using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimManager : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private BlockManager myBlock;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myBlock = GameObject.Find("GameManager").GetComponent<BlockManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myBlock.isPressJump)anim.SetBool("is_Walk",true);
    }
}
