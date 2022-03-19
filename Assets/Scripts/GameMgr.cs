using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public Transform[] pos = new Transform[3];
    public GameObject[] heroes = new GameObject[3];
    public GameObject[] items = new GameObject[3];
    public RectTransform slot1;
    public RectTransform slot2;

    public int[] hero = new int[3];
    public int item;
    public int item2;
    public bool isFull = false;


    public void Awake()
    {
        if (PlayerPrefs.HasKey("hero1"))
        {
            hero[0] = PlayerPrefs.GetInt("hero1");
            hero[1] = PlayerPrefs.GetInt("hero2");
            hero[2] = PlayerPrefs.GetInt("hero3");
            item = PlayerPrefs.GetInt("item");
            item2 = PlayerPrefs.GetInt("item2");


        }
    }

    public void CreateHeroes()
    {
        if (hero[0] == 10)
        {
            GameObject hero1 = Instantiate(heroes[0]);
            hero1.transform.position = pos[0].transform.position;
        }
        if (hero[1] == 11)
        {
            GameObject hero1 = Instantiate(heroes[1]);
            hero1.transform.position = pos[1].transform.position;
        }
        if (hero[2] == 12)
        {
            GameObject hero1 = Instantiate(heroes[2]);
            hero1.transform.position = pos[2].transform.position;
        }
        if (item == 15 && isFull == false)
        {
            isFull = true;
            GameObject item = Instantiate(items[0]);
            item.transform.SetParent(slot1);
            item.transform.position = slot1.transform.position;
            item.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(item == 15 && isFull == true)
        {
            GameObject item = Instantiate(items[0]);
            item.transform.SetParent(slot2);
            item.transform.position = slot2.transform.position;
            item.transform.localScale = new Vector3(1, 1, 1);
        }
        if (item2 == 16 && isFull == false)
        {
            GameObject item2 = Instantiate(items[1]);
            item2.transform.SetParent(slot1);
            item2.transform.position = slot1.transform.position;
            item2.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(item2 == 16 && isFull == true)
        {
            GameObject item2 = Instantiate(items[1]);
            item2.transform.SetParent(slot2);
            item2.transform.position = slot2.transform.position;
            item2.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ResetHeroes()
    {
        PlayerPrefs.DeleteAll();
        hero[0] = 0;
        hero[1] = 0;
        hero[2] = 0;
    }

}
