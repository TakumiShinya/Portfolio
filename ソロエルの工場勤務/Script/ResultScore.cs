using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScore : MonoBehaviour
{
    public GameObject scoreText=null;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameManager.getScore();
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
