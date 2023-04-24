using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    //スライダーの変数
    Slider m_Slider;

    //スライダーの値を格納する変数
    public static float value;

    //最初に発動
    void Awake()
    {
        //変数の初期化
        m_Slider = GetComponent<Slider>();
        m_Slider.value = AudioListener.volume;
        value = m_Slider.value;
    }

    //オブジェクトが表示されたら作動
    private void OnEnable()
    {
        //スライダーの値を等しくする
        m_Slider.value = AudioListener.volume;

        //リスナーを追加
        m_Slider.onValueChanged.AddListener((sliderValue) => AudioListener.volume = sliderValue);
    }

    //オブジェクトが非表示になったら作動
    private void OnDisable()
    {
        //全てのリスナーを削除
        m_Slider.onValueChanged.RemoveAllListeners();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
