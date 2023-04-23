using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBall : MonoBehaviour
{
    [SerializeField]
    private float destroyCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag=="CopyBall"){
            destroyCount+=Time.deltaTime;
            if((int)destroyCount==30){
                Destroy(this.gameObject);
            }
        }
    }
}
