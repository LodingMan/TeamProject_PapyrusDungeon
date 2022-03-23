using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipStatsLoad : MonoBehaviour
{
    public HeroStatsLoad heroStatsLoad;
    public EquipSL equipSL;
    public string weapon;
    public bool isWeapon;
    public int w_Lv;
    public int w_Atk;
    public int w_Def;
    public int w_Cri;
    public int w_Acc;
    public int w_Agi;

    public string armor;
    public bool isArmor;
    public int a_Lv;
    public int a_Atk;
    public int a_Def;
    public int a_Cri;
    public int a_Acc;
    public int a_Agi;
    // Start is called before the first frame update
    void Start()
    {
        heroStatsLoad = gameObject.GetComponent<HeroStatsLoad>();
        equipSL = GameObject.Find("EquipMgr").GetComponent<EquipSL>();
        weapon = heroStatsLoad.weapon;
        armor = heroStatsLoad.armor;
        // heroStats.weapon과 armor의 문자열을 검사
        for (int i = 0; i < 6; i++)
        {
            if (weapon == equipSL.equipName[i])
            {
                isWeapon = equipSL.isWeapon[i];
                w_Lv = equipSL.lv[i];
                w_Atk = equipSL.atk[i];
                w_Def = equipSL.def[i];
                w_Cri = equipSL.cri[i];
                w_Acc = equipSL.acc[i];
                w_Agi = equipSL.agi[i];
            }
            if (armor == equipSL.equipName[i])
            {
                isArmor = !equipSL.isWeapon[i];
                a_Lv = equipSL.lv[i];
                a_Atk = equipSL.atk[i];
                a_Def = equipSL.def[i];
                a_Cri = equipSL.cri[i];
                a_Acc = equipSL.acc[i];
                a_Agi = equipSL.agi[i];
            }
        }
        
    }

}
