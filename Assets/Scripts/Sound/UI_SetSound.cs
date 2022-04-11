using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetSound : MonoBehaviour
{
    public AudioSource audioSE;
    // Start is called before the first frame update
    private void Start()
    {
        audioSE = GameObject.Find("UI_SoundMgr").GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("VolSE"))
        {
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("VolSE");
            audioSE.volume = PlayerPrefs.GetFloat("VolSE");
        }
        else
        {
            gameObject.GetComponent<Slider>().value = audioSE.volume;
        }


    }
    private void Update()
    {
        SetSound();
    }

    public void SetSound() //나중에 켜기
    {
        audioSE.volume = gameObject.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("VolSE", audioSE.volume);
    }
}
