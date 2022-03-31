using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//==================================================================================================//
//무기, 장비 장착 및 해제 스크립트입니다. 03-28 윤성근
//==================================================================================================//
public class EquipScripts_ysg : MonoBehaviour 
{
    public Equip equip;
    public ItemUseManager itemUseManager;
    public ShopManager itemData;
    public EquipTable equipTable = new EquipTable();
    public SmithManager smithManager;
    public Song.UI_DungeonSelect_Manager dgSelectMgr;
    public UI_Tweening_Manager twMgr;

    public int equipIndex;
    public int sell = 0;

    public bool isEquip = false; // 현재 무기or장비가 장착 되었는지 확인 하는 bool 값입니다.
    public bool isSmith = false;
    public bool isSelled = false;

    public Button equipBtn;
    public Transform smithSlot;

   
    

    void Start()
    {

        itemUseManager = GameObject.Find("ShopManager").GetComponent<ItemUseManager>();
        smithManager = GameObject.Find("SmithManager").GetComponent<SmithManager>();
        smithSlot = smithManager.smithSlot;
        itemData = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        equipBtn = gameObject.transform.GetChild(1).GetComponent<Button>();
        dgSelectMgr = GameObject.Find("DungeonSelectManager").GetComponent<Song.UI_DungeonSelect_Manager>();
        twMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
        itemData.hasEquipList.Add(gameObject);


        switch (gameObject.name) //현재 게임오브젝트의 이름에 맞는 함수를 출력합니다.
        {
            case "Sword(Clone)":
                equipIndex = 0;
                EquipParamInit();

                break;

            case "Shield(Clone)":
                equipIndex = 1;
                EquipParamInit();

                break;
            default:
                break;
        }
    }
    public void EquipParamInit() //EquipTable에 있는 정보를 가져옵니다. 정보는 equipIndex에 있는 Index를 기반으로 가져옵니다.
    {
        gameObject.name = equip.Name;
        equip.Cost = equipTable.initEquip[equipIndex].Cost;
    }

    public void Equip() // 장비를 장착 or 해제 했을때 호출되는 함수입니다. 
    {
        if (!isEquip)
        {

            switch (equip.Index)
            {
                case 0:
                    EquipWeapon();

                    break;
                case 1:
                    EquipArmor();
                    break;
                default:
                    break;
            }
        }
        else if (isEquip)
        {

            switch (equip.Index)
            {
                case 0:
                    UnEquipWeapon();
                    break;

                case 1:
                    UnEquipArmor();
                    break;
                default:
                    break;
            }
        }
        else if (isSmith)
        {
            switch (equip.Index)
            {
                case 0:
                    UpgradeEquips();
                    break;
                case 1:
                    UpgradeEquips();
                    break;
                default:
                    break;
            }
        }




    }

    public void EquipSell()
    {

        if (itemData.isShop && twMgr.isShopOn)
        {
            equipBtn.gameObject.SetActive(false);
            sell++;

            if (sell == 2)
            {
                isSelled = true;
                itemData.money += equip.Cost;
                for (int i = itemData.hasEquipList.Count - 1; i >= 0; i--) //아이템 사용 후 리스트에 있는 오브젝트 삭제 시 중복으로 삭제되는걸 방지 하기 위해 넣음 03-30 윤성근
                {
                    if (itemData.hasEquipList[i].GetComponent<EquipScripts_ysg>().isSelled)
                    {
                        itemData.hasEquipList.RemoveAt(i);
                    }
                }
                equipBtn.gameObject.SetActive(false);
                Destroy(gameObject);

            }

        }
        else
        {
            SellCancel();
        }


    }
    public void EquipWeapon() // 무기 착용 시 실행되는 함수입니다.
    {
        if (itemUseManager.isActive) // 영웅이 선택 되었다면 실행합니다.
        {
            isEquip = true;
            itemUseManager.isActive = false;
            itemUseManager.equips[0].Index = equip.Index;
            itemUseManager.equips[0].Name = equip.Name;
            itemUseManager.equips[0].Lv = equip.Lv;
            itemUseManager.equips[0].Atk += equip.Atk;
            itemUseManager.equips[0].Def += equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "해제";
            equipBtn.gameObject.SetActive(false);

        }
    }
    public void EquipArmor() // 장비 착용 시 실행되는 함수입니다.
    {
        if (itemUseManager.isActive)
        {
            isEquip = true;
            itemUseManager.isActive = false;
            itemUseManager.equips[1].Index = equip.Index;
            itemUseManager.equips[1].Name = equip.Name;
            itemUseManager.equips[1].Lv = equip.Lv;
            itemUseManager.equips[1].Atk += equip.Atk;
            itemUseManager.equips[1].Def += equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "해제";
            equipBtn.gameObject.SetActive(false);

        }
    }

    public void UnEquipWeapon() //무기 해제 함수입니다.
    {
        if (isEquip && itemUseManager.isActive)
        {
            isEquip = false;
            itemUseManager.isActive = false;
            itemUseManager.equips[0].Index = -1;
            itemUseManager.equips[0].Name = null;
            itemUseManager.equips[0].Lv = -1;
            itemUseManager.equips[0].Atk -= equip.Atk;
            itemUseManager.equips[0].Def -= equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "장착";
            equipBtn.gameObject.SetActive(false);

        }
    }

    public void UnEquipArmor() // 장비 해제 함수입니다.
    {
        if (isEquip && itemUseManager.isActive)
        {
            isEquip = false;
            itemUseManager.isActive = false;
            itemUseManager.equips[1].Index = -1;
            itemUseManager.equips[1].Name = null;
            itemUseManager.equips[1].Lv = -1;
            itemUseManager.equips[1].Atk -= equip.Atk;
            itemUseManager.equips[1].Def -= equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "장착";
            equipBtn.gameObject.SetActive(false);

        }
    }

    public void UpgradeEquips() // 무기, 장비 강화 함수입니다.
    {
        if (!smithManager.isSlotFull && smithManager.isActive)
        {
                smithManager.isSlotFull = true;
                smithManager.equip.Index = equip.Index;
                smithManager.equip.Name = equip.Name;
                smithManager.equip.Lv = equip.Lv;
                smithManager.equip.Atk = equip.Atk;
                smithManager.equip.Def = equip.Def;

                gameObject.transform.SetParent(smithSlot);
                gameObject.transform.localPosition = smithSlot.localPosition;
                gameObject.transform.localScale = smithSlot.localScale;

                equipBtn.gameObject.SetActive(false);
            
        }


    }


    public void SellCancel()
    {
        sell = 0;
        isSelled = false;
    }

    public void ShowBtnOnlyDungeon()
    {
        if (dgSelectMgr.isDungeonSelect)
        {
            if (!equipBtn)
            {
                equipBtn.gameObject.SetActive(true);
            }
            else
            {
                equipBtn.gameObject.SetActive(false);
            }
        }

    }



}
