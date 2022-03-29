using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipDataSave : MonoBehaviour
{
    public EquipSavingData equipSavingData = new EquipSavingData();
    void Start()
    {
        SaveEquip();

    }
    public void SaveEquip()
    {
        equipSavingData.equip = gameObject.GetComponent<EquipScripts_ysg>().equip;

    }
}
