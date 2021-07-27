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
    private KeyCode keyCodeJump = KeyCode.Space;    // ����Ű space
    //[SerializeField]
    //private KeyCode keyCodeAttack = KeyCode.A;    // ����Ű A

    private AudioSource audioSource;                // ���� ��� ������Ʈ

    private Animator animator;                      // �ִϸ��̼�

    private bool isDie = false;                     // ��� ����

    private int score;
    public int Score
    {
        // Score�� ���� ������ ���� �ʵ���
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
        // �÷��̾� ����� ���� �Ұ����ϰ� ����
        if (isDie == true) return;
        // 5000 ���� ������ Ŭ����
        if (score >= 5000) IsClear();  

        // ����Ű�� Up/Down���� ����/����
        if (Input.GetKeyDown(keyCodeJump))
        {
            StartJump();
        }
        else if (Input.GetKeyUp(keyCodeJump))
        {
            StopJump();
        }
    }

    // ������ ���� ������ �����ϱ� ���� �ڷ�ƾ
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
            animator.Rebind();                                                          // �ִϸ��̼� �ǰ���
            animator.Play("PlayerUp");                                                  // PlayerUp �ִϸ��̼� ���
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300f);         // ���� 300f ��ŭ ����
            audioSource.Play();                                                         // ���� �Ҹ� ���
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    // ����ִ� ���� 1�ʴ� ������ 100���� ȹ���ϱ� ���� �ڷ�ƾ
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
        // ��� �� Ű �÷��̾� ���� ���� ���� ���ϰ� �ϴ� ����
        isDie = true;
        // �÷��̾� ������Ʈ ����
        Destroy(gameObject);
        // Destroy(GetComponent<CircleCollider2D>());
        // ����̽��� ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        // �÷��̾� ����� nextSceneName ������ �̵�
        SceneManager.LoadScene(nextSceneName);
    }

}
