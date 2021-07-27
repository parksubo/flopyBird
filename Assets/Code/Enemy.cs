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
        // ������ �ε��� ������Ʈ�� �±װ� "Player"���
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().OnDie();
            OnDie();
            // �� ������Ʈ�� �����ϱ� ���� ȣ���ϴ� �Լ�
        }
    }

    private void OnDie()
    {
        Destroy(gameObject);
    }
}
