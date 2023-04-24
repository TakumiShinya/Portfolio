using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    //フェードするためのパネル
    [SerializeField]
    private GameObject fadePanel;
    
    //BGM
    [SerializeField]
    private AudioSource bgm;
    
    //フェードする割合
    [SerializeField]
    private float fadeDration;
    
    //クレジットを表示するパネル
    [SerializeField]
    private GameObject creditPanel;

    //フェードするまでのパネル
    private float fadingTime=3f;

    // Start is called before the first frame update
    void Start()
    {
        //変数を初期化
        AudioSource[] audioSources =GetComponents<AudioSource>();
        bgm = GetComponent<AudioSource>();
        bgm = audioSources[1];
    }

    // Update is called once per frame
    void Update()
    {
        //フェードアウト始まったら作動
        if(FadeController.isFadeOut){
            fadingTime-=Time.deltaTime;
            bgm.volume-=0.02f;
        }
    }

    //ゲームスタートのボタン関数
    public void StartGame(){
        StartCoroutine("StartGameCoroutine");
    }

    //ゲームスタートコルーチン
    private IEnumerator StartGameCoroutine(){
        fadePanel.SetActive(true);
        FadeController.isFadeOut =true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage");
    }

    //クレジットを表示する関数
    public void ShowCredit(){
        creditPanel.SetActive(true);
    }
    
    //クレジットを非表示にする関数
    public void CloseCredit(){
        creditPanel.SetActive(false);
    }

    //ゲーム終了の関数
    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
