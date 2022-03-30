using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==================================================================================================//
// 장비 스텟 저장 스크립트입니다. 03-29 윤성근
//==================================================================================================//
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
