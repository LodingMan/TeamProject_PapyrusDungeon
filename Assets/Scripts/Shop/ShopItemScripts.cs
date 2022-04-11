using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//==================================================================================================//
// 상점에 나타나는 아이템 스크립트입니다. 03-28 윤성근
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


    public void Start() //아이템 생성시 필요한 정보를 가져오는 코드입니다.
    {
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        shopPanel = shopManager.shopPanel;
        inventory = shopManager.inventory;
        hasItemList = shopManager.hasItemList;
        BuyBtn = shopManager.BuyBtn;


        ItemCheck();
    }



    public void ItemCheck() // 생성되는 아이템의 이름을 변경 해주며, itemIdx에 현재 아이템의 인덱스 번호를 대입합니다.
    {
        switch (gameObject.name)
        {
            case "HP_POTION_SHOP":
                itemIdx = itemTable.Item_Dictionary[0].Index;
                gameObject.name = itemTable.Item_Dictionary[0].Name + "_Shop"; //_Shop 이 붙는 오브젝트는 상점에 나타나는 오브젝트입니다.
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
        switch (itemIdx) // 대입한 인덱스 번호에 맞게 프리팹을 생성하는 함수를 호출합니다.
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




    public void ItemInstantiate() //아이템 구매 시 인벤토리에 프리팹을 생성합니다.
    {                                       // 아이템 구매 시 인벤토리 사이즈에 맞게 구매 가능하게 변경 하였습니다. 03-28 윤성근
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
            Debug.Log("인벤토리가 다 찼습니다.");
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
