using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController playerController;
    public void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 "Player"라면
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().OnDie();
            OnDie();
            // 적 오브젝트를 삭제하기 위해 호출하는 함수
        }
    }

    private void OnDie()
    {
        Destroy(gameObject);
    }
}
