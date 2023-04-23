using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{
    Slider m_Slider;//���ʒ����p�X���C�_�[
    public static float value;

    [SerializeField]
    bool m_isInput;//�L�[���͂Œ����o�[�𓮂�����悤�ɂ��邩
    [SerializeField]
    float m_ScroolSpeed = 1;//�L�[���͂Œ����o�[�𓮂����X�s�[�h
    void Awake()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.value = AudioListener.volume;
        value = m_Slider.value;
    }

    private void OnEnable()
    {
        m_Slider.value = AudioListener.volume;
        //�X���C�_�[�̒l���ύX���ꂽ�特�ʂ��ύX����
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
