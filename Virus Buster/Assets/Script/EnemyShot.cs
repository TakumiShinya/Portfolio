using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private int count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count++;

        if (count % 300 == 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * 300);
            Destroy(bullet, 5.0f);
        }
    }
}
    
