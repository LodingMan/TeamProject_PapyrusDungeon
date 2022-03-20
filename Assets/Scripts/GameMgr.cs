using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public Transform[] pos = new Transform[3];
    public GameObject[] heroes = new GameObject[3];
    public GameObject[] itemList = new GameObject[4];
    public GameObject[] slots = new GameObject[4];
    public GameObject[] shopList = new GameObject[4];
    public List<int> randomlist = new List<int>();
    public GameObject shop;

    public List<GameObject> hasHeroes = new List<GameObject>();
    public List<GameObject> hasItems = new List<GameObject>();

    public int[] hero = new int[3];
    public int[] items = new int[4];
    public bool isDone = false;
    public bool isFull = false;
    public bool isOlduser = false;
    public bool isItemHas = false;

    public int money;
    public Text moneyTxt;


    public void Awake()
    {
        money = PlayerPrefs.GetInt("money");
        PlayerDataLoad();
        
    }
    public void PlayerDataLoad()
    {
        if (PlayerPrefs.HasKey("hero1"))
        {
            isDone = true;
            hero[0] = PlayerPrefs.GetInt("hero1");
            hero[1] = PlayerPrefs.GetInt("hero2");
            hero[2] = PlayerPrefs.GetInt("hero3");
            items[0] = PlayerPrefs.GetInt("item1");
            items[1] = PlayerPrefs.GetInt("item2");
            items[2] = PlayerPrefs.GetInt("item3");
            items[3] = PlayerPrefs.GetInt("item4");

            if (isDone)
            {
                if (hero[0] != 0)
                {
                    isOlduser = true;
                    for (int i = 0; i < 3; i++)
                    {
                        hasHeroes.Add(heroes[hero[i]]);
                    }

                }
                else
                {
                    return;
                }

                if (items[0] != 0)
                {
                    isOlduser = true;
                    isItemHas = true;
                    for (int i = 0; i < 4; i++)
                    {
                        hasItems.Add(itemList[items[i]]);
                    }

                }
                else
                {
                    return;
                }



            }
        }
    }
    private void Update()
    {
        moneyTxt.text = "ÀÜ¾× : " + money.ToString() + "¿ø";
        if (money < 0)
        {
            money = 0;
        }
        
        if (PlayerPrefs.HasKey("hero1"))
        {
            isDone = true;
            hero[0] = PlayerPrefs.GetInt("hero1");
            hero[1] = PlayerPrefs.GetInt("hero2");
            hero[2] = PlayerPrefs.GetInt("hero3");
            items[0] = PlayerPrefs.GetInt("item1");
            items[1] = PlayerPrefs.GetInt("item2");
            items[2] = PlayerPrefs.GetInt("item3");
            items[3] = PlayerPrefs.GetInt("item4");
           
        }
    }

    public void ShopUpdate()
    {
            randomlist.Clear();

        for (int i = 0; i < 4;)
        {
            int rnd = Random.Range(0, 4);
            if (randomlist.Contains(rnd))
            {
                rnd = Random.Range(0, 4);
            }
            else
            {
                GameObject item = Instantiate(shopList[rnd]);
                item.transform.position = shop.transform.position;
                item.transform.SetParent(shop.transform);
                item.transform.localScale = new Vector3(1, 1, 1);
                randomlist.Add(rnd);
                i++;
            }

            
        }
    }

    public void LoadData()
    {

        if (isDone && isOlduser == true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (hero[i] != 0)
                {
                    GameObject heroes = Instantiate(hasHeroes[hero[i]]);
                    heroes.transform.position = pos[i].transform.position;
                    heroes.transform.SetParent(pos[i]);
                    heroes.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    continue;
                }
            }

        }

        if (isDone && isOlduser == true && isItemHas == true)
        {
            for (int i = 0; i < 4; i++)
            {
                if (items[i] != 0)
                {
                    GameObject item = Instantiate(hasItems[items[i]]);
                    item.transform.position = slots[i].transform.position;
                    item.transform.SetParent(slots[i].transform);
                    item.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    continue;
                }

            }


        }
        
    }
    public void buySword()
    {

            PlayerPrefs.SetInt("item1", 1);
            items[0] = 1;
            PlayerPrefs.Save();
            GameObject item = Instantiate(itemList[1]);

            item.transform.position = slots[0].transform.position;
            item.transform.SetParent(slots[0].transform);
            item.transform.localScale = new Vector3(1, 1, 1);
        

    }

    public void buyWood()
    {

            PlayerPrefs.SetInt("item2", 2);
            items[1] = 2;
            PlayerPrefs.Save();
            GameObject item2 = Instantiate(itemList[2]);

            item2.transform.position = slots[1].transform.position;
            item2.transform.SetParent(slots[1].transform);
            item2.transform.localScale = new Vector3(1, 1, 1);
        
    }

    public void buyBow()
    {

            PlayerPrefs.SetInt("item3", 3);
            items[2] = 3;
            PlayerPrefs.Save();
            GameObject item3 = Instantiate(itemList[3]);

            item3.transform.position = slots[2].transform.position;
            item3.transform.SetParent(slots[2].transform);
            item3.transform.localScale = new Vector3(1, 1, 1);

    }

    public void buyKnuckle()
    {

            PlayerPrefs.SetInt("item4", 4);
            items[3] = 4;
            PlayerPrefs.Save();
            GameObject item4 = Instantiate(itemList[4]);

            item4.transform.position = slots[3].transform.position;
            item4.transform.SetParent(slots[3].transform);
            item4.transform.localScale = new Vector3(1, 1, 1);
        
    }

    public void ResetHeroes()
    {
        PlayerPrefs.DeleteAll();

    }

}
