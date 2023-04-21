using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    public List<GameObject> balls = new List<GameObject>();


    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public GameObject readyUI;
    public GameObject lifeText = null;
    public GameObject scoreText = null;
    public GameObject player;

    private AudioSource audio1;
    private AudioSource audio2;
    private AudioSource audio3;
    private AudioSource audio4;

    private int life = 3;
    private bool isgameclear = false;
    private bool isgameover = false;
    private int score=0;

    private int[] resultID = new int[3];
    private float[] resultAR = new float[3];

    private void Awake()
    {
        readyUI.SetActive(true);
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio1 = audioSources[0];
        audio2 = audioSources[1];
        audio3 = audioSources[2];
        audio4 = audioSources[3];
        audio1.Play();
        Time.timeScale = 1;
        readyUI.SetActive(false);
    }

    public int getLife()
    {
        return this.life;
    }
    public void setLife(int a)
    {
        this.life += a;
    }

    // Update is called once per frame
    void Update()
    {
        Text life_text = lifeText.GetComponent<Text>();
        life_text.text = "life: " + life;
        Text score_text = scoreText.GetComponent<Text>();
        score_text.text = "score: " + score;
        if (isgameclear != true)
        {
            if (DestroyAllBlocks())
            {
                //ゲームクリア
                GameClear();

            }
        }
        if (isgameover != true)
        {
            if (life < 1)
            {
                GameOver();
                isgameover = true;
            }
        }
        

    }

    //ブロックが全部消えたか判定
    private bool DestroyAllBlocks()
    {
        foreach(GameObject b in blocks)
        {
            if (b != null) return false;
        }
        return true;
    }
    //ゲームオーバーUIの操作
    public void GameOver()
    {
        foreach(GameObject b in balls)
        {
            Destroy(b);

        }
        Destroy(player);
        gameOverUI.SetActive(true);
        audio1.Stop();
        audio2.Play();
        
    }

    public void GameClear()
    {
        GameObject[] bullets=GameObject.FindGameObjectsWithTag("bullet"); 
        GameObject[] dBullets = GameObject.FindGameObjectsWithTag("Death");
        GameObject[] cures= GameObject.FindGameObjectsWithTag("Cure");
        GameObject[] addballs = GameObject.FindGameObjectsWithTag("Addball");
        GameObject[] addscores = GameObject.FindGameObjectsWithTag("Addscore");
        GameObject[] mobus = GameObject.FindGameObjectsWithTag("Mobu");
        audio1.Stop();
        audio3.Play();
        gameClearUI.SetActive(true);
        isgameclear = true;
        foreach (GameObject b in balls)
        {
            Destroy(b);

        }
        DestroyEach(mobus);
        DestroyEach(bullets);
        DestroyEach(dBullets);
        DestroyEach(cures);
        DestroyEach(addballs);
        DestroyEach(addscores);
    }

    public void DestroyEach(GameObject[] gameObjects)
    {
        foreach(GameObject game in gameObjects)
        {
            if(game!=null)Destroy(game);
        }
    }

    //ゲームリトライボタンの操作
    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int addscore)
    {
        score += addscore;
        
    }

   
    public void BallCopy()
    {
        GameObject ball = GameObject.Find("OriginBall");
        GameObject copy = Instantiate(ball, new Vector3(0.0f, 1.0f, -4.0f), Quaternion.identity);
        copy.transform.position = new Vector3(0.0f, 1.0f, -1.0f);
        Rigidbody rigidbody = copy.GetComponent<Rigidbody>();
        rigidbody.AddForce((transform.forward + transform.right) * 7, ForceMode.VelocityChange);
        balls.Add(copy);


    }

    private void PlayerPowerUp()
    {
        Vector3 p = player.transform.localScale;
        p.x += 0.3f;
        player.transform.localScale = p;
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
    public void SoundPlayBlock()
    {
        audio4.PlayOneShot(audio4.clip);
    }

}
