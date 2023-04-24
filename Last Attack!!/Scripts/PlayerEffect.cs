using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    //ゲームマネージャクラス
    public GameManager myManager;

    //エフェクトを管理するリスト
    [SerializeField]
    private List<GameObject> effects = new List<GameObject>();

    //SEを管理するリスト
    [SerializeField]
    private List<AudioSource> effectSE = new List<AudioSource>();

    //各エフェクト表示されているか
    [SerializeField]
    private bool magicPowerup;
    [SerializeField]
    private bool firePowerup;
    [SerializeField]
    private bool thunderPowerup;
    [SerializeField]
    private bool explosionPowerup;


    // Start is called before the first frame update
    void Start()
    {
        //GameManagerクラスを代入
        myManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //カウントが50以上で作動
        if(myManager.mouseCount>=50 && magicPowerup == false)
        {
            effects[0].SetActive(true);
            effectSE[0].PlayOneShot(effectSE[0].clip);
            magicPowerup = true;
        }
        if(myManager.mouseCount<50)
        {            
            effects[0].SetActive(false);
            magicPowerup = false;   
        }

        //カウントが100以上で作動
        if(myManager.mouseCount>=100 && firePowerup == false)
        {
            effects[1].SetActive(true);
            effectSE[1].PlayOneShot(effectSE[1].clip);
            firePowerup = true;
        }
        if(myManager.mouseCount<100)
        {
            effects[1].SetActive(false);
            firePowerup = false;
        }

        //カウントが150以上で作動
        if(myManager.mouseCount>=150 && thunderPowerup == false)
        {
            effects[2].SetActive(true);
            effectSE[2].PlayOneShot(effectSE[2].clip);
            thunderPowerup = true;
        }
        if(myManager.mouseCount<150)
        {
            effects[2].SetActive(false);
            thunderPowerup = false;  
        }

        //カウントが200以上で作動
        if(myManager.mouseCount>=200& explosionPowerup == false)
        {
            effects[3].SetActive(true);
            effectSE[3].PlayOneShot(effectSE[3].clip);
            explosionPowerup = true;
        }
        if(myManager.mouseCount<200)
        {
            effects[3].SetActive(false);
            explosionPowerup = false;
        }
    }
}
