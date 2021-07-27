using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject enemyPrefab;              // �� ������
    [SerializeField]
    private float positionY = -2.6f;             // �� ������ y ��ġ
    [SerializeField]
    private float delayTime = 10.0f;              // �� ���� ������ �ð�
    [SerializeField]
    private float spawnStartTime = 2.0f;         // ���� ���� �ֱ� 
    [SerializeField]
    private float spawnEndTime = 3.0f;
    private float spawnTime;
    [SerializeField]
    private float minSize = 2.0f;                // ���� ���� ũ��
    [SerializeField]
    private float maxSize = 5.0f;
    

    private float time = 0.0f, currentTime = 0.0f;    // n �ð��� ���̵� ��ȭ �ϱ� ���� �ð�

    private int difficulty = 1;                       // ���̵�

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= delayTime && difficulty < 3)   // delayTime���� ���̵� up, �ִ� 3�������� �ö�
        {
             DifficultyUp();
             currentTime = 0;
             difficulty++;
        }

    }

    private void DifficultyUp()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            spawnTime = Random.Range(spawnStartTime, spawnEndTime);
            // �� ũ�� �������� ����
            float sizeOfEnemy = Random.Range(minSize, maxSize);
            enemyPrefab.transform.localScale = new Vector3(sizeOfEnemy, sizeOfEnemy, 0);
            // �� ĳ���� ��ġ
            Vector3 position = new Vector3(stageData.LimitMax.x + 4.0f, positionY + sizeOfEnemy, 0.0f);
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }
    
}

