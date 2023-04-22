using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //ブロックの体力
    public int hitpoint=3;
    //Gamemanagerクラス
    public GameManager myManager;
    //ブロックが破壊された時の効果音
    private AudioSource blockAudio;
    //アイテムがドロップする確率を格納する配列
    private float[] probs = { 0.30f, 0.20f, 0.20f, 0.30f };
    //ブロックの現在の位置を格納する変数
    private Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        //ブロックの現在の位置を取得
        v = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ブロックと何かがぶつかったときに呼び出される
    private void OnCollisionEnter(Collision collision)
    {
        //ブロックがボールとぶつかったら
        if (collision.gameObject.CompareTag("ball") || collision.gameObject.CompareTag("Ballcopy"))
        {
            //ブロックの体力を１減らす
            hitpoint--;
            //AudioSourceコンポーネントを取得
            blockAudio = GetComponent<AudioSource>();
            //ブロックがぶつかった時の効果音を再生
            blockAudio.PlayOneShot(blockAudio.clip);
            //体力に応じて操作を切り替える
            switch (hitpoint)
            {
                case 1:
                    //オブジェクトの色を変える
                    GetComponent<Renderer>().material.color = new Color32(120, 190, 190, 1);
                    break;
                case 2:
                    //オブジェクトの色を変える
                    GetComponent<Renderer>().material.color = new Color32(120, 90, 190, 1);
                    break;
                case 0:
                    //ブロック破壊音を再生
                    myManager.SoundPlayBlock();
                    //スコアを追加
                    myManager.AddScore(100);

                    //アイテムが落ちる確率を計算
                    float p = myManager.EncountCulc(probs);

                    //アイテムオブジェクトの宣言
                    GameObject item;
                    //抽選された番号によって切り替え
                    switch(p){
                        case 0:
                            //回復アイテムを指定
                            item = GameObject.FindGameObjectWithTag("Cure");
                            break;
                        case 1:
                            //ボール追加アイテムを指定
                            item = GameObject.Find("Addball");
                            break;
                        case 2:
                            //スコア加算アイテムを指定
                            item = GameObject.Find("Addscore");
                            break;
                        default:
                        return;

                    }

                    //シーン上で指定したアイテムを複製
                    GameObject itemCopy = Instantiate(item, v, Quaternion.identity);
                    //複製したアイテムのRigidBodyを取得
                    Rigidbody rigidbody = itemCopy.GetComponent<Rigidbody>();
                    //アイテムを画面下方向に飛ばす
                    rigidbody.AddForce(-transform.forward * 300);
                    
                    //ブロックを破壊する
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}
