using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    //ボールのスピード
    public float speed = 1.0f;
    //ボールのRididbody
    private Rigidbody myRigid;
    //Gamemanagerクラス
    public GameManager myManager;
    //ボールを落とした際のペナルティのクラス
    public GamePenalty myPenalty;
    //ボールが落下した時の音
    private AudioSource ballAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyコンポーネントを取得
        Myrigid = GetComponent<Rigidbody>();
        //右上に力を加え発射
        Myrigid.AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);
        //AudioSourceコンポーネントを取得
        ballAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //ボールが何かに衝突した際に呼び出される
    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかったオブジェクトのタグがfloorの時
        if (collision.gameObject.tag == "floor")
        {
            //ライフが残っていれば
            if (myManager.getLife() > 0)
            {
                //このボールがコピーでなければ
                if (this.gameObject.tag != "Ballcopy")
                {
                    //ボール落下の効果音を鳴らす
                    ballAudio.PlayOneShot(ballAudio.clip);
                    //ライフを１減らす
                    myManager.setLife(-1);
                    //ボールの位置をもとに戻す
                    this.transform.position = new Vector3(0.0f, 1.0f, -3.0f);
                    //ステージによって異なるペナルティを呼び出す
                    if (SceneManager.GetActiveScene().name == "Stage1")
                    {
                        myPenalty.PenaltyStage1();
                    }
                    else if (SceneManager.GetActiveScene().name == "Stage2")
                    {
                        myPenalty.PenaltyStage2();
                    }
                    else if (SceneManager.GetActiveScene().name == "Stage3")
                    {
                        myPenalty.PenaltyStage3();
                    }
                }
                //コピーされたボールの場合
                else
                {
                    //ボールを破壊する
                    Destroy(this.gameObject);
                }
                
            }
        }
    }
}
