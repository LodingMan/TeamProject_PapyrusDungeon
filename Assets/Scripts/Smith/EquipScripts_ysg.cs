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
    public ShopManager itemData;
    public EquipTable equipTable = new EquipTable();
    public SmithManager smithManager;
    public Song.UI_DungeonSelect_Manager dgSelectMgr;
    public UI_Tweening_Manager twMgr;

    public int equipIndex;
    public int sell = 0;

    public bool isEquip = false; // ���� ����or��� ���� �Ǿ����� Ȯ�� �ϴ� bool ���Դϴ�.
    public bool isArmorEquip = false;
    public bool isSmith = false;
    public bool isSelled = false;
    public bool isDungeon = false;

    public Button equipBtn;
    public Transform smithSlot;

   
    

    void Start()
    {

        itemUseManager = GameObject.Find("TentManager").GetComponent<ItemUseManager>();
        smithManager = GameObject.Find("SmithManager").GetComponent<SmithManager>();
        smithSlot = smithManager.smithSlot;
        itemData = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        equipBtn = gameObject.transform.GetChild(1).GetComponent<Button>();
        dgSelectMgr = GameObject.Find("DungeonSelectManager").GetComponent<Song.UI_DungeonSelect_Manager>();
        twMgr = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();


        itemData.hasEquipList.Add(gameObject);


        switch (gameObject.name) //���� ���ӿ�����Ʈ�� �̸��� �´� �Լ��� ����մϴ�.
        {
            case "Sword(Clone)":
                equipIndex = 0;
                EquipParamInit();

                break;
            case "Axe(Clone)":
                equipIndex = 1;
                EquipParamInit();

                break;
            case "Bow(Clone)":
                equipIndex = 2;
                EquipParamInit();

                break;
            case "Knife(Clone)":
                equipIndex = 3;
                EquipParamInit();

                break;
            case "PoleAxe(Clone)":
                equipIndex = 4;
                EquipParamInit();

                break;
            case "Saber(Clone)":
                equipIndex = 5;
                EquipParamInit();

                break;
            case "Wand(Clone)":
                equipIndex = 6;
                EquipParamInit();

                break;

            case "Amulet1(Clone)":
                equipIndex = 7;
                EquipParamInit();

                break;
            case "Amulet2(Clone)":
                equipIndex = 8;
                EquipParamInit();

                break;
            case "Amulet3(Clone)":
                equipIndex = 9;
                EquipParamInit();

                break;
            case "Armor1(Clone)":
                equipIndex = 10;
                EquipParamInit();

                break;
            case "Armor2(Clone)":
                equipIndex = 11;
                EquipParamInit();

                break;

            case "Boot1(Clone)":
                equipIndex = 12;
                EquipParamInit();

                break;
            case "Boot2(Clone)":
                equipIndex = 13;
                EquipParamInit();

                break;

            case "Boot3(Clone)":
                equipIndex = 14;
                EquipParamInit();

                break;
            case "Armor3(Clone)":
                equipIndex = 15;
                EquipParamInit();

                break;
            case "Armor4(Clone)":
                equipIndex = 16;
                EquipParamInit();

                break;
            case "Glove1(Clone)":
                equipIndex = 17;
                EquipParamInit();

                break;
            case "Glove2(Clone)":
                equipIndex = 18;
                EquipParamInit();

                break;
            case "Armor5(Clone)":
                equipIndex = 19;
                EquipParamInit();

                break;
            case "Helmet1(Clone)":
                equipIndex = 20;
                EquipParamInit();

                break;
            case "Helmet2(Clone)":
                equipIndex = 21;
                EquipParamInit();

                break;
            case "Helmet3(Clone)":
                equipIndex = 22;
                EquipParamInit();

                break;
            case "Ring1(Clone)":
                equipIndex = 23;
                EquipParamInit();

                break;
            case "Ring2(Clone)":
                equipIndex = 24;
                EquipParamInit();

                break;

            case "Shield(Clone)":
                equipIndex = 25;
                EquipParamInit();

                break;
            default:
                break;
        }
    }
    public void EquipParamInit() //EquipTable�� �ִ� ������ �����ɴϴ�. ������ equipIndex�� �ִ� Index�� ������� �����ɴϴ�.
    {
        if (equip.Name == "")
        {
            equip.Index = equipTable.initEquip[equipIndex].Index;
            equip.Name = equipTable.initEquip[equipIndex].Name;
            equip.Job = equipTable.initEquip[equipIndex].Job;
            equip.Lv = equipTable.initEquip[equipIndex].Lv;
            equip.Hp = equipTable.initEquip[equipIndex].Hp;
            equip.Mp = equipTable.initEquip[equipIndex].Mp;
            equip.Atk = equipTable.initEquip[equipIndex].Atk;
            equip.Def = equipTable.initEquip[equipIndex].Def;
            equip.Cri = equipTable.initEquip[equipIndex].Cri;
            equip.Acc = equipTable.initEquip[equipIndex].Acc;
            equip.Cost = equipTable.initEquip[equipIndex].Cost;
        }
        gameObject.name = equip.Name;
        equip.Cost = equipTable.initEquip[equipIndex].Cost;
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
                    EquipWeapon();
                    break;
                case 2:
                    EquipWeapon();
                    break;
                case 3:
                    EquipWeapon();
                    break;
                case 4:
                    EquipWeapon();
                    break;
                case 5:
                    EquipWeapon();
                    break;
                case 6:
                    EquipWeapon();
                    break;
                case 7:
                    EquipArmor();
                    break;
                case 8:
                    EquipArmor();
                    break;
                case 9:
                    EquipArmor();
                    break;
                case 10:
                    EquipArmor();
                    break;
                case 11:
                    EquipArmor();
                    break;
                case 12:
                    EquipArmor();
                    break;
                case 13:
                    EquipArmor();
                    break;
                case 14:
                    EquipArmor();
                    break;
                case 15:
                    EquipArmor();
                    break;
                case 16:
                    EquipArmor();
                    break;
                case 17:
                    EquipArmor();
                    break;
                case 18:
                    EquipArmor();
                    break;
                case 19:
                    EquipArmor();
                    break;
                case 20:
                    EquipArmor();
                    break;
                case 21:
                    EquipArmor();
                    break;
                case 22:
                    EquipArmor();
                    break;
                case 23:
                    EquipArmor();
                    break;
                case 24:
                    EquipArmor();
                    break;
                case 25:
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
                    UnEquipWeapon();
                    break;
                case 2:
                    UnEquipWeapon();
                    break;
                case 3:
                    UnEquipWeapon();
                    break;
                case 4:
                    UnEquipWeapon();
                    break;
                case 5:
                    UnEquipWeapon();
                    break;
                case 6:
                    UnEquipWeapon();
                    break;
                case 7:
                    UnEquipArmor();
                    break;
                case 8:
                    UnEquipArmor();
                    break;
                case 9:
                    UnEquipArmor();
                    break;
                case 10:
                    UnEquipArmor();
                    break;
                case 11:
                    UnEquipArmor();
                    break;
                case 12:
                    UnEquipArmor();
                    break;
                case 13:
                    UnEquipArmor();
                    break;
                case 14:
                    UnEquipArmor();
                    break;
                case 15:
                    UnEquipArmor();
                    break;
                case 16:
                    UnEquipArmor();
                    break;
                case 17:
                    UnEquipArmor();
                    break;
                case 18:
                    UnEquipArmor();
                    break;
                case 19:
                    UnEquipArmor();
                    break;
                case 20:
                    UnEquipArmor();
                    break;
                case 21:
                    UnEquipArmor();
                    break;
                case 22:
                    UnEquipArmor();
                    break;
                case 23:
                    UnEquipArmor();
                    break;
                case 24:
                    UnEquipArmor();
                    break;
                case 25:
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
                case 2:
                    UpgradeEquips();
                    break;
                case 3:
                    UpgradeEquips();
                    break;
                case 4:
                    UpgradeEquips();
                    break;
                case 5:
                    UpgradeEquips();
                    break;
                case 6:
                    UpgradeEquips();
                    break;
                case 7:
                    UpgradeEquips();
                    break;
                case 8:
                    UpgradeEquips();
                    break;
                case 9:
                    UpgradeEquips();
                    break;
                case 10:
                    UpgradeEquips();
                    break;
                case 11:
                    UpgradeEquips();
                    break;
                case 12:
                    UpgradeEquips();
                    break;
                case 13:
                    UpgradeEquips();
                    break;
                case 14:
                    UpgradeEquips();
                    break;
                case 15:
                    UpgradeEquips();
                    break;
                case 16:
                    UpgradeEquips();
                    break;
                case 17:
                    UpgradeEquips();
                    break;
                case 18:
                    UpgradeEquips();
                    break;
                case 19:
                    UpgradeEquips();
                    break;
                case 20:
                    UpgradeEquips();
                    break;
                case 21:
                    UpgradeEquips();
                    break;
                case 22:
                    UpgradeEquips();
                    break;
                case 23:
                    UpgradeEquips();
                    break;
                case 24:
                    UpgradeEquips();
                    break;
                case 25:
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
                for (int i = itemData.hasEquipList.Count - 1; i >= 0; i--) //������ ��� �� ����Ʈ�� �ִ� ������Ʈ ���� �� �ߺ����� �����Ǵ°� ���� �ϱ� ���� ���� 03-30 ������
                {
                    if (itemData.hasEquipList[i].GetComponent<EquipScripts_ysg>().isSelled)
                    {
                        itemData.hasEquipList.RemoveAt(i);
                    }
                }
                equipBtn.gameObject.SetActive(false);
                Destroy(gameObject);
                Debug.Log("�ǸſϷ�");

            }

        }
        else
        {
            SellCancel();
        }


    }
    public void EquipWeapon() // ���� ���� �� ����Ǵ� �Լ��Դϴ�.
    {
        if (itemUseManager.isActive) // ������ ���� �Ǿ��ٸ� �����մϴ�.
        {
            if (itemUseManager.equips[0].Name == "" && !isEquip && itemUseManager.stats.Job == equip.Job)
            {
                isEquip = true;
                //itemUseManager.isActive = false;
                itemUseManager.equips[0].Index = equip.Index;
                itemUseManager.equips[0].Name = equip.Name;
                itemUseManager.equips[0].Job = equip.Job;
                itemUseManager.equips[0].Lv = equip.Lv;
                itemUseManager.equips[0].Hp = equip.Hp;
                itemUseManager.equips[0].Mp = equip.Mp;
                itemUseManager.equips[0].Atk += equip.Atk;
                itemUseManager.equips[0].Def += equip.Def;
                itemUseManager.equips[0].Cri += equip.Cri;
                itemUseManager.equips[0].Acc += equip.Acc;
                equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
                equipBtn.gameObject.SetActive(false);
            }


        }
    }
    public void EquipArmor() // ��� ���� �� ����Ǵ� �Լ��Դϴ�.
    {
        if (itemUseManager.isActive)
        {
            if (itemUseManager.equips[1].Name == "" && !isArmorEquip)
            {
                isArmorEquip = true;
                //itemUseManager.isActive = false;
                itemUseManager.equips[1].Index = equip.Index;
                itemUseManager.equips[1].Name = equip.Name;
                itemUseManager.equips[1].Job = equip.Job;
                itemUseManager.equips[1].Lv = equip.Lv;
                itemUseManager.equips[1].Hp = equip.Hp;
                itemUseManager.equips[1].Mp = equip.Mp;
                itemUseManager.equips[1].Atk += equip.Atk;
                itemUseManager.equips[1].Def += equip.Def;
                itemUseManager.equips[1].Cri += equip.Cri;
                itemUseManager.equips[1].Acc += equip.Acc;
                equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
                equipBtn.gameObject.SetActive(false);
            }

        }
    }

    public void UnEquipWeapon() //���� ���� �Լ��Դϴ�.
    {
        if (isEquip && itemUseManager.isActive)
        {
            if (itemUseManager.equips[0].Name != "" && isEquip)
            {
                isEquip = false;
                //itemUseManager.isActive = false;
                itemUseManager.equips[0].Index = -1;
                itemUseManager.equips[0].Name = null;
                itemUseManager.equips[0].Job = null;
                itemUseManager.equips[0].Lv = 0;
                itemUseManager.equips[0].Hp = 0;
                itemUseManager.equips[0].Mp = 0;
                itemUseManager.equips[0].Atk = 0;
                itemUseManager.equips[0].Def = 0;
                itemUseManager.equips[0].Cri = 0;
                itemUseManager.equips[0].Acc = 0;

                equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
                equipBtn.gameObject.SetActive(false);
            }


        }
    }

    public void UnEquipArmor() // ��� ���� �Լ��Դϴ�.
    {
        if (isArmorEquip && itemUseManager.isActive)
        {
            if (itemUseManager.equips[1].Name != "" && isArmorEquip)
            {
                isArmorEquip = false;
                //itemUseManager.isActive = false;
                itemUseManager.equips[1].Index = -1;
                itemUseManager.equips[1].Name = null;
                itemUseManager.equips[1].Job = null;
                itemUseManager.equips[1].Lv = 0;
                itemUseManager.equips[1].Hp = 0;
                itemUseManager.equips[1].Mp = 0;
                itemUseManager.equips[1].Atk = 0;
                itemUseManager.equips[1].Def = 0;
                itemUseManager.equips[1].Cri = 0;
                itemUseManager.equips[1].Acc = 0;
                equipBtn.transform.GetChild(0).GetComponent<Text>().text = "����";
                equipBtn.gameObject.SetActive(false);
            }


        }
    }

    public void UpgradeEquips() // ����, ��� ��ȭ �Լ��Դϴ�.
    {
        if (!smithManager.isSlotFull && smithManager.isActive)
        {
                smithManager.isSlotFull = true;
                smithManager.equip.Index = equip.Index;
                smithManager.equip.Name = equip.Name;
                smithManager.equip.Job = equip.Job;
                smithManager.equip.Lv = equip.Lv;
                smithManager.equip.Hp = equip.Hp;
                smithManager.equip.Mp = equip.Mp;
                smithManager.equip.Atk = equip.Atk;
                smithManager.equip.Def = equip.Def;
                smithManager.equip.Cri = equip.Cri;
                smithManager.equip.Acc = equip.Acc;
                gameObject.transform.SetParent(smithSlot);
                gameObject.transform.localPosition = smithSlot.localPosition;
                gameObject.transform.localScale = smithSlot.localScale;

                equipBtn.gameObject.SetActive(false);
            
        }



    }


    public void SellCancel() //������ �������� �ʱ�ȭ ��ŵ�ϴ�.
    {
        sell = 0;
        isSelled = false;
    }

    public void ShowBtnOnlyDungeon() // ������ ���� �� ��ư ǥ�ø� �մϴ�.
    {
        if (dgSelectMgr.isTent && itemUseManager.isActive)
        {
            if (!isDungeon)
            {
                isDungeon = true;
                equipBtn.gameObject.SetActive(true);
            }
            else
            {
                isDungeon = false;
                equipBtn.gameObject.SetActive(false);
            }
        }

    }



}
