using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    //ステージ説明用UI
    public GameObject explainUI;
    //ステージ選択用UI
    public GameObject selectUI;
    //ゲーム終了用UI
    public GameObject quitUI;
    //遊び方説明用UI
    public GameObject howtoUI;
    //敵ブロックのUI
    public GameObject enemyBlock;
    //ボスブロックのUI
    public GameObject bossBlock;

    //選択したステージ番号を格納する変数
    private int stage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //以下ボタン用関数
    //
    public void GameStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public void GoStage()
    {
        if(stage==1)SceneManager.LoadScene("Stage1");
        if (stage == 2) SceneManager.LoadScene("Stage2");
        if (stage == 3) SceneManager.LoadScene("Stage3");
    }
    public void GoExplain1()
    {
        selectUI.SetActive(false);
        explainUI.SetActive(true);
        enemyBlock.SetActive(true);
        stage = 1;
    }
    public void GoExplain2()
    {
        selectUI.SetActive(false);
        explainUI.SetActive(true);
        enemyBlock.SetActive(true);
        stage = 2;
    }
    public void GoExplain3()
    {
        selectUI.SetActive(false);
        explainUI.SetActive(true);
        bossBlock.SetActive(true);
        stage = 3;
    }
    public void BackMenu()
    {
        explainUI.SetActive(false);
        selectUI.SetActive(true);
        enemyBlock.SetActive(false);
        bossBlock.SetActive(false);
        stage = 0;
    }
    public void BackTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void OpenQuitMenu()
    {
        quitUI.SetActive(true);
    }
    public void CloseQuitMenu()
    {
        quitUI.SetActive(false);
    }
    public void OpenHowto()
    {
        howtoUI.SetActive(true);
    }
    public void CloseHowto()
    {
        howtoUI.SetActive(false);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
