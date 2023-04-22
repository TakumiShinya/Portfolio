using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    //弾のプレハブ
    public GameObject bulletPrefab;
    //弾の発射間隔
    private int shotInterval;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //発射間隔をカウントアップ
        shotInterval++;

        if (shotInterval % 300 == 0)
        {
            //弾を複製
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //弾のRigidbodyを取得
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            //弾を画面下に発射
            rigidbody.AddForce(transform.forward * 300);
            //弾を5秒後に破壊する
            Destroy(bullet, 5.0f);
        }
    }
}
    
