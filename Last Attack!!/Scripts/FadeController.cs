using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    //フェードする速さ
    private float fadeSpeed = 0.03f;

    //パネルのRGBAの値
    private float red, green, blue, alfa;

    //フェードアウトしたか
    public static bool isFadeOut = false;

    //フェードインしたか
    public static bool isFadeIn = false;

    //フェードするときに使うパネル
    private Image fadeImage; 

    // Start is called before the first frame update
    void Start()
    {
        //フェードのためのパネルを取得
        fadeImage = GetComponent<Image>();

        //アルファ値を取得
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        //フェードインする
        if(isFadeIn){
            StartFadeIn();
        }

        //フェードアウトする
        if(isFadeOut){
            StartFadeOut();
        }
    }

    //フェードイン関数
    private void StartFadeIn(){
        alfa-=fadeSpeed;
        SetAlpha();
        if(alfa<=0){
            isFadeIn = false;
            fadeImage.enabled = false;
        }
    }

    //フェードアウト関数
    private void StartFadeOut(){
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if(alfa>= 1){
            isFadeOut = false;
        }
    }

    //色を初期化する関数
    private void SetAlpha(){
        fadeImage.color = new Color(red,green,blue,alfa);
    }
}
