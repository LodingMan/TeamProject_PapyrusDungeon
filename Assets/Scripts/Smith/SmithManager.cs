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

    public Text upgradeChanceText;

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
            upgradeChance -= equip.Lv * 20;
            if (upgradeChance < 0)
            {
                upgradeChance = 1;
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
                shopManager.money -= 100;
                Destroy(compliteEffect, 3f);

                StartCoroutine(UpgradeTextDelay());


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
                shopManager.money -= 100;

                Destroy(compliteEffect, 3f);
                StartCoroutine(UpgradeFailed());


            }
            smithEquip.GetComponent<EquipScripts_ysg>().equip = equip;
            smithEquip.GetComponent<EquipDataSave>().equipSavingData.equip = equip;
            smithEquip.transform.GetChild(4).GetComponent<Text>().text = equip.Lv.ToString();
            smithEquip.GetComponent<EquipDataSave>().SaveEquip();
            shopManager.GoldRefresh();
            smithEquip.transform.SetParent(inventory);
            smithEquip.transform.localPosition = inventory.localPosition;
            smithEquip.transform.localScale = new Vector3(1, 1, 1);
            upgradeChanceText.gameObject.SetActive(false);
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
            upgradeChanceText.gameObject.SetActive(false);

        }
        isSlotFull = false;
        upgradeChanceText.gameObject.SetActive(false);

    }

    IEnumerator UpgradeTextDelay()
    {
        popupPanel.transform.gameObject.SetActive(true);
        popupPanel.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 1f);
        yield return new WaitForSeconds(1.5f);
        popupPanel.transform.DOScale(new Vector3(0, 0, 0), 1f);
        popupPanel.transform.gameObject.SetActive(false);
    }

    IEnumerator UpgradeFailed()
    {
        upgradeFailPanel.transform.gameObject.SetActive(true);
        upgradeFailPanel.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 1f);
        yield return new WaitForSeconds(1.5f);
        upgradeFailPanel.transform.DOScale(new Vector3(0, 0, 0), 1f);
        upgradeFailPanel.transform.gameObject.SetActive(false);
    }


}
