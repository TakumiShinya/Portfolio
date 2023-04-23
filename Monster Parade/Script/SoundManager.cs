using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource stageBGM;
    private AudioSource stopSE;
    public static AudioSource destroySE;
    public static AudioSource reflectSE;
    public static AudioSource explosionSE;
    public static AudioSource dragonSE;


    private bool isStop=false;

    public float time;
    [SerializeField]
    private TimeManager myTime;
    private void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        stageBGM = audioSources[0];
        destroySE = audioSources[1];  
        reflectSE = audioSources[2];
        dragonSE = audioSources[3];
        explosionSE =audioSources[4]; 
        stopSE = audioSources[5];
    }
    private IEnumerator Start()
    {
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        stageBGM.Play();
    }
    // Update is called once per frame
    void Update()
    {
        time=myTime.time;
        if(time<0){
            if(!isStop){
            stageBGM.Stop();
            stopSE.PlayOneShot(stopSE.clip);
            }
            isStop=true;
        }
    }

    public static void PlayDestroySE(){
        destroySE.PlayOneShot(destroySE.clip);
    }

    public static void PlayReflectSE(){
        reflectSE.PlayOneShot(reflectSE.clip);
    }

    public static void PlayDragonSE(){
        dragonSE.PlayOneShot(dragonSE.clip);
    }

    public static void PlayExploSE(){
        explosionSE.PlayOneShot(explosionSE.clip);
    }
}
