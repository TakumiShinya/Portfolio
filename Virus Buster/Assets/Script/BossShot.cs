using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject deathBulletPrefab;
    public List<GameObject> bullets = new List<GameObject>();

    private int count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 45 * Time.deltaTime, 0);
        count++;
        switch (this.gameObject.name)
        {
            case "Middleboss":
                if (count % 300 == 0) Boss(deathBulletPrefab);
                break;
            case "Cube":
                if (count % 300 == 0) Boss(deathBulletPrefab);
                break;
        }
    }

    private void Boss(GameObject gameObject)
    {
        GameObject bullet = Instantiate(gameObject, transform.position, Quaternion.identity);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((transform.forward + transform.right) * 400);
        Destroy(bullet, 7.0f);
     }
}
