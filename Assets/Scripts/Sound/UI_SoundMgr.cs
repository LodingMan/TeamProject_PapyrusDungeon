using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SoundMgr : MonoBehaviour
{
    public AudioSource audioSE;
    public AudioClip audioBtn;
    public AudioClip audioOption;
    public AudioClip audioGold;
    public AudioClip audioGold02;
    public AudioClip audioDungeon;
    public AudioClip audioDungeonFail;
    public AudioClip audioMenu;
    public AudioClip audioTrainStart;
    public AudioClip audioContent;
    public AudioClip audioDungeonStart;
    void Start()
    {
        audioSE = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("VolSE"))
        {
            audioSE.volume = PlayerPrefs.GetFloat("VolSE");
        }
        //DontDestroyOnLoad(gameObject);
    }

    public void PlayClipBtn()
    {
        audioSE.clip = audioBtn;
        audioSE.Play();
    }
    public void PlayClipOption()
    {
        audioSE.clip = audioOption;
        audioSE.Play();
    }
    public void PlayClipGold()
    {
        audioSE.clip = audioGold;
        audioSE.Play();
    }

    public void PlayClipGold02()
    {
        audioSE.clip = audioGold02;
        audioSE.Play();
    }
    public void PlayClipDungeonSelect()
    {
        audioSE.clip = audioDungeon;
        audioSE.Play();
    }
    public void FailClipDungeonSelect()
    {
        audioSE.clip = audioDungeonFail;
        audioSE.Play();
    }
    public void PlayClipMenu()
    {
        audioSE.clip = audioMenu;
        audioSE.Play();

    }
    public void PlayClipContent()
    {
        audioSE.clip = audioContent;
        audioSE.Play();
    }

    public void PlayClipDGStart()
    {
        audioSE.clip = audioDungeonStart;
        audioSE.Play();
    }

    
}
