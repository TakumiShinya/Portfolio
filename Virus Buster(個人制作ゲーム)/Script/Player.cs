using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public GameManager myManager;
    public GamePenalty myPenalty;
    private int count = 0;
    public bool isCollision = false;

    private AudioSource audio1;
    private AudioSource audio2;
    private AudioSource audio3;
    private AudioSource audio4;
    private AudioSource audio5;





    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio1 = audioSources[0];
        audio2 = audioSources[1];
        audio3 = audioSources[2];
        audio4 = audioSources[3];
        audio5 = audioSources[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision == true)
        {
            count++;
            if (count % 15 == 0) isCollision = false;
        }
        if (isCollision==false&&Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x - this.transform.localScale.x / 2 > -11.5)
                this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (isCollision == false&&Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x + this.transform.localScale.x / 2 < 11.5)
                this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            count = 0;
            isCollision = true;
            audio4.PlayOneShot(audio4.clip);
            
        }
        if (collision.gameObject.tag == "Death")
        {
            myManager.setLife(-1);
            audio2.PlayOneShot(audio2.clip);
            if (SceneManager.GetActiveScene().name == "Stage2")
            {
                myPenalty.PenaltyStage2();
            }
            if (SceneManager.GetActiveScene().name == "Stage3")
            {
                myPenalty.PenaltyStage3();
            }

        }
        if (collision.gameObject.tag == "Cure")
        {
            myManager.setLife(1);
            audio3.PlayOneShot(audio3.clip);
        }
        if (collision.gameObject.tag == "Addball")
        {
            myManager.BallCopy();
            audio5.PlayOneShot(audio5.clip);
        }
        if (collision.gameObject.tag == "Addscore")
        {
            myManager.AddScore(100);
            audio3.PlayOneShot(audio3.clip);
        }
        if (collision.gameObject.tag == "ball"||collision.gameObject.tag=="Ballcopy")
        {
            audio1.PlayOneShot(audio1.clip);
        }
    }
}

