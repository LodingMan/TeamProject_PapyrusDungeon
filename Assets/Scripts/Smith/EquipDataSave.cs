using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==================================================================================================//
// ��� ���� ���� ��ũ��Ʈ�Դϴ�. 03-29 ������
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
