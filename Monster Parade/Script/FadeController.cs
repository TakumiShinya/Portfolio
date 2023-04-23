using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private float fadeSpeed = 0.02f;
    private float red, green, blue, alfa;

    public static bool isFadeOut = false;
    public static bool isFadeIn = false;

    private Image fadeImage; 

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn){
            StartFadeIn();
        }
        if(isFadeOut){
            StartFadeOut();
        }
    }

    private void StartFadeIn(){
        alfa-=fadeSpeed;
        SetAlpha();
        if(alfa<=0){
            isFadeIn = false;
            fadeImage.enabled = false;
        }
    }

    private void StartFadeOut(){
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if(alfa>= 1){
            isFadeOut = false;
        }
    }

    private void SetAlpha(){
        fadeImage.color = new Color(red,green,blue,alfa);
    }
}
