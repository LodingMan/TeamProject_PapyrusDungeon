using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioSource audioS;
    private void Start()
    {
        audioS = GameObject.Find("BGM_Manager").GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Vol"))
        {
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Vol");
            audioS.volume = PlayerPrefs.GetFloat("Vol");
        }
        else
        {
            gameObject.GetComponent<Slider>().value = audioS.volume;
        }

    }

    public void SetBGM()
    {
        audioS.volume = gameObject.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Vol", audioS.volume);
    }
}
