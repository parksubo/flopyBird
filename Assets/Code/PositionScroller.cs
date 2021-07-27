using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField]
    private Transform target;   // ���� ���ӿ����� �� ���� ����� ���ΰ� ������ Ÿ��
    [SerializeField]
    private float scrollRange = 17.75f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.left;

    // Update is called once per frame
    private void Update()
    {
        // �����  moveDirection �������� moveSpeed�� �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // ����� ������ ������ ����� ��ġ �缳��
        if (transform.position.x <= -scrollRange)
        {
            transform.position = target.position + Vector3.right * scrollRange;
        }
    }
}

/*
 * Desc :  
 * ��ũ�ѽ�Ű�� ���� ������Ʈ�� �����ؼ� ���
 */