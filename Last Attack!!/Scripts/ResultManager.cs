using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    //機能ボタン
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private GameObject titleButton;
    [SerializeField]
    private GameObject rankingButton;
    
    //スコア＆文字表示用UI
    [SerializeField]
    private GameObject victoryText;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    //プレイヤーとドラゴンのアニメーター
    private Animator anim;
    private Animator enemyAnim;

    //フェードしたか
    private bool isFade=false;

    //勝利BGM
    private AudioSource victoryBGM;

    //フェードする期間
    [SerializeField]
    private float fadeDration;

    //フェードまでの時間
    private float fadingTime=1f;

    // Start is called before the first frame update
    void Start()
    {
        //変数初期化
        FadeController.isFadeIn = true;
        anim =  GameObject.Find("Player").GetComponent<Animator>();
        enemyAnim= GameObject.Find("Enemy").GetComponent<Animator>();
        AudioSource[] audioSources =GetComponents<AudioSource>();
        victoryBGM = GetComponent<AudioSource>();
        victoryBGM=audioSources[1];
        victoryBGM.volume=SoundSlider.value;

        //ダメージを表示
        scoreText.text = "Damage : " + (int)GameManager.damage;
    }

    // Update is called once per frame
    void Update()
    {

        //アニメーション再生
        anim.SetBool("is_Victory", true);
        enemyAnim.SetBool("is_Die",true);

        //フェードインが終わったら作動
        if(!FadeController.isFadeIn)
        {
            //一階だけ作動
            if(!isFade)
            {
                //UIを表示＆BGM再生
                retryButton.SetActive(true);
                titleButton.SetActive(true);
                rankingButton.SetActive(true);
                victoryText.SetActive(true);
                isFade=true;
                victoryBGM.Play();
            }

        }

        //フェードアウトが終わったら作動
        if(FadeController.isFadeOut)
        {
            //UIを消す
            retryButton.SetActive(false);
            titleButton.SetActive(false);
            rankingButton.SetActive(false);
            fadingTime-=Time.deltaTime;
            victoryBGM.volume=fadingTime/fadeDration;

        }
    }

    //リトライボタン用関数
    public void Retry(){
        StartCoroutine("RetryCoroutine");
    }

    //リトライボタンコルーチン
    private IEnumerator RetryCoroutine(){
        FadeController.isFadeOut =true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage");
    }

    //タイトルに戻る用関数
    public void BackTitle(){
        StartCoroutine("BackTitleCoroutine");
    }

    //タイトルボタンコルーチン
    private IEnumerator BackTitleCoroutine(){
        FadeController.isFadeOut =true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Title");
    }

    //ランキング呼び出し
    public void LoadRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking ((int)GameManager.damage);
    }
}
