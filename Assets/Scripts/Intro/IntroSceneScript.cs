using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneScript : MonoBehaviour
{
    public AudioSource audioSS;

    void Start()
    {
        if (PlayerPrefs.HasKey("Vol"))
        {
            audioSS.volume = PlayerPrefs.GetFloat("Vol");
        }
        DontDestroyOnLoad(gameObject);
    }


}
