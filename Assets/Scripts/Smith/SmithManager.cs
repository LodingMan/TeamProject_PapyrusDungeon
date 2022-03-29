using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SmithManager : MonoBehaviour
{
    public Equip equip;
    public Transform smithSlot;
    public Transform inventory;

    public bool isActive = false;
    public bool isSlotFull = false;

    private void Start()
    {
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
            isSlotFull = false;
            int rnd = Random.Range(0, 100);
            if (rnd < 50)
            {
                equip.Lv++;
                Debug.Log("강화 성공! 레벨"+ equip.Lv);

            }
            else
            {
                equip.Lv = 1;
                Debug.Log("강화 실패" + equip.Lv);
            }
            GameObject smithEquip = smithSlot.GetChild(0).gameObject;
            smithEquip.GetComponent<EquipScripts_ysg>().equip.Lv = equip.Lv;
            smithEquip.transform.SetParent(inventory);
            smithEquip.transform.localPosition = inventory.localPosition;
            smithEquip.transform.localScale = new Vector3(1, 1, 1);
            equip.Name = "";

        }
    }


}
