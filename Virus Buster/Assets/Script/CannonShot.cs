using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{

    public GameObject bulletPrefab;
    private int count=0;
    private float speed=0.1f;
    public int cannonFreq=300;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 p = new Vector3(speed, 0, 0);
        transform.Translate(p);
        if (this.transform.position.x < -11.5 || this.transform.position.x > 11.5) speed *= -1;
        count++;
        if (count % cannonFreq == 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * 300);
            Destroy(bullet, 8.0f);
        }
    }
}
