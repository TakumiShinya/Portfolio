﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //弾が何かに当たった時に呼び出される
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor"|| collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

