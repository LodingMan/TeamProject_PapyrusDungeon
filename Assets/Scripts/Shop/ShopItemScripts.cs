using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//==================================================================================================//
// ������ ��Ÿ���� ������ ��ũ��Ʈ�Դϴ�. 03-28 ������
//==================================================================================================//

public class ShopItemScripts : MonoBehaviour
{
    public ItemTable itemTable = new ItemTable();
    public List<GameObject> hasItemList;

    public ShopManager shopManager;
    public GameObject inventory;
    public int itemIdx;
    public Button BuyBtn;
    public GameObject selectImg;
    public bool isSelect = false;
    public GameObject shopPanel;


    public void Start() //������ ������ �ʿ��� ������ �������� �ڵ��Դϴ�.
    {
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        shopPanel = shopManager.shopPanel;
        inventory = shopManager.inventory;
        hasItemList = shopManager.hasItemList;
        BuyBtn = shopManager.BuyBtn;


        ItemCheck();
    }



    public void ItemCheck() // �����Ǵ� �������� �̸��� ���� ���ָ�, itemIdx�� ���� �������� �ε��� ��ȣ�� �����մϴ�.
    {
        switch (gameObject.name)
        {
            case "HP_POTION_SHOP":
                itemIdx = itemTable.Item_Dictionary[0].Index;
                gameObject.name = itemTable.Item_Dictionary[0].Name + "_Shop"; //_Shop �� �ٴ� ������Ʈ�� ������ ��Ÿ���� ������Ʈ�Դϴ�.
                break;

            case "MP_POTION_SHOP":
                itemIdx = itemTable.Item_Dictionary[1].Index;
                gameObject.name = itemTable.Item_Dictionary[1].Name + "_Shop";
                break;
            default:
                break;
        }
    }

    public void BuyItem()
    {
        switch (itemIdx) // ������ �ε��� ��ȣ�� �°� �������� �����ϴ� �Լ��� ȣ���մϴ�.
        {
            case 0:
                ItemInstantiate();

                break;
            case 1:
                ItemInstantiate();
                break;

            default:
                break;
        }
    }

    public void BuyBtnConnect()
    {
        if (BuyBtn != null)
        {
            BuyBtn.onClick.RemoveAllListeners();
        }
        BuyBtn.onClick.AddListener(BuyItem);
    }




    public void ItemInstantiate() //������ ���� �� �κ��丮�� �������� �����մϴ�.
    {                                       // ������ ���� �� �κ��丮 ����� �°� ���� �����ϰ� ���� �Ͽ����ϴ�. 03-28 ������
        if (hasItemList.Count < 10)
        {
            GameObject buyItem = Instantiate(shopManager.itemList[itemIdx]);
            hasItemList.Add(buyItem);
            buyItem.transform.SetParent(inventory.transform);
            buyItem.transform.localPosition = inventory.transform.localPosition;
            buyItem.transform.localScale = new Vector3(1, 1, 1);
            shopManager.ItemSave();
        }
        else
        {
            Debug.Log("�κ��丮�� �� á���ϴ�.");
        }
    }

    public void SelectImage()
    {
        if (!isSelect)
        {
            for (int i = 0; i < shopPanel.transform.childCount; i++)
            {
                if (shopPanel.transform.GetChild(i).tag == "Item")
                {
                    shopPanel.transform.GetChild(i).GetComponent<ShopItemScripts>().isSelect = false;
                    shopPanel.transform.GetChild(i).GetComponent<ShopItemScripts>().selectImg.SetActive(false);
                }
                else if(shopPanel.transform.GetChild(i).tag == "Equip")
                {
                    shopPanel.transform.GetChild(i).GetComponent<ShopEquipScripts>().isSelect = false;
                    shopPanel.transform.GetChild(i).GetComponent<ShopEquipScripts>().selectImg.SetActive(false);
                }
            }
            isSelect = true;
            selectImg.SetActive(true);
        }
        else
        {
            isSelect = false;
            selectImg.SetActive(false);
            BuyBtn.onClick.RemoveAllListeners();

        }


    }
}
