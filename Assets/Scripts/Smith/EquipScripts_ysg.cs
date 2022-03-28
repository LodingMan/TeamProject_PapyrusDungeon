using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//==================================================================================================//
//����, ��� ���� �� ���� ��ũ��Ʈ�Դϴ�. 03-28 ������
//==================================================================================================//
public class EquipScripts_ysg : MonoBehaviour 
{
    public Equip equip;
    public ItemUseManager itemUseManager;
    public EquipTable equipTable = new EquipTable();
    public int equipIndex;
    public bool isEquip = false; // ���� ����or��� ���� �Ǿ����� Ȯ�� �ϴ� bool ���Դϴ�.
    public Button equipBtn;

    void Start()
    {
        itemUseManager = GameObject.Find("ShopManager").GetComponent<ItemUseManager>();
        equipBtn = gameObject.transform.GetChild(1).GetComponent<Button>();

        switch (gameObject.name) //���� ���ӿ�����Ʈ�� �̸��� �´� �Լ��� ����մϴ�.
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
    public void EquipParamInit() //EquipTable�� �ִ� ������ �����ɴϴ�. ������ equipIndex�� �ִ� Index�� ������� �����ɴϴ�.
    {
        equip.Index = equipTable.initEquip[equipIndex].Index;
        equip.Name = equipTable.initEquip[equipIndex].Name;
        equip.Atk = equipTable.initEquip[equipIndex].Atk;
        equip.Def = equipTable.initEquip[equipIndex].Def;
        gameObject.name = equip.Name;
    }

    public void Equip() // ��� ���� or ���� ������ ȣ��Ǵ� �Լ��Դϴ�. 
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
        if (itemUseManager.isActive) // ������ ���� �Ǿ��ٸ� �����մϴ�.
        {
            isEquip = true;
            itemUseManager.isActive = false;
            itemUseManager.equips[0].Index = equip.Index;
            itemUseManager.equips[0].Name = equip.Name;
            itemUseManager.equips[0].Atk += equip.Atk;
            itemUseManager.equips[0].Def += equip.Def;
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
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
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
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
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
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
            equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
            equipBtn.gameObject.SetActive(false);

        }
    }



}
