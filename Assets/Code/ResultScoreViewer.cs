using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // textMesh  네임 스페이스에 저장된 값을 사용하기 위함

public class ResultScoreViewer : MonoBehaviour
{
    private TextMeshProUGUI textResultScore;

    private void Awake()
    {
        textResultScore = GetComponent<TextMeshProUGUI>();
        // Stage에서 저장한 점수를 불러와서 score 변수에 저장
        int score = PlayerPrefs.GetInt("Score");
        // textResultScore UI에 점수 갱신
        textResultScore.text = "Result Score " + score;
    }

}
