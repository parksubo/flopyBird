using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private string clearSceneName;
    [SerializeField]
    private KeyCode keyCodeJump = KeyCode.Space;    // 점프키 space
    //[SerializeField]
    //private KeyCode keyCodeAttack = KeyCode.A;    // 공격키 A

    private AudioSource audioSource;                // 사운드 재생 컴포넌트

    private Animator animator;                      // 애니메이션

    private bool isDie = false;                     // 사망 여부

    private int score;
    public int Score
    {
        // Score의 값이 음수가 되지 않도록
        set => score = Mathf.Max(0, value);
        get => score;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        StartCoroutine("GetPlayerScore");
    }

    private void Update()
    {
        // 플레이어 사망시 조작 불가능하게 설정
        if (isDie == true) return;
        // 5000 점이 넘으면 클리어
        if (score >= 5000) IsClear();  

        // 점프키를 Up/Down으로 시작/종료
        if (Input.GetKeyDown(keyCodeJump))
        {
            StartJump();
        }
        else if (Input.GetKeyUp(keyCodeJump))
        {
            StopJump();
        }
    }

    // 누르는 동안 점프를 지속하기 위한 코루틴
    public void StartJump()
    {
        StartCoroutine("TryJump");
    }
    public void StopJump()
    {
        StopCoroutine("TryJump");
    }

    private IEnumerator TryJump()
    {
        while(true)
        {
            animator.Rebind();                                                          // 애니메이션 되감기
            animator.Play("PlayerUp");                                                  // PlayerUp 애니메이션 재생
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f);         // 위로 300f 만큼 점프
            audioSource.Play();                                                         // 점프 소리 재생
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    // 살아있는 동안 1초당 점수를 100점씩 획득하기 위한 코루틴
    private IEnumerator GetPlayerScore()
    {
        while (true)
        {
            score += 100;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void IsClear()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(clearSceneName);
    }

    public void OnDie()
    {
        // 사망 시 키 플레이어 조작 등을 하지 못하게 하는 변수
        isDie = true;
        // 플레이어 오브젝트 삭제
        Destroy(gameObject);
        // Destroy(GetComponent<CircleCollider2D>());
        // 디바이스에 획득한 점수 score 저장
        PlayerPrefs.SetInt("Score", score);
        // 플레이어 사망시 nextSceneName 씬으로 이동
        SceneManager.LoadScene(nextSceneName);
    }

}
