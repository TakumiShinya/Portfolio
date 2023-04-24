using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //RigidBodyを取得する関数
    private Rigidbody myRigid;

    //ボールのスピード
    public float speed=10f;

    //ゲームマネージャークラス
    [SerializeField]
    private GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        //RigidBodyを取得
        myRigid=this.GetComponent<Rigidbody>();

        //GameManagerを取得
        myManager= GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //ボール発射のタイミングで作動
        if(myManager.isImpulse){
            //一瞬力を加える
            myRigid.AddForce(transform.forward * speed, ForceMode.Impulse);
            myManager.isImpulse=false;
        }

    }

    //接触判定
    private void OnCollisionEnter(Collision other) {
        //触れたオブジェクトのタグで判別
        switch(other.gameObject.tag){
            //Enemyの場合
            case "Enemy":
            //非表示にする
            this.gameObject.SetActive(false);
            break;

        }    
    }
}
