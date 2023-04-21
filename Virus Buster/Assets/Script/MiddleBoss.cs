using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss : MonoBehaviour
{
    private int hitpoint = 5;
    public GameManager myManager;
    public GameObject bulletPrefab;
    public List<GameObject> bullets = new List<GameObject>();
    private int count;
    private AudioSource audio1;


    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 45 * Time.deltaTime, 0);
        count++;
        if (count % 300 == 0) Boss(bulletPrefab);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball"|| collision.gameObject.tag == "Ballcopy")
        {
            hitpoint--;
            audio1.PlayOneShot(audio1.clip);

            switch (hitpoint)
            {
                case 1:
                    GetComponent<Renderer>().material.color = new Color32(0, 255, 255, 1);
                    break;
                case 2:
                    GetComponent<Renderer>().material.color = new Color32(40, 190, 190, 1);
                    break;
                case 3:
                    GetComponent<Renderer>().material.color = new Color32(120, 120, 255, 1);
                    break;
                case 4:
                    GetComponent<Renderer>().material.color = new Color32(190, 40, 255, 1);
                    break;
                case 0:
                    Destroy(this.gameObject);
                    myManager.AddScore(500);
                    myManager.SoundPlayBlock();
                    break;

            }
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
