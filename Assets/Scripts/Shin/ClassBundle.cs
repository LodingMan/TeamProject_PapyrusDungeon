using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipClass
{
    public string name;
    public bool isWeapon;
    public int lv;
    public int atk;
    public int def;
    public int cri;
    public int acc;
    public int agi;

    public EquipClass(string name, bool isWeapon, int lv, int atk, int def, int cri, int acc, int agi)
    {
        this.name = name;
        this.isWeapon = isWeapon;
        this.lv = lv;
        this.atk = atk;
        this.def = def;
        this.cri = cri;
        this.acc = acc;
        this.agi = agi;
    }
}

public class EnemyClass
{
    public string name;
    public int lv;
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int cri;
    public int acc;
    public int agi;

    public EnemyClass(string name, int lv, int hp, int mp, int atk, int def, int cri, int acc, int agi)
    {
        this.name = name;
        this.lv = lv;
        this.hp = hp;
        this.mp = mp;
        this.atk = atk;
        this.def = def;
        this.cri = cri;
        this.acc = acc;
        this.agi = agi;
    }
    //public string skill01;
    //public string skill02;
}


