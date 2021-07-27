using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    private float destroyWeight = 5.0f;

    // 현재 씬에 존재하는 모든 게임오브젝트의 Update() 함수가 1회 실행된 후 실행된다
    private void LateUpdate()
    {
        if( transform.position.y < stageData.LimitMin.y - destroyWeight ||
            transform.position.y > stageData.LimitMax.y + destroyWeight ||
            transform.position.x < stageData.LimitMin.x - destroyWeight ||
            transform.position.x > stageData.LimitMax.x + destroyWeight )
        {
            Destroy(gameObject);
        }
    }
}

/*
 * Desc : 
 *  화면 밖으로 나갈 수 있는 오브젝트에 부착해서 사용
 *  오브젝트가 일정 범위 바깥으로 나가면 삭제
 */
