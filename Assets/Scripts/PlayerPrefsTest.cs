using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsTest : MonoBehaviour
{
    public int heroNum1;
    public int heroNum2;
    public int heroNum3;
    public int item;
    public int item2;
    public int hp;
    public int mp;

    void Start()
    {
        PlayerPrefs.SetInt("hero1", heroNum1);
        PlayerPrefs.SetInt("hero2", heroNum2);
        PlayerPrefs.SetInt("hero3", heroNum3);
        PlayerPrefs.SetInt("item", item);
        PlayerPrefs.SetInt("item2", item2);
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("mp", mp);

    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

}
