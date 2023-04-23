using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private GameObject block1;
    [SerializeField]
    private GameObject block2;
    [SerializeField]
    private GameObject bossBlock;

    [SerializeField]
    private GameObject metalBlock;
    [SerializeField]
    private TimeManager myTime;

    private float[] probs = new float[3];
    [SerializeField]
    private int count=0;
    private float time=60.0f;
    private int blockTime=300;
    
    public bool isPressJump;
    private bool isBoss=false;

    // Start is called before the first frame update
    private void Start()
    {
        probs[0] = 0.40f;
        probs[1] = 0.40f;
        probs[2] = 0.20f;
        AudioSource[] audioSources = GetComponents<AudioSource>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump")){
            if(!isPressJump){
                isPressJump=true;
                count=60;
            }
        }
        count++;
        if(isPressJump){
            time -= Time.deltaTime;
            Invoke("Instboss", 30.0f);
            if(count % blockTime == 0){
                for(int i=0;i<21;i+=10){
                    float p=EncountCulc(probs);
                    if(p==0){
                        Instantiate(block1, new Vector3(-10.0f + i, 0, 15.0f), Quaternion.Euler(0,180,0));
                    }
                    if(p==1){
                        Instantiate(block2, new Vector3(-10.0f + i, 0, 15.0f), Quaternion.Euler(0,180,0));
                    }
                    if(p==2){
                        Instantiate(metalBlock, new Vector3(-10.0f + i, 0, 15.0f), Quaternion.Euler(0,180,0));
                    }
                }
            }
            if(time<10.0f){
                blockTime=100;
            }
        }
    }

    public float EncountCulc(float[] probs)
    {
        float total = 0;
        foreach (float f in probs) total += f;

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }

        }
        return probs.Length - 1; ;
    }

    private void Instboss(){
        if(!isBoss){
        blockTime=180;
        Instantiate(bossBlock, new Vector3( 0, -0.25f, 30.0f), Quaternion.Euler(0,180,0));
        SoundManager.PlayDragonSE();
        }
        isBoss=true;
    }
}
