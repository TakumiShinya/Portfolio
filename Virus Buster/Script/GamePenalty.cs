using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePenalty : MonoBehaviour
{
    public GameManager myManager;
    private int count = 0;
    public Lastboss lastBoss;

    private AudioSource audio1;
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

    public void PenaltyStage1()
    {
        GameObject mobu = GameObject.Find("OriginBlock");

        if (myManager.getLife() < 3 && count == 0)
        {
            audio1.PlayOneShot(audio1.clip);
            for (int i = 0; i / 2 < 7; i += 2)
            {
                GameObject mobu1 = Instantiate(mobu, new Vector3(-6.0f + i, 1.0f, 5.0f), Quaternion.identity);
                myManager.blocks.Add(mobu1);

            }
            count++;
        }
        if (myManager.getLife() < 2 && count == 1)
        {
            audio1.PlayOneShot(audio1.clip);

            for (int i = 0; i / 2 < 7; i += 2)
            {
                GameObject mobu2 = Instantiate(mobu, new Vector3(-6.0f + i, 1.0f, 4.0f), Quaternion.identity);
                myManager.blocks.Add(mobu2);


            }
            count++;
        }
    }
    public void PenaltyStage2()
    {
        GameObject mobu = GameObject.Find("OriginMobu");

        if (myManager.getLife() < 3 && count == 0)
        {
            audio1.PlayOneShot(audio1.clip);


            for (int i = 0; i < 12; i++)
            {
                GameObject mobu1 = Instantiate(mobu, new Vector3(-11.0f + i * 2, 1.0f, 3.0f), Quaternion.identity);

            }
            count++;
        }
        if (myManager.getLife() < 2 && count == 1)
        {
            audio1.PlayOneShot(audio1.clip);

            for (int i = 0; i < 12; i++)
            {
                GameObject mobu1 = Instantiate(mobu, new Vector3(-11.0f + i * 2, 1.0f, 2.0f), Quaternion.identity);

            }
            count++;
        }
    }
    public void PenaltyStage3()
    {
        audio1.PlayOneShot(audio1.clip);

        GameObject block = GameObject.Find("OriginBlock");
        for(int i = 0; i < 3; i++)
        {
            GameObject mobu = Instantiate(block, new Vector3(Random.Range(-10.0f, 10.0f), 1.0f, Random.Range(0.0f, 7.0f)), Quaternion.identity);
            lastBoss.blocks.Add(mobu);
        }

    }
}
