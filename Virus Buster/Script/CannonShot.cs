using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{

    //弾のプレハブ
    public GameObject bulletPrefab;
    //弾の発射間隔
    private int cannonInterval=0;
    //弾の発射頻度
    public int cannonFreq=300;
    //砲台が左右に動く時の速度
    private float speed=0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //砲台の移動量を宣言
        Vector3 cannonVector = new Vector3(speed, 0, 0);
        //砲台を移動させる
        transform.Translate(cannonVector);

        //インターバルをカウントアップ
        cannonInterval++;
        //法大が左右どちらかの壁についたら
        if (this.transform.position.x < -11.5 || this.transform.position.x > 11.5)
        {
            //反対に動くようにする
            speed *= -1;
        }
        //設定した発射頻度になったら作動
        if (cannonInterval % cannonFreq == 0)
        {
            shotCannon(bulletPrefab);
        }
    }

    private void shotCannon(GameObject prefab)
    {
        //弾を複製
        GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
        //弾のRigidbodyを取得
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        //画面下方向に弾を飛ばす
        rigidbody.AddForce(transform.forward * 300);
        //発射から8秒後に弾を破壊する
        Destroy(bullet, 8.0f);
    }
}
