using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//==================================================================================================//
//�κ��丮 �����ۿ� �޸��� ��ũ��Ʈ�Դϴ�. 03-28 ������
//������ ��� ������ �� �̺�Ʈ�� �����մϴ�.
//==================================================================================================//

public class ItemScripts : MonoBehaviour 
{                                        
    public Item item;
    public Equip equip;
    public ItemUseManager itemUseManager;
    public ShopManager shopManager;
    public ItemTable itemTable = new ItemTable();
    public Button useBtn;
    public Song.UI_DungeonSelect_Manager dgMgr;
    public UI_Tweening_Manager twMgr;
    public int itemIndex; // ������Ʈ�� �����ϱ� ���� ���� �����Դϴ�.
    public bool isUsed = false;
    public bool isDungeon = false;

    public int sell = 0;



    private void Start()
    {
        itemUseManager = GameObject.Find("ShopManager").GetComponent<ItemUseManager>();
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        dgMgr = GameObject.Find("DungeonSelectManager").GetComponent<Song.UI_DungeonSelect_Manager>();
        useBtn = gameObject.transform.GetChild(1).GetComponent<Button>();
        twMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();


        switch (gameObject.name) // ���� ������Ʈ�� �̸��� ã�Ƽ� �׿� �´� ������ �������� �Լ��� �����մϴ�.
        {
            case "HP_POTION(Clone)":
                itemIndex = 0;
                ItemParamInit();

                break;

            case "MP_POTION(Clone)":
                itemIndex = 1;
                ItemParamInit();

                break;


            default:
                break;
        }
        if (!shopManager.isShop)
        {
            useBtn.transform.GetChild(0).GetComponent<Text>().text = "���";
        }
        else if(shopManager.isShop)
        {
            useBtn.transform.GetChild(0).GetComponent<Text>().text = "�Ǹ�";
        }


    }

    public void TextChange()
    {
        if (!shopManager.isShop)
        {
            useBtn.transform.GetChild(0).GetComponent<Text>().text = "���";
        }
        else if(shopManager.isShop)
        {
            useBtn.transform.GetChild(0).GetComponent<Text>().text = "�Ǹ�";
        }


    }
    public void ItemParamInit() //itemTable�� �ִ� ������ �����ɴϴ�. ������ itemIndex�� �ִ� Index�� ������� �����ɴϴ�.
    {
        item.Index = itemTable.Item_Dictionary[itemIndex].Index;
        item.Name = itemTable.Item_Dictionary[itemIndex].Name;
        item.Pram = itemTable.Item_Dictionary[itemIndex].Pram;
        item.cost = itemTable.Item_Dictionary[itemIndex].cost;
        item.TargetStatus = itemTable.Item_Dictionary[itemIndex].TargetStatus;
        gameObject.name = item.Name;
    }

    public void UseItem() // ������ ��� �� UIManager�� �ִ� ������ �����մϴ�.
    {
        if (!shopManager.isShop)
        {
            switch (item.TargetStatus)
            {
                case "HP":
                    if (itemUseManager.isActive) // ������Ʈ�� ���õǾ���� ������ �����ϰ� ��������ϴ�.
                    {
                        isUsed = true; // ������ ��� ���� üũ
                        itemUseManager.stats.HP += item.Pram; // ���õ� ������Ʈ�� HP���� ���� �����ݴϴ�. �������� itemTable�� �ִ� ��ġ�� ������� �մϴ�.
                        itemUseManager.isActive = false; // �ߺ� Ŭ�� ������ ���� �־����ϴ�.
                        itemUseManager.stats = null; // ������ ��� �� ������ �����͸� �����մϴ�.
                        for (int i = shopManager.hasItemList.Count - 1; i >= 0; i--) //������ ��� �� ����Ʈ�� �ִ� ������Ʈ ���� �� �ߺ����� �����Ǵ°� ���� �ϱ� ���� ���� 03-28 ������
                        {
                            if (shopManager.hasItemList[i].GetComponent<ItemScripts>().isUsed)
                            {
                                shopManager.hasItemList.RemoveAt(i);
                            }
                        }
                        Destroy(gameObject);

                    }

                    break;
                case "MP":
                    if (itemUseManager.isActive)
                    {
                        isUsed = true;
                        itemUseManager.stats.MP += item.Pram;
                        itemUseManager.isActive = false;
                        itemUseManager.stats = null;
                        for (int i = shopManager.hasItemList.Count - 1; i >= 0; i--)
                        {
                            if (shopManager.hasItemList[i].GetComponent<ItemScripts>().isUsed)
                            {
                                shopManager.hasItemList.RemoveAt(i);
                            }
                        }
                        Destroy(gameObject);

                    }

                    break;
                default:
                    break;
            }
        }
        //else
        //{
        //    switch (item.TargetStatus)
        //    {
        //        case "HP":
        //                isUsed = true;
                    
        //                itemUseManager.isActive = false;
        //                itemUseManager.stats = null;
        //                shopManager.money += item.cost;
        //            for (int i = shopManager.hasItemList.Count - 1; i >= 0; i--) //������ ��� �� ����Ʈ�� �ִ� ������Ʈ ���� �� �ߺ����� �����Ǵ°� ���� �ϱ� ���� ���� 03-28 ������
        //                {
        //                    if (shopManager.hasItemList[i].GetComponent<ItemScripts>().isUsed)
        //                    {
        //                        shopManager.hasItemList.RemoveAt(i);
        //                    }
        //                }
        //                Destroy(gameObject);
        //            break;
        //        case "MP":
        //             isUsed = true;
        //            itemUseManager.isActive = false;
        //            itemUseManager.stats = null;
        //            shopManager.money += item.cost;
        //            for (int i = shopManager.hasItemList.Count - 1; i >= 0; i--)
        //                {
        //                    if (shopManager.hasItemList[i].GetComponent<ItemScripts>().isUsed)
        //                    {
        //                        shopManager.hasItemList.RemoveAt(i);
        //                    }
        //                }
        //                Destroy(gameObject);


        //            break;
        //        default:
        //            break;
        //    }
        //}


    }

    public void ItemSell()
    {
        if (shopManager.isShop && twMgr.isShopOn)
        {
            useBtn.gameObject.SetActive(false);
            sell++;

            if (sell == 2)
            {
                isUsed = true;
                shopManager.money += item.cost;
                for (int i = shopManager.hasItemList.Count - 1; i >= 0; i--) //������ ��� �� ����Ʈ�� �ִ� ������Ʈ ���� �� �ߺ����� �����Ǵ°� ���� �ϱ� ���� ���� 03-28 ������
                {
                    if (shopManager.hasItemList[i].GetComponent<ItemScripts>().isUsed)
                    {
                        shopManager.hasItemList.RemoveAt(i);
                    }
                }
                useBtn.gameObject.SetActive(false);
                Debug.Log("�Ǹ� �Ϸ�");
                Destroy(gameObject);

            }

        }
        else
        {
            SellCancel();
        }
    }


    public void SellCancel()
    {
        sell = 0;
        isUsed = false;
    }

    public void ShowBtnOnlyDungeon()
    {
        if (dgMgr.isDungeonSelect && itemUseManager.isActive)
        {
            if (!isDungeon)
            {
                isDungeon = true;
                useBtn.gameObject.SetActive(true);
            }
            else
            {
                isDungeon = false;
                useBtn.gameObject.SetActive(false);
            }
        }

    }

}
