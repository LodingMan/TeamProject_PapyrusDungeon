using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemScript : MonoBehaviour
{
    public ItemManager iData;
    public int itemIDX;
    public string ItemName;
    public int dmg;
    public int def;
    public GameObject inventory;
    public Transform shopSlot;
    public Button BuyBtn;
    public Text BtnTxt;

    public bool isBought = false;
    public bool isSell = false;


    private void Start()
    {
        iData = GameObject.Find("GameMgr").GetComponent<ItemManager>();
        BuyBtn = gameObject.transform.GetChild(0).GetComponent<Button>();
        BtnTxt = BuyBtn.transform.GetChild(0).GetComponent<Text>();
        shopSlot = iData.ShopSlot.GetComponent<Transform>();
        string item = gameObject.tag;
        inventory = iData.inventory;
        ItemName = item;
        ItemCheck();
        IsBoughtCheck();

    }

    public void ItemCheck()
    {

        switch (ItemName)
        {
            case "Sword_S":
                if (ItemName == "Sword_S")
                {
                    int i = 0;
                    itemIDX = i;
                    dmg = iData.itemData[i].dmg;
                    def = iData.itemData[i].def;
                }
                break;

            case "Stick_S":
                if (ItemName == "Stick_S")
                {
                    int i = 1;
                    itemIDX = i;
                    dmg = iData.itemData[i].dmg;
                    def = iData.itemData[i].def;
                }
                break;

            case "Kukri_S":
                if (ItemName == "Kukri_S")
                {
                    int i = 2;
                    itemIDX = i;
                    dmg = iData.itemData[i].dmg;
                    def = iData.itemData[i].def;
                }
                break;

            case "Wood_Shield_S":
                if (ItemName == "Wood_Shield_S")
                {
                    int i = 3;
                    itemIDX = i;
                    dmg = iData.itemData[i].dmg;
                    def = iData.itemData[i].def;
                }
                break;

            case "Silver_Shield_S":
                if (ItemName == "Silver_Shield_S")
                {
                    int i = 4;
                    itemIDX = i;
                    dmg = iData.itemData[i].dmg;
                    def = iData.itemData[i].def;
                }
                break;

            case "Gold_Shield_S":
                if (ItemName == "Gold_Shield_S")
                {
                    int i = 5;
                    itemIDX = i;
                    dmg = iData.itemData[i].dmg;
                    def = iData.itemData[i].def;
                }
                break;
        }
    }
    public void IsBoughtCheck()
    {
        if (!isBought)
        {
            if (BuyBtn.onClick != null)
            {
                BuyBtn.onClick.RemoveAllListeners();
            }
            BuyBtn.onClick.AddListener(BuyItem);
            BtnTxt.text = "구매";
        }
        else
        {
            if (BuyBtn.onClick != null)
            {
                BuyBtn.onClick.RemoveAllListeners();
            }
            isSell = true;
            BuyBtn.onClick.AddListener(SellItem);
            BtnTxt.text = "판매";

        }
    }
    public void BuyItem()
    {
        if (!isBought)
        {
            switch (itemIDX)
            {
                case 0:
                    if (itemIDX == 0)
                    {
                        ItemMethod();
                    }
                    break;
                case 1:
                    if (itemIDX == 1)
                    {
                        ItemMethod();

                    }
                    break;
                case 2:
                    if (itemIDX == 2)
                    {
                        ItemMethod();

                    }
                    break;
                case 3:
                    if (itemIDX == 3)
                    {
                        ItemMethod();

                    }
                    break;
                case 4:
                    if (itemIDX == 4)
                    {
                        ItemMethod();

                    }
                    break;
                case 5:
                    if (itemIDX == 5)
                    {
                        ItemMethod();

                    }
                    break;
                default:
                    break;
            }
        }

        
    }

    public void SellItem()
    {
        if (isSell)
        {
            switch (itemIDX)
            {
                case 0:
                    if (itemIDX == 0)
                    {
                        Debug.Log("판매");
                        Destroy(gameObject);

                    }
                    break;
                case 1:
                    if (itemIDX == 1)
                    {

                    }
                    break;
                case 2:
                    if (itemIDX == 2)
                    {

                    }
                    break;
                case 3:
                    if (itemIDX == 3)
                    {

                    }
                    break;
                case 4:
                    if (itemIDX == 4)
                    {

                    }
                    break;
                case 5:
                    if (itemIDX == 5)
                    {

                    }
                    break;
                default:
                    break;
            }

        }
    }

    public void ItemMethod()
    {
        isBought = true;
        gameObject.transform.SetParent(shopSlot.transform);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        IsBoughtCheck();
        GameObject itemPf = Instantiate(iData.itemPrefabs[itemIDX]);
        itemPf.gameObject.GetComponent<ShopItemScript>().isSell = true;
        itemPf.transform.SetParent(inventory.transform);
        itemPf.transform.localPosition = inventory.transform.localPosition;
        itemPf.transform.localScale = inventory.transform.localScale;
        itemPf.transform.GetChild(0).gameObject.SetActive(false);
    }
 

}
 
