using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{
    Slider m_Slider;//音量調整用スライダー
    public static float value;

    [SerializeField]
    bool m_isInput;//キー入力で調整バーを動かせるようにするか
    [SerializeField]
    float m_ScroolSpeed = 1;//キー入力で調整バーを動かすスピード
    void Awake()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.value = AudioListener.volume;
        value = m_Slider.value;
    }

    private void OnEnable()
    {
        m_Slider.value = AudioListener.volume;
        //スライダーの値が変更されたら音量も変更する
        m_Slider.onValueChanged.AddListener((sliderValue) => AudioListener.volume = sliderValue);
    }

    private void OnDisable()
    {
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
    public static float getSoundValue()
    {
        return value;
    }
}
