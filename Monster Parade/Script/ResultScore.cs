using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultScore : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI commentText;

    [SerializeField]
    private GameObject fadeUI;

    //[SerializeField]
    //private TextMeshProUGUI rankingText;

    public List<int> scoreList= new List<int>();
    public List<int> saveScoreList= new List<int>();
    [SerializeField]
    private int score;
    private int[] src={0,0,0,0,0};
    // Start is called before the first frame update
    void Start()
    {
        score = ScoreManager.getScore();
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score);
    }

    // Update is called once per frame
    void Update()
    {
        if(score<=2000){
            commentText.text="ダメダメね…";
        }
        if(score>2000&&score<=4000){
            commentText.text="やり直しよ!!";
        }
        if(score>4000&&score<=6000){
            commentText.text="まあまあだわ。";
        }
        if(score>6000&&score<=8000){
            commentText.text="上出来よ!";
        }
        if(score>8000&&score<=10000){
            commentText.text="すごいじゃない!!";
        }
        if(score>10000){
            commentText.text="あなたは最高の\n退魔士よ!!!";
        }

        scoreText.text= "Score : "+ score;
    }
    public void Retry(){
        fadeUI.SetActive(true);
        StartCoroutine("RetryCoroutine");
    }

    private IEnumerator RetryCoroutine(){
        FadeController.isFadeOut =true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage");
    }

    public void BackTitle(){
        fadeUI.SetActive(true);
        StartCoroutine("BackTitleCoroutine");
    }

    private IEnumerator BackTitleCoroutine(){
        FadeController.isFadeOut =true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Title");
    }
}
