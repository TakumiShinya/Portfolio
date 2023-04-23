using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score=0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
    }

    public static int getScore(){
        return score;
    }
}
