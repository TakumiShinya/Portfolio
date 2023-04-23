using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField]
    private GameObject howToUI;
    [SerializeField]
    private GameObject creditUI;
    [SerializeField]
    private GameObject fadeUI;
    [SerializeField]
    private TextMeshProUGUI howToText;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    [SerializeField]
    private GameObject girl;
    [SerializeField]
    private GameObject image1;
    [SerializeField]
    private GameObject image2;
    [SerializeField]
    private GameObject image3;
    [SerializeField]
    private GameObject image4;
    [SerializeField]
    private GameObject image5;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private GameObject backButton;

    private bool isHowTo;
    private int countClick;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SwitchText();
        if(!isHowTo)countClick=0;
    }

    public void StartGame(){
        fadeUI.SetActive(true);
        StartCoroutine("StartGameCoroutine");
    }

    private IEnumerator StartGameCoroutine(){
        FadeController.isFadeOut =true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage");
    }

    public void HowToPlay(){
        girl.SetActive(true);
        howToUI.SetActive(true);
        nextButton.SetActive(true);
        backButton.SetActive(true);
        isHowTo=true;
    }

    public void CloseHowTo(){
        girl.SetActive(false);
        howToUI.SetActive(false);
        nextButton.SetActive(false);
        backButton.SetActive(false);
        isHowTo=false;
    }

    public void OpenCredit(){
        creditUI.SetActive(true);
    }

    public void CloseCredit(){
        creditUI.SetActive(false);
    }

    public void NextButton(){
        countClick++;
    }

    public void BackButton(){
        if(countClick-1!=-1){
            countClick--;
        }
    }
    
    private void SwitchText(){
        switch (countClick)
        {
            case 0:
            howToText.text="Hello! 私はこの町に住む退魔士よ！\n最近、魔物が墓地から\nあふれ出てきて大変なのよ…\n誰か一緒にやってくれないかしら…？";
            image5.SetActive(false);
            break;
            case 1:
            howToText.text="あ！あなた…！\nちょうどいいわ、\nちょっと手伝いなさい！";
            image1.SetActive(false);
            break;
            case 2:
            howToText.text="ん？難しそう？そんなことないわ！\n私が魔法で作った光の球を\n魔物に当てて倒すだけよ！\n魔物を倒すと得点をゲットできるわ！";
            image1.SetActive(true);
            image2.SetActive(false);
            break;
            case 3:
            howToText.text="魔物の種類は全部で3種類。\nお化け・ミイラが100ポイント、\n骸骨が500ポイントよ。";
            image1.SetActive(false);
            image2.SetActive(true);
            image3.SetActive(false);
            break;
            case 4:
            howToText.text="そして、途中で乱入してくるドラゴンを\n倒すと、1000ポイントゲットできるわ！";
            image2.SetActive(false);
            image3.SetActive(true);
            image4.SetActive(false);
            break;
            case 5:
            howToText.text="あと、魔物を倒すと、たまにアイテムを\n落とすみたい。";
            image3.SetActive(false);
            image4.SetActive(true);
            break;
            case 6:
            howToText.text="赤いのは、火の玉を1つ呼び出すわ。\n青いのは、スコアを100点もらえるわ。\n"
                             + "そして最後に、緑のは、あなたの操る\nバーの長さを少し長くするわ。";
            image4.SetActive(true);
            break;
            case 7:
            howToText.text="あ、そう、光は貴重な資源だから、\n間違っても落としたら駄目よ！！\nもし落としたら、スコアを減点するわよ！！";
            image4.SetActive(false);
            image5.SetActive(false);
            nextButton.SetActive(true);
            break;
            case 8:
            howToText.text="たくさん魔物を倒してくれれば、\n私が特別に褒めてあげるわ!\nさあ、魔物退治の始まりよ！！";
            image5.SetActive(true);
            nextButton.SetActive(false);
            break;
            default:
            break;
        }
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
