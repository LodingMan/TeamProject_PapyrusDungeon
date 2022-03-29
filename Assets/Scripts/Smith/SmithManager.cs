using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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



    public void SmithSetting()
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

    public void Upgrade()
    {

        if (equip.Name != "")
        {
            upgradeChance = 100;
            isSlotFull = false;
            GameObject smithEquip = smithSlot.GetChild(0).gameObject;
            equip.Lv = smithEquip.GetComponent<EquipScripts_ysg>().equip.Lv;
            int rnd = Random.Range(0, 100);
            upgradeChance -= equip.Lv * 10;
            if (upgradeChance < 0)
            {
                upgradeChance = 0;
            }
            if (rnd < upgradeChance)
            {
                equip.Lv++;
                Debug.Log("강화 성공! 레벨: "+ equip.Lv +",확률 :" + upgradeChance + "%");

            }
            else
            {
                equip.Lv = 1;
                Debug.Log("강화 실패! 레벨: " + equip.Lv + ",확률 :" + upgradeChance +"%");
            }
            smithEquip.GetComponent<EquipScripts_ysg>().equip.Lv = equip.Lv;
            smithEquip.GetComponent<EquipDataSave>().equipSavingData.equip.Lv = equip.Lv;
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


}
