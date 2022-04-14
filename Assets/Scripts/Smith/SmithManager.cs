using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//==================================================================================================//
// 장비 강화 스크립트입니다.. 03-29 윤성근
//==================================================================================================//
public class SmithManager : MonoBehaviour
{
    public Equip equip;
    public Transform smithSlot;
    public Transform inventory;
    public int equipIndex;

    public int upgradeChance = 100;
    public ShopManager shopManager;


    public bool isActive = false;
    public bool isSlotFull = false;

    public GameObject popupPanel;
    public Text upgradeText;
    public Text upgradeFailText;
    public GameObject upgradeFailPanel;
    public GameObject[] upgradeEffect = new GameObject[2];

    private void Start()
    {
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        isActive = false;

    }



    public void SmithSetting() // ?????? ????????? ??
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

    public void Upgrade() // ??? ??? ???????.
    {
        if (equip.Name != "" && isSlotFull)
        {
            upgradeChance = 100;
            isSlotFull = false;
            GameObject smithEquip = smithSlot.GetChild(0).gameObject;
            equip = smithEquip.GetComponent<EquipScripts_ysg>().equip;
            equipIndex = equip.Index;
            int rnd = Random.Range(0, 100);
            upgradeChance -= equip.Lv * 10;
            if (upgradeChance < 0)
            {
                upgradeChance = 0;
            }
            if (rnd < upgradeChance)
            {
                int originalLv = equip.Lv;
                equip.Lv++;
                equip.Hp = (equip.Hp * 1) + equip.Lv + 1;
                equip.Mp = (equip.Mp * 1) + equip.Lv + 1;
                equip.Atk = (equip.Atk * 1) + equip.Lv + 1;
                equip.Def = (equip.Def * 1) + equip.Lv + 1;
                equip.Cri = (equip.Cri * 1) + equip.Lv + 1;
                equip.Acc = (equip.Acc * 1) + equip.Lv + 1;
                upgradeText.text = " LV " + originalLv + " -> " + " LV " + equip.Lv.ToString();
                GameObject compliteEffect = Instantiate(upgradeEffect[0]);
                compliteEffect.transform.position = new Vector3(3.4f, 0.5f, 47);
                compliteEffect.transform.rotation = Quaternion.Euler(11, 0, 0);
                compliteEffect.transform.localScale = new Vector3(1, 1, 1);
                Destroy(compliteEffect, 3f);

                StartCoroutine(UpgradeTextDelay());
                //Debug.Log("??? ????! ????: "+ equip.Lv +",??? :" + upgradeChance + "%");


            }
            else
            {
                int originalLv = equip.Lv;
                Equip smithEquipOriginStats = smithEquip.GetComponent<EquipScripts_ysg>().equipTable.initEquip[equipIndex];
                equip.Lv = 1;
                equip.Hp = smithEquipOriginStats.Hp;
                equip.Mp = smithEquipOriginStats.Mp;
                equip.Atk = smithEquipOriginStats.Atk;
                equip.Def = smithEquipOriginStats.Def;
                equip.Cri = smithEquipOriginStats.Cri;
                equip.Acc = smithEquipOriginStats.Acc;
                equip.Cost = smithEquipOriginStats.Cost;
                upgradeFailText.text = " LV " + originalLv + " -> " + " LV " + equip.Lv.ToString();
                GameObject compliteEffect = Instantiate(upgradeEffect[1]);
                compliteEffect.transform.position = new Vector3(3.4f, 0.5f, 47);
                compliteEffect.transform.rotation = Quaternion.Euler(11, 0, 0);
                compliteEffect.transform.localScale = new Vector3(1, 1, 1);
                Destroy(compliteEffect, 3f);
                StartCoroutine(UpgradeFailed());
                //Debug.Log("??? ????! ????: " + equip.Lv + ",??? :" + upgradeChance +"%");

            }
            smithEquip.GetComponent<EquipScripts_ysg>().equip = equip;
            smithEquip.GetComponent<EquipDataSave>().equipSavingData.equip = equip;
            smithEquip.transform.GetChild(4).GetComponent<Text>().text = equip.Lv.ToString();
            smithEquip.GetComponent<EquipDataSave>().SaveEquip();
            shopManager.money -= 100 * equip.Lv;
            shopManager.GoldRefresh();
            smithEquip.transform.SetParent(inventory);
            smithEquip.transform.localPosition = inventory.localPosition;
            smithEquip.transform.localScale = new Vector3(1, 1, 1);

            if (shopManager.hasEquipList.Contains(smithEquip))
            {
                shopManager.hasEquipList.Remove(smithEquip);
                shopManager.hasEquipList.Add(smithEquip);
                shopManager.ItemSave();


            }
            else
            {
                shopManager.hasEquipList.Add(smithEquip);
                shopManager.ItemSave();


            }




        }
    }

    public void EquipReturnToInven()
    {
        if (isSlotFull)
        {
            GameObject smithEquip = smithSlot.GetChild(0).gameObject;
            smithEquip.transform.SetParent(inventory);
            smithEquip.transform.localPosition = inventory.localPosition;
            smithEquip.transform.localScale = new Vector3(1, 1, 1);

        }
        isSlotFull = false;
    }

    IEnumerator UpgradeTextDelay()
    {
        popupPanel.transform.DOLocalMove(new Vector3(120, 300, 0), 1f);
        yield return new WaitForSeconds(1f);
        popupPanel.transform.DOLocalMove(new Vector3(120, 450, 0), 1f);
    }

    IEnumerator UpgradeFailed()
    {
        upgradeFailPanel.transform.DOLocalMove(new Vector3(120, 300, 0), 1f);
        yield return new WaitForSeconds(1f);
        upgradeFailPanel.transform.DOLocalMove(new Vector3(120, 450, 0), 1f);
    }


}
