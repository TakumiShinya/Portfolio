using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public SkinnedMeshRenderer face_SkinnedMeshRenderer;
    private Animator anim;

    [SerializeField]
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        score = ScoreManager.getScore();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(score<=2000){
            //Debug.Log("Oh");
            anim.SetBool("isOhMy", true);
        }
        if(score>2000&&score<=4000){
            //Debug.Log("Bad");
            anim.SetBool("isBad", true);
        }
        if(score>4000&&score<=6000){
            //Debug.Log("Good");
            anim.SetBool("isGood", true);
        }
        if(score>6000&&score<=8000){
            //Debug.Log("Great");
            anim.SetBool("isGreat", true);
        }
        if(score>8000&&score<=10000){
            //Debug.Log("Excellent");
            anim.SetBool("isExcell", true);
        }
        if(score>10000){
            //Debug.Log("Perfect");
            anim.SetBool("isPer", true);
        } 
    }
}
