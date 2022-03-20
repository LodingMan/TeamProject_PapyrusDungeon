using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsTest : MonoBehaviour
{
    public int[] hero = new int[3];

    public int[] item = new int[4];

    public int[] itemRank = new int[2];

    public int money;



    void Start()
    {
        PlayerPrefs.SetInt("hero1", hero[0]);
        PlayerPrefs.SetInt("hero2", hero[1]);
        PlayerPrefs.SetInt("hero3", hero[2]);
        PlayerPrefs.SetInt("item1", item[0]);
        PlayerPrefs.SetInt("item2", item[1]);
        PlayerPrefs.SetInt("item3", item[2]);
        PlayerPrefs.SetInt("item4", item[3]);
        PlayerPrefs.SetInt("rank1", itemRank[0]);
        PlayerPrefs.SetInt("rank2", itemRank[1]);
        PlayerPrefs.SetInt("money", money);

        PlayerPrefs.Save();

    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

}
