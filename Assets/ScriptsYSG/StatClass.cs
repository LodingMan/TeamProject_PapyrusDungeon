using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StatClass
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
    public string weapon;
    public string armor;
    public int heroNum;

    public StatClass(string name, int lv, int hp, int mp, int atk, int def, int cri, int acc, int agi, string weapon, string armor, int heroNum)
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
        this.weapon = weapon;
        this.armor = armor;
        this.heroNum = heroNum;
    }
}

public class MonsterStatClass
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

    public MonsterStatClass(string name, int lv, int hp, int mp, int atk, int def, int cri, int acc, int agi)
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
}



