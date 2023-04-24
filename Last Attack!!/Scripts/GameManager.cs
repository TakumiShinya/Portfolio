using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //スコア算出のための変数
    public float mouseCount;

    //カウントを開始し始めたか
    public bool isCount=false;

    //球を発射したか
    public bool isImpulse=false;

    //制限時間が終了したか
    public bool isEnd=false;

    //制限時間
    public float time=60.0f;

    //ドラゴンに与えるダメージ
    public static float damage;

    //テキスト
    [SerializeField]
    private GameObject pressTextUI;
    
    //ためるボタン
    [SerializeField]
    private GameObject chargeButton;
    
    //打ち出すボール
    [SerializeField]
    private GameObject ball;
    
    //制限時間を表示するテキスト
    [SerializeField]
    private TextMeshProUGUI timeText;

    //音量操作スライダー
    [SerializeField]
    private Slider powerSlider;

    //時間経過で減るゲージの量
    [SerializeField]
    private float mouseDecrease;

    //BGMを格納しておくリスト
    [SerializeField]
    private List<AudioSource> audios = new List<AudioSource>();

    //プレイヤーのアニメーター
    private Animator anim;

    //ゲージの上限
    private float maxCount=200f;

    //bgm
    private AudioSource bgm;
    
    //風のBGM
    private AudioSource windBgm;
    
    //球を打ち出すときのSE
    private AudioSource shotSE;

    //フェードアウトする割合
    [SerializeField]
    private float fadeDration;

    //フェードイン/アウトまでの時間
    private float fadingTime=2f;

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
        mouseCount=0f;

        //音量調節スライダーの上限を初期化
        powerSlider.maxValue = maxCount;

        //フェードイン開始
        FadeController.isFadeIn = true;

        //ダメージを初期化
        damage=0;

        //アニメーターを代入
        anim =  GameObject.Find("Player").GetComponent<Animator>();
    
        //BGMを初期化
        windBgm=audios[0];
        shotSE=audios[1];
        bgm=audios[2];
        //BGMの音量をスライダーの値にする
        bgm.volume=SoundSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの値をスコアの数だけ減らす
        powerSlider.value=maxCount-mouseCount;

        //スコアと時間をUIに反映
        timeText.text = "Time : " + time.ToString("f0");
        
        //フェードインが終わってカウントが始まる前に作動
        if(!FadeController.isFadeIn && !isCount)
        {
                //UIを表示
                pressTextUI.SetActive(true);
                chargeButton.SetActive(true);
        }

        //カウントダウンが始まって、制限時間がくるまで作動
        if(isCount&&time>0f)
        {
            //時間を減らす
            time -= Time.deltaTime;

            //プレイヤーの詠唱モーション
            anim.SetBool("is_Interact", true);

            //スコアが0より大きい場合作動
            if(mouseCount > 0)
            {
                //スコアを減らし続ける
                mouseCount -= mouseDecrease;
            }
        }

        //制限時間が終了したら1度だけ作動
        if(time<=0f && !isEnd)
        {
            //コルーチン開始
            StartCoroutine("ShotBall");
            isEnd = true;
        }

        //フェードアウトが始まったら作動
        if(FadeController.isFadeOut)
        {
            //BGMの音量を次第に小さく
            fadingTime-=Time.deltaTime;
            bgm.volume=fadingTime/fadeDration;
        }
    }

    //球を打ち出すコルーチン関数
    private IEnumerator ShotBall()
    {
        //ためるボタンを非表示
        chargeButton.SetActive(false);

        //プレイヤーの攻撃モーション
        anim.SetBool("is_Attack", true);

        //2秒待つ
        yield return new WaitForSeconds(2);

        //球を打ち出す効果音出す
        shotSE.PlayOneShot(shotSE.clip);
        
        //ボール複製
        GameObject newBall = Instantiate(ball);
        newBall.transform.position =new Vector3(21f, 0.5f, 15f);
        isImpulse=true;

        //ダメージ計算
        damage=300f*mouseCount;

        //3秒待つ
        yield return new WaitForSeconds(3);
        
        //フェードアウト開始
        FadeController.isFadeOut=true;

        //3秒待つ
        yield return new WaitForSeconds(3);
        
        //リザルト画面に移動
        SceneManager.LoadScene("Result");
    }

    //ためるボタンに使う関数
    public void ChargePower()
    {
        //制限時間が0以上の時作動
        if(time>=0.0f)
        {
            //カウントしていなければ作動
            if(!isCount)
            {
                //カウント開始
                isCount=true;
                
                //UIを非表示
                pressTextUI.SetActive(false);
                
                //風の音を止めてBGMを鳴らす
                windBgm.Stop();
                bgm.Play();
            }
            //ボタンを押すたびに値を増やす
            mouseCount+=Random.Range(2.0f,4.0f);
        }
    }
}
