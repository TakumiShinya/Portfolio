using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public float time = 60.0f;
    private int count;
    private bool isCount;
    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private GameObject readyUI;

    [SerializeField]
    private GameObject finishUI;
    
    [SerializeField]
    private GameObject pressUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            if(!isCount){
                isCount=true;
            }       
            readyUI.SetActive(false);
            pressUI.SetActive(false);
        }
        if(isCount)time -= Time.deltaTime;
        timeText.text = "Time : " + time.ToString("f0");

        if(time < 0){
            isCount=false;
            finishUI.SetActive(true);
            pressUI.SetActive(false);
            SetFalse();
            StartCoroutine(LoadResult());
        }
    }

    private IEnumerator LoadResult(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Result");
    }

    private void SetFalse(){
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        GameObject[] metalBlocks = GameObject.FindGameObjectsWithTag("MetalBlock");
        GameObject[] cBalls = GameObject.FindGameObjectsWithTag("CopyBall");
        GameObject bossBlock= GameObject.FindGameObjectWithTag("BossBlock");
        GameObject bItem= GameObject.FindGameObjectWithTag("BallItem");
        GameObject sItem= GameObject.FindGameObjectWithTag("ScoreItem");
        GameObject barItem= GameObject.FindGameObjectWithTag("BarItem");
        foreach(GameObject b in blocks){
            Destroy(b);
        }
        foreach(GameObject mb in metalBlocks){
            Destroy(mb);
        }

        foreach(GameObject cb in cBalls){
            Destroy(cb);
        }
        Destroy(ball);
        Destroy(bItem);
        Destroy(sItem);
        Destroy(barItem);
        Destroy(bossBlock);
    }
}
