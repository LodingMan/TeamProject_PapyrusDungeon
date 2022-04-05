using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//==================================================================================================//
// 대장간 스크립트입니다. 장비 강화 및 강화 수치 반환을 담당합니다. 03-29 윤성근
//==================================================================================================//
public class SmithManager : MonoBehaviour
{
    public Equip equip;
    public Transform smithSlot;
    public Transform inventory;

    public int upgradeChance = 100;
    public ShopManager shopManager;


    public bool isActive = false;
    public bool isSlotFull = false;

    private void Start()
    {
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        isActive = false;
    }



    public void SmithSetting() // 대장간이 켜져있는지 체크
    {
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }

    public void Upgrade() // 장비 강화 함수입니다.
    {
        if (equip.Name != "")
        {
            upgradeChance = 100;
            isSlotFull = false;
            GameObject smithEquip = smithSlot.GetChild(0).gameObject;
            equip = smithEquip.GetComponent<EquipScripts_ysg>().equip;
            int rnd = Random.Range(0, 100);
            upgradeChance -= equip.Lv * 10;
            if (upgradeChance < 0)
            {
                upgradeChance = 0;
            }
            if (rnd < upgradeChance)
            {
                equip.Lv++;
                equip.Hp = (equip.Hp * 1) + equip.Lv + 1;
                equip.Mp = (equip.Mp * 1) + equip.Lv + 1;
                equip.Atk = (equip.Atk * 1) + equip.Lv + 1;
                equip.Def = (equip.Def * 1) + equip.Lv + 1;
                equip.Cri = (equip.Cri * 1) + equip.Lv + 1;
                equip.Acc = (equip.Acc * 1) + equip.Lv + 1;
                Debug.Log("강화 성공! 레벨: "+ equip.Lv +",확률 :" + upgradeChance + "%");

            }
            else
            {
                Equip smithEquipOriginStats = smithEquip.GetComponent<EquipTable>().initEquip[equip.Index];
                equip.Lv = 1;
                equip.Hp = smithEquipOriginStats.Hp;
                equip.Mp = smithEquipOriginStats.Mp;
                equip.Atk = smithEquipOriginStats.Atk;
                equip.Def = smithEquipOriginStats.Def;
                equip.Cri = smithEquipOriginStats.Cri;
                equip.Acc = smithEquipOriginStats.Acc;

                Debug.Log("강화 실패! 레벨: " + equip.Lv + ",확률 :" + upgradeChance +"%");
            }
            smithEquip.GetComponent<EquipScripts_ysg>().equip = equip;
            smithEquip.GetComponent<EquipDataSave>().equipSavingData.equip = equip;
            smithEquip.GetComponent<EquipDataSave>().SaveEquip();
            smithEquip.transform.SetParent(inventory);
            smithEquip.transform.localPosition = inventory.localPosition;
            smithEquip.transform.localScale = new Vector3(1, 1, 1);
            if (shopManager.hasEquipList.Contains(smithEquip))
            {
                shopManager.hasEquipList.Remove(smithEquip);
                shopManager.hasEquipList.Add(smithEquip);
            }
            else
            {
                shopManager.hasEquipList.Add(smithEquip);
            }

            
            

        }
    }

    public void EquipReturnToInven()
    {
        if (smithSlot.GetChild(0) != null)
        {
            equip = null;

            smithSlot.GetChild(0).SetParent(inventory);
            smithSlot.GetChild(0).transform.localPosition = inventory.localPosition;
            smithSlot.GetChild(0).transform.localScale = new Vector3(1, 1, 1);

        }
    }


}
