using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DestroyBall : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    private AudioSource audio1;

    [SerializeField]
    private GameObject pleasePressText;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio1 = audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag!="Wall"){
            Destroy(other.gameObject);
            if(other.gameObject.tag=="Ball"){
                Instantiate(ball);
                audio1.PlayOneShot(audio1.clip);
                ScoreManager.score-=100;
                pleasePressText.SetActive(true);
            }
        }
    }
}
