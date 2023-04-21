using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody Myrigid;
    public GameManager myManager;
    public GamePenalty myPenalty;
    private AudioSource audio1;

    // Start is called before the first frame update
    void Start()
    {
        Myrigid = GetComponent<Rigidbody>();
        Myrigid.AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);
        audio1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            if (myManager.getLife() > 0)
            {
                if (this.gameObject.tag != "Ballcopy")
                {
                    audio1.PlayOneShot(audio1.clip);
                    myManager.setLife(-1);
                    this.transform.position = new Vector3(0.0f, 1.0f, -3.0f);
                    if (SceneManager.GetActiveScene().name == "Stage1")
                    {
                        myPenalty.PenaltyStage1();
                    }
                    else if (SceneManager.GetActiveScene().name == "Stage2")
                    {
                        myPenalty.PenaltyStage2();
                    }
                    else if (SceneManager.GetActiveScene().name == "Stage3")
                    {
                        myPenalty.PenaltyStage3();
                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
                
            }
        }
    }
}
