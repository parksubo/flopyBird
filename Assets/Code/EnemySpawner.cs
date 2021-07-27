using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject enemyPrefab;              // 적 프리팹
    [SerializeField]
    private float positionY = -2.6f;             // 적 프리팹 y 위치
    [SerializeField]
    private float delayTime = 10.0f;              // 적 스폰 딜레이 시간
    [SerializeField]
    private float spawnStartTime = 2.0f;         // 랜덤 생성 주기 
    [SerializeField]
    private float spawnEndTime = 3.0f;
    private float spawnTime;
    [SerializeField]
    private float minSize = 2.0f;                // 랜덤 생성 크기
    [SerializeField]
    private float maxSize = 5.0f;
    

    private float time = 0.0f, currentTime = 0.0f;    // n 시간후 난이도 변화 하기 위한 시간

    private int difficulty = 1;                       // 난이도

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= delayTime && difficulty < 3)   // delayTime마다 난이도 up, 최대 3레벨까지 올라감
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
            // 적 크기 랜덤으로 설정
            float sizeOfEnemy = Random.Range(minSize, maxSize);
            enemyPrefab.transform.localScale = new Vector3(sizeOfEnemy, sizeOfEnemy, 0);
            // 적 캐릭터 위치
            Vector3 position = new Vector3(stageData.LimitMax.x + 4.0f, positionY + sizeOfEnemy, 0.0f);
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);
        }
    }
    
}

