using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public GameObject TitleUI;
    public GameObject ExplainUI;
    private float value;

    // Start is called before the first frame update
    void Start()
    {
        value = SoundSlider.getSoundValue();
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoExplain()
    {
        TitleUI.SetActive(false);
        ExplainUI.SetActive(true);

    }
    public void Backtitle()
    {
        TitleUI.SetActive(true);
        ExplainUI.SetActive(false);
    }
}
