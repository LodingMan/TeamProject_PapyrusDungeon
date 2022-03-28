using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScripts_ysg : MonoBehaviour
{
    public Equip equip;
    public ItemUseManager itemUseManager;
    public EquipTable equipTable = new EquipTable();
    public int equipIndex;
    public bool isEquip = false;

    void Start()
    {
        itemUseManager = GameObject.Find("UIManager").GetComponent<ItemUseManager>();

        switch (gameObject.name)
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
    public void EquipParamInit() //itemTable에 있는 정보를 가져옵니다. 정보는 itemIndex에 있는 Index를 기반으로 가져옵니다.
    {
        equip.Index = equipTable.initEquip[equipIndex].Index;
        equip.Name = equipTable.initEquip[equipIndex].Name;
        equip.Atk = equipTable.initEquip[equipIndex].Atk;
        equip.Def = equipTable.initEquip[equipIndex].Def;
        gameObject.name = equip.Name;
    }

    public void Equip()
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

    }


    public void EquipWeapon()
    {
        if (itemUseManager.isActive)
        {
            itemUseManager.equips[0].Index = equip.Index;
            itemUseManager.equips[0].Name = equip.Name;
            itemUseManager.equips[0].Atk += equip.Atk;
            itemUseManager.equips[0].Def += equip.Def;
        }
    }
    public void EquipArmor()
    {
        if (itemUseManager.isActive)
        {
            itemUseManager.equips[1].Index = equip.Index;
            itemUseManager.equips[1].Name = equip.Name;
            itemUseManager.equips[1].Atk += equip.Atk;
            itemUseManager.equips[1].Def += equip.Def;
        }
    }



}
