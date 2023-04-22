using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitpoint=3;
    public GameManager myManager;
    private AudioSource audio1;

    private float[] probs = new float[4];
    private Vector3 v;


    // Start is called before the first frame update
    void Start()
    {
        probs[0] = 0.30f;
        probs[1] = 0.20f;
        probs[2] = 0.20f;
        probs[3] = 0.30f;
        v = this.transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball"||collision.gameObject.tag=="Ballcopy")
        {
            hitpoint--;
            audio1 = GetComponent<AudioSource>();
            audio1.PlayOneShot(audio1.clip);
            switch (hitpoint)
            {
                case 1:
                    GetComponent<Renderer>().material.color = new Color32(120, 190, 190, 1);
                    break;
                case 2:
                    GetComponent<Renderer>().material.color = new Color32(120, 90, 190, 1);
                    break;
                case 0:
                    Destroy(this.gameObject);
                    myManager.SoundPlayBlock();
                    myManager.AddScore(100);
                    float p = myManager.EncountCulc(probs);
                    if (p == 0)
                    {
                        GameObject block = GameObject.FindGameObjectWithTag("Cure");
                        GameObject mobu = Instantiate(block, v, Quaternion.identity);
                        Rigidbody rigidbody = mobu.GetComponent<Rigidbody>();
                        rigidbody.AddForce(-transform.forward * 300);

                    }
                    if (p == 1)
                    {

                        GameObject block = GameObject.Find("Addball");
                        GameObject mobu = Instantiate(block, v, Quaternion.identity);
                        Rigidbody rigidbody = mobu.GetComponent<Rigidbody>();
                        rigidbody.AddForce(-transform.forward * 300);

                    }
                    if (p == 2)
                    {
                        GameObject block = GameObject.Find("Addscore");
                        GameObject mobu = Instantiate(block, v, Quaternion.identity);
                        Rigidbody rigidbody = mobu.GetComponent<Rigidbody>();
                        rigidbody.AddForce(-transform.forward * 300);

                    }
                    break;
            }
        }
    }


}
