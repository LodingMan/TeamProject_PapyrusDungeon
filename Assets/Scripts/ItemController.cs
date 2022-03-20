using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public int itemRank = 1;
    public int atkDmg = 10;
    public Text rankTxt;
    public GameMgr mgr;

    private void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        if (this.gameObject.tag == "Sword")
        {
            if (PlayerPrefs.HasKey("rank1"))
            {
                itemRank = PlayerPrefs.GetInt("rank1");
                rankTxt.text = itemRank.ToString();
            }
        }
        else if(this.gameObject.tag == "Wood")
        {
            if (PlayerPrefs.HasKey("rank2"))
            {
                itemRank = PlayerPrefs.GetInt("rank2");
                rankTxt.text = itemRank.ToString();
            }
        }



    }

    public void Equip()
    {
        if (this.gameObject.tag == "Sword")
        {
            GameObject knight = GameObject.FindWithTag("Knight");
            int atkconst = knight.GetComponent<HeroesStats>().atk;
            knight.GetComponent<HeroesStats>().atk += atkDmg + (itemRank * 2);
        }
        else if(this.gameObject.tag == "Wood")
        {
            GameObject Mage = GameObject.FindWithTag("Mage");
            int atkconst = Mage.GetComponent<HeroesStats>().atk;
            Mage.GetComponent<HeroesStats>().atk += atkDmg + (itemRank * 2);
        }

    }
    public void Drop()
    {
        if (this.gameObject.tag == "Sword")
        {
            GameObject knight = GameObject.FindWithTag("Knight");
            knight.GetComponent<HeroesStats>().atk -= atkDmg + (itemRank * 2);
        }
        else if(this.gameObject.tag == "Wood")
        {
            GameObject mage = GameObject.FindWithTag("Mage");
            mage.GetComponent<HeroesStats>().atk -= atkDmg + (itemRank * 2);
        }

    }

    public void itemRankUp()
    {
        if (this.gameObject.tag == "Sword")
        {
            int rnd = Random.Range(0, 100);
            if (mgr.money > 100)
            {
                if (rnd < 50)
                {

                    mgr.money -= 100;
                    itemRank++;
                    rankTxt.text = itemRank.ToString();
                    PlayerPrefs.SetInt("rank1", itemRank);
                    PlayerPrefs.SetInt("money", mgr.money);
                    Debug.Log(rnd + "::강화 성공");
                }
                else
                {
                    mgr.money -= 100;
                    itemRank = 1;
                    rankTxt.text = itemRank.ToString();
                    PlayerPrefs.SetInt("rank1", itemRank);
                    PlayerPrefs.SetInt("money", mgr.money);
                    Debug.Log(rnd + "::강화 실패");
                }

            }
            else
            {

                Debug.Log("돈 부족");
            }
        }
        else if (this.gameObject.tag == "Wood")
        {
            int rnd = Random.Range(0, 100);
            if (mgr.money > 200)
            {
                if (rnd < 50)
                {

                    mgr.money -= 200;
                    itemRank++;
                    rankTxt.text = itemRank.ToString();
                    PlayerPrefs.SetInt("rank2", itemRank);
                    PlayerPrefs.SetInt("money", mgr.money);
                    Debug.Log(rnd + "::강화 성공");
                }
                else
                {
                    mgr.money -= 200;
                    itemRank = 1;
                    rankTxt.text = itemRank.ToString();
                    PlayerPrefs.SetInt("rank2", itemRank);
                    PlayerPrefs.SetInt("money", mgr.money);
                    Debug.Log(rnd + "::강화 실패");
                }

            }
            else
            {

                Debug.Log("돈 부족");
            }

        }
    }
}
