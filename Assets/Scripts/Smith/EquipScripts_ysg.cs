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
    public EquipTable equipTable = new EquipTable();
    public int equipIndex;
    public bool isEquip = false; // 현재 무기or장비가 장착 되었는지 확인 하는 bool 값입니다.
    public Button equipBtn;

    void Start()
    {
        itemUseManager = GameObject.Find("ShopManager").GetComponent<ItemUseManager>();
        equipBtn = gameObject.transform.GetChild(1).GetComponent<Button>();

        switch (gameObject.name) //현재 게임오브젝트의 이름에 맞는 함수를 출력합니다.
        {
            case "Sword":
                equipIndex = 0;
                EquipParamInit();

                break;

            case "Shield":
                equipIndex = 1;
                EquipParamInit();

                break;
            default:
                break;
        }
    }
    public void EquipParamInit() //EquipTable에 있는 정보를 가져옵니다. 정보는 equipIndex에 있는 Index를 기반으로 가져옵니다.
    {
        equip.Index = equipTable.initEquip[equipIndex].Index;
        equip.Name = equipTable.initEquip[equipIndex].Name;
        equip.Atk = equipTable.initEquip[equipIndex].Atk;
        equip.Def = equipTable.initEquip[equipIndex].Def;
        gameObject.name = equip.Name;
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
        else
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



    }


    public void EquipWeapon()
    {
        if (itemUseManager.isActive) // 영웅이 선택 되었다면 실행합니다.
        {
            isEquip = true;
            itemUseManager.isActive = false;
            itemUseManager.equips[0].Index = equip.Index;
            itemUseManager.equips[0].Name = equip.Name;
            itemUseManager.equips[0].Atk += equip.Atk;
            itemUseManager.equips[0].Def += equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "해제";
            equipBtn.gameObject.SetActive(false);

        }
    }
    public void EquipArmor()
    {
        if (itemUseManager.isActive)
        {
            isEquip = true;
            itemUseManager.isActive = false;
            itemUseManager.equips[1].Index = equip.Index;
            itemUseManager.equips[1].Name = equip.Name;
            itemUseManager.equips[1].Atk += equip.Atk;
            itemUseManager.equips[1].Def += equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "해제";
            equipBtn.gameObject.SetActive(false);

        }
    }

    public void UnEquipWeapon()
    {
        if (isEquip && itemUseManager.isActive)
        {
            isEquip = false;
            itemUseManager.isActive = false;
            itemUseManager.equips[0].Index = -1;
            itemUseManager.equips[0].Name = null;
            itemUseManager.equips[0].Atk -= equip.Atk;
            itemUseManager.equips[0].Def -= equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "장착";
            equipBtn.gameObject.SetActive(false);

        }
    }

    public void UnEquipArmor()
    {
        if (isEquip && itemUseManager.isActive)
        {
            isEquip = false;
            itemUseManager.isActive = false;
            itemUseManager.equips[1].Index = -1;
            itemUseManager.equips[1].Name = null;
            itemUseManager.equips[1].Atk -= equip.Atk;
            itemUseManager.equips[1].Def -= equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "장착";
            equipBtn.gameObject.SetActive(false);

        }
    }



}
