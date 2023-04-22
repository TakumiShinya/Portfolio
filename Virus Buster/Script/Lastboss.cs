using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lastboss : MonoBehaviour
{
    private const int hitpoint = 20;
    public GameManager myManager;
    public CannonShot mycannon;
    public Slider slider;
    private int currentHp;
    private int count;
    private int blockAddCount = 600;
    public List<GameObject> blocks = new List<GameObject>();

    public GameObject deathBulletPrefab;
    public GameObject bulletPrefab;

    private AudioSource audio1;


    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = hitpoint;
        currentHp = hitpoint;
        slider.value = currentHp;
        
        audio1 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0, 45 * Time.deltaTime, 0);
        count++;
        if (count % 360 == 0) Boss(deathBulletPrefab);
        if (count % 100 == 0) Boss(bulletPrefab);

        if (count % blockAddCount ==0 )
        {
            for(int i = 0; i < 3; i++)
            {
                GameObject block = GameObject.Find("OriginBlock");
                GameObject mobu = Instantiate(block, new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(0.0f, 7.0f)), Quaternion.identity);
                blocks.Add(mobu);
            }    
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball" || collision.gameObject.tag == "Ballcopy")
        {
            currentHp--;
            audio1.PlayOneShot(audio1.clip);
            slider.value = currentHp;
            switch (currentHp)
            {
                case 5:
                    GetComponent<Renderer>().material.color = new Color32(0, 255, 255, 1);
                    mycannon.cannonFreq = 120;
                    blockAddCount = 180;

                    break;
                case 10:
                    GetComponent<Renderer>().material.color = new Color32(40, 190, 190, 1);
                    mycannon.cannonFreq = 180;
                    blockAddCount = 300;

                    break;
                case 15:
                    GetComponent<Renderer>().material.color = new Color32(120, 120, 255, 1);
                    mycannon.cannonFreq = 240;
                    blockAddCount = 480;
                    break;
                case 0:
                    myManager.SoundPlayBlock();
                    Destroy(this.gameObject);
                    foreach(GameObject b in blocks)
                    {
                        Destroy(b);
                    }
                    myManager.AddScore(1000);
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
