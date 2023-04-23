using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<string> Items = new List<string>();
    public List<string> Aims = new List<string>();

    private int count;
    private int iCount = 0;
    public static int score;
    private float countdown = 3f;
    private float time=80;
    private int textTime ;
    public float value;


    private float[] probs = new float[4];

    public GameObject rItem;
    public GameObject bItem;
    public GameObject gItem;
    public GameObject scoreText = null;
    public GameObject timeText = null;
    public GameObject wantText = null;
    public GameObject wantText2 = null;
    public GameObject cubeUI = null;
    public GameObject countdownText = null;
    public GameObject countdownText2 = null;
    public GameObject OkText = null;
    public GameObject NoText = null;
    public GameObject Nottext = null;

    private AudioSource audio1;
    private AudioSource audio2;
    private AudioSource audio3;
    private AudioSource audio4;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rItem = Resources.Load("RedItem") as GameObject;
        gItem = Resources.Load("GreenItem") as GameObject;
        bItem = Resources.Load("BlueItem") as GameObject;

        probs[0] = 0.25f;
        probs[1] = 0.25f;
        probs[2] = 0.25f;
        probs[3] = 0.25f;

        AimSet();
        score = 0;

        value = SoundSlider.getSoundValue();
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = value;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio1 = audioSources[0];
        audio2 = audioSources[1];
        audio3 = audioSources[2];
        audio4 = audioSources[3];
        cubeUI.SetActive(true);
        audio1.PlayDelayed(2);
    }

    // Update is called once per frame
    void Update()
    {

        TextMeshProUGUI countdown_text = countdownText.GetComponent<TextMeshProUGUI>();
        countdown_text.text =  countdown.ToString("f0");
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown < 0)
        {
            countdownText.SetActive(false);


            if (time <= 0)
            {
                countdownText2.SetActive(true);
                wantText.SetActive(false);
                wantText2.SetActive(false);
                scoreText.SetActive(false);
                timeText.SetActive(false);
            }
            if (time <= -3)
            {
                SceneManager.LoadScene("result");
            }
            wantText.SetActive(true);
            wantText2.SetActive(true);

            //countdownText2.SetActive(false);
            TextMeshProUGUI score_text = scoreText.GetComponent<TextMeshProUGUI>();
            score_text.text = "‹‹—¿ : " + score + "‰~";

            TextMeshProUGUI time_text = timeText.GetComponent<TextMeshProUGUI>();
            time_text.text = "Žc‚è‹Î–±ŽžŠÔ : " + time.ToString("f0");

            time -= Time.deltaTime;
            count++;
            textTime++;
            if (count % 120 == 0)
            {
                ItemInstantiate();
            }
            if (textTime % 180 == 0)
            {
                OkText.SetActive(false);
                NoText.SetActive(false);
                Nottext.SetActive(false);
            }

        }

    }

    private void ItemInstantiate()
    {

            if (iCount % 3 == 0)
            {
                Instantiate(rItem, new Vector3(-8.0f, 2.0f, -5.0f), Quaternion.identity);
            }
            if (iCount % 3 == 1)
            {
                Instantiate(gItem, new Vector3(-8.0f, 2.0f, -5.0f), Quaternion.identity);
            }
            if (iCount % 3 == 2)
            {
                Instantiate(bItem, new Vector3(-8.0f, 2.0f, -5.0f), Quaternion.identity);
            }

        iCount++;
    }

    public void AddName(string name) {
        Items.Add(name);
    }

    public void CheckItem()
    {
        OkText.SetActive(false);
        NoText.SetActive(false);
        Nottext.SetActive(false);
        textTime = 0;
        int itemcount=0;
        if (Aims.Count > Items.Count)
        {
            Debug.Log("Not Enough!!!");
            Nottext.SetActive(true);
            Items.Clear();
            audio4.PlayOneShot(audio4.clip);
        }
        else
        {
            foreach (string s in Aims)
            {
                if (s == Items[itemcount])
                {
                    itemcount++;
                }
            }
            if (itemcount == Aims.Count)
            {
                Debug.Log("OK!!");
                OkText.SetActive(true);
                AddScore(1000 * Aims.Count);
                audio2.PlayOneShot(audio2.clip);
            }
            else
            {
                Debug.Log("No...");
                NoText.SetActive(true);
                AddScore(-1000);
                audio3.PlayOneShot(audio3.clip);
            }
            Items.Clear();
            Aims.Clear();
            AimSet();
            
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
    private void AimSet()
    {
            for (int i = 0; i <= 2; i++)
            {
                float p = EncountCulc(probs);
                if (p == 0)
                {
                    Aims.Add("RItem");
                }
                if (p == 1)
                {
                    Aims.Add("GItem");
                }
                if (p == 2)
                {
                    Aims.Add("BItem");
                }
            }
    }
    private void AddScore(int addscore)
    {
        score += addscore;

    }

    public static int getScore()
    {
        return score;
    }
}

