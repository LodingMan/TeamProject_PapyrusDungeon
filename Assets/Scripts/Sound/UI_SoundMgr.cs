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
    public AudioClip audioDungeon;
    public AudioClip audioDungeonFail;

    void Start()
    {
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
}
