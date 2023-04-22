using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    //弾のプレハブ
    public GameObject bulletPrefab;
    //ボスの球のプレハブ
    public GameObject deathBulletPrefab;
    //弾を発射する感覚
    private int shotInterval;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ボスの回転
        RotateBoss();

        // 弾を発射する処理
        ShotBullet();
    }

    // ボスの回転
    private void RotateBoss()
    {
        this.transform.Rotate(0, 45 * Time.deltaTime, 0);
    }

    // 弾を発射する処理
    private void ShotBullet()
    {
        // インターバルをカウントアップ
        shotInterval++;

        // 中ボス、キューブの場合、定期的に弾を発射
        if (this.gameObject.name == "Middleboss" || this.gameObject.name == "Cube")
        {
            if (shotInterval % 300 == 0)
            {
                //弾を生成し発射
                InstantiateBullet(deathBulletPrefab);
            }
        }
    }

    // 弾を生成する処理
    private void InstantiateBullet(GameObject bulletPrefab)
    {
        //指定した弾を複製
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //弾のRididbodyを取得
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        //弾を発射
        rigidbody.AddForce((transform.forward + transform.right) * 400);
        //球を7秒後に消去する
        Destroy(bullet, 7.0f);
    }
}
