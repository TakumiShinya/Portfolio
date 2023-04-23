using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody myRigid;
    [SerializeField]
    private float nowVelo;

    private float speedLimit=50.0f;
    // Start is called before the first frame update
    void Start()
    {
        myRigid=this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && myRigid.velocity == Vector3.zero){

            myRigid.AddForce(new Vector3(1,0,1) * speed, ForceMode.VelocityChange);

        }
        nowVelo=Mathf.Abs(myRigid.velocity.x)+Mathf.Abs(myRigid.velocity.z);
    }

    private void OnCollisionEnter(Collision other) {
        if(nowVelo<speedLimit){
            myRigid.velocity*=1.05f;
        }


        if(Mathf.Abs(myRigid.velocity.x)<5)
        {
            Vector3 v = myRigid.velocity;
            v.x *= 5;
            myRigid.velocity = v;
        }

        if(Mathf.Abs(myRigid.velocity.z)<5)
        {
            Vector3 v = myRigid.velocity;
            v.z *= 5;
            myRigid.velocity = v;
        }
    }
}
