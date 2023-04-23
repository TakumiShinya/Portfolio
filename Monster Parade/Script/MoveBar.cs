using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBar : MonoBehaviour
{
    
    [SerializeField]
    private float accel;

    [SerializeField]
    private GameObject ball;

    private Rigidbody myRigid;
    
    [SerializeField]
    private ScoreManager myScore;
    
    private AudioSource audio1;
    private AudioSource audio2;
    private AudioSource audio3;
    private AudioSource audio4;

    // Start is called before the first frame update
    void Start()
    {
        myRigid=GetComponent<Rigidbody>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio1 = audioSources[0];
        audio2 = audioSources[1];
        audio3 = audioSources[2];
        audio4 = audioSources[3];
    }

    // Update is called once per frame
    void Update()
    {
        myRigid.AddForce(Vector3.right*Input.GetAxis("Horizontal")*accel, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision other) {

        switch(other.gameObject.tag){
            case "Ball":
            case "CopyBall":
            audio1.PlayOneShot(audio1.clip);
            break;
            case "BallItem":
            GameObject copy = Instantiate(ball);
            Rigidbody rigidbody = copy.GetComponent<Rigidbody>();
            rigidbody.AddForce((transform.forward + transform.right) * 10, ForceMode.VelocityChange);
            audio2.PlayOneShot(audio2.clip);
            Destroy(other.gameObject);
            break;
            case "ScoreItem":
            ScoreManager.score+=50;
            audio3.PlayOneShot(audio3.clip);
            Destroy(other.gameObject);
            break;
            case "BarItem":
            Vector3 bar = this.gameObject.transform.localScale;
            if(bar.x<30)
            {
                audio4.PlayOneShot(audio4.clip);
                bar.x+=2;
                this.gameObject.transform.localScale=bar;
            }
            Destroy(other.gameObject);
            break;
        }
    }
}
