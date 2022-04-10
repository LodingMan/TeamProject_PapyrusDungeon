using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneScript : MonoBehaviour
{
    public AudioSource audioSS;
    public AudioClip audioTown;
    public AudioClip audioTent;
    public AudioClip audioCombat;

    void Start()
    {
        audioSS.clip = audioTown;
        audioSS.Play();
        if (PlayerPrefs.HasKey("Vol"))
        {
            audioSS.volume = PlayerPrefs.GetFloat("Vol");
        }
        DontDestroyOnLoad(gameObject);
    }

}
