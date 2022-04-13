using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEquipScripts : MonoBehaviour
{
    public EquipTable equipTable = new EquipTable();
    public List<GameObject> hasEquipList;

    public ShopManager shopManager;
    public GameObject inventory;
    public int equipIdx;
    public Button BuyBtn;
    public bool isSelect = false;
    public GameObject selectImg;
    public GameObject shopPanel;
    public void Start() //아이템 생성시 필요한 정보를 가져오는 코드입니다.
    {
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        shopPanel = shopManager.shopPanel;
        inventory = shopManager.inventory;
        hasEquipList = shopManager.hasEquipList;
        BuyBtn = shopManager.BuyBtn;


        equipCheck();
    }

    public void equipCheck()
    {
        switch (gameObject.name)
        {
            case "SWORD_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[1].Index;
                gameObject.name = equipTable.initEquip[1].Name + "_Shop";
                break;

            case "AXE_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[2].Index;
                gameObject.name = equipTable.initEquip[2].Name + "_Shop";
                break;
            case "BOW_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[3].Index;
                gameObject.name = equipTable.initEquip[3].Name + "_Shop";
                break;
            case "KNIFE_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[4].Index;
                gameObject.name = equipTable.initEquip[4].Name + "_Shop";
                break;
            case "DOUBLEAXE_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[5].Index;
                gameObject.name = equipTable.initEquip[5].Name + "_Shop";
                break;
            case "SABER_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[6].Index;
                gameObject.name = equipTable.initEquip[6].Name + "_Shop";
                break;
            case "WAND_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[7].Index;
                gameObject.name = equipTable.initEquip[7].Name + "_Shop";
                break;
            case "ARMOR1_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[11].Index;
                gameObject.name = equipTable.initEquip[11].Name + "_Shop";
                break;
            case "ARMOR2_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[12].Index;
                gameObject.name = equipTable.initEquip[12].Name + "_Shop";
                break;
            case "BOOT1_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[13].Index;
                gameObject.name = equipTable.initEquip[13].Name + "_Shop";
                break;
            case "BOOT2_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[14].Index;
                gameObject.name = equipTable.initEquip[14].Name + "_Shop";
                break;
            case "BOOT3_EQUIP(Clone)":
                equipIdx = equipTable.initEquip[15].Index;
                gameObject.name = equipTable.initEquip[15].Name + "_Shop";
                break;
            default:
                break;
        }
    }

    public void BuyEquip()
    {
        switch (equipIdx)
        {
            case 1:
                EquipInstantiate();

                break;
            case 2:
                EquipInstantiate();
                break;
            case 3:
                EquipInstantiate();

                break;
            case 4:
                EquipInstantiate();
                break;
            case 5:
                EquipInstantiate();

                break;
            case 6:
                EquipInstantiate();
                break;
            case 7:
                EquipInstantiate();

                break;
            case 11:
                EquipInstantiate();
                break;
            case 12:
                EquipInstantiate();
                break;
            case 13:
                EquipInstantiate();
                break;
            case 14:
                EquipInstantiate();
                break;
            case 15:
                EquipInstantiate();
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
        BuyBtn.onClick.AddListener(BuyEquip);
    }

    public void EquipInstantiate()
    {
        if (shopManager.money > equipTable.initEquip[equipIdx].Cost)
        {
            shopManager.money -= equipTable.initEquip[equipIdx].Cost;
            shopManager.GoldRefresh();
            GameObject buyEquip = Instantiate(shopManager.equipList[equipIdx]);
            buyEquip.transform.SetParent(inventory.transform);
            buyEquip.transform.localPosition = inventory.transform.localPosition;
            buyEquip.transform.localScale = new Vector3(1, 1, 1);
            hasEquipList.Add(buyEquip);
            shopManager.ItemSave();
            Destroy(gameObject);
        }
        else if(shopManager.money < equipTable.initEquip[equipIdx].Cost)
        {
            shopManager.NotEnoughMoney();
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
                else if (shopPanel.transform.GetChild(i).tag == "Equip")
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
