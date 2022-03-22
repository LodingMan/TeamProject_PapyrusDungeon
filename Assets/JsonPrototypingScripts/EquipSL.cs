using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class EquipSL : MonoBehaviour
{
    List<EquipClass> weaponData = new List<EquipClass>();

    public string[] equipName = new string[6];
    public bool[] isWeapon = new bool[6];
    public int[] lv = new int[6];
    public int[] atk = new int[6];
    public int[] def = new int[6];
    public int[] cri = new int[6];
    public int[] acc = new int[6];
    public int[] agi = new int[6];

    private void Awake()
    {
        weaponData.Add(new EquipClass(equipName[0], isWeapon[0], lv[0], atk[0], def[0], cri[0], acc[0], agi[0]));
        weaponData.Add(new EquipClass(equipName[1], isWeapon[1], lv[1], atk[1], def[1], cri[1], acc[1], agi[1]));
        weaponData.Add(new EquipClass(equipName[2], isWeapon[2], lv[2], atk[2], def[2], cri[2], acc[2], agi[2]));
        weaponData.Add(new EquipClass(equipName[3], isWeapon[3], lv[3], atk[3], def[3], cri[3], acc[3], agi[3]));
        weaponData.Add(new EquipClass(equipName[4], isWeapon[4], lv[4], atk[4], def[4], cri[4], acc[4], agi[4]));
        weaponData.Add(new EquipClass(equipName[5], isWeapon[5], lv[5], atk[5], def[5], cri[5], acc[5], agi[5]));


    }
    public void EquipSave()
    {
        string jdata = JsonConvert.SerializeObject(weaponData);

        File.WriteAllText(Application.dataPath + "/" + "Resources" + "/" + "EquipItem.json", jdata);
    }
    public void EquipLoad()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "EquipItem.json");
        if (jdata == null)
        {
            Debug.Log("불러올 데이터가 없습니다... Player");
            return;
        }
        weaponData = JsonConvert.DeserializeObject<List<EquipClass>>(jdata);
        Debug.Log(jdata);
    }
}
