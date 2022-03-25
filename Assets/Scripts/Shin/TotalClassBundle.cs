using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public int gold;
    public int week;
    public int jewel;

    public PlayerClass(int gold, int week, int jewel)
    {
        this.gold = gold;
        this.week = week;
        this.jewel = jewel;
    }
}

/*public class HeroClass
{
    public int index;
    public string name;
    public string job;
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
    public string skill01;
    public string skill02;
    public string skill03;
    public string skill04;
    public string skill05;

    public HeroClass(int index, string name, string job, int lv, int hp, int mp, int atk, int def, int cri, int acc, int agi, string weapon, string armor, string skill01, string skill02, string skill03, string skill04, string skill05)
    {
        this.index = index;
        this.name = name;
        this.job = job;
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
        this.skill01 = skill01;
        this.skill02 = skill02;
        this.skill03 = skill03;
        this.skill04 = skill04;
        this.skill05 = skill05;
    }
}*/

public class HeroClass
{
    public int index;
    public Stats stats;
    public Equip equip;
    public Skill[] skill;

    public HeroClass(int index, Stats stats, Equip equip, Skill[] skill)
    {
        this.index = index;
        this.stats = stats;
        this.equip = equip;
        this.skill = skill;
    }
}
public class SavingData
{
    public Stats stats;
    public Equip equip;
    public skill[] skill;
}
public class Stats
{

    public string name;
    public string job;
    public int lv;
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int cri;
    public int acc;
    public int agi;

    public Stats(string name, string job, int lv, int hp, int mp, int atk, int def, int cri, int acc, int agi)
    {
        this.name = name;
        this.job = job;
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

public class Equip
{
    public string name;
    public int lv;
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int acc;
    public int cri;
    public int agi;

    public Equip(string name, int lv, int hp, int mp, int atk, int def, int acc, int cri, int agi)
    {
        this.name = name;
        this.lv = lv;
        this.hp = hp;
        this.mp = mp;
        this.atk = atk;
        this.def = def;
        this.acc = acc;
        this.cri = cri;
        this.agi = agi;
    }
}

public class Skill
{
    public string name;
    public int lv;
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int acc;
    public int cri;
    public int agi;
    public int cooltime;

    public Skill(string name, int lv, int hp, int mp, int atk, int def, int acc, int cri, int agi, int cooltime)
    {
        this.name = name;
        this.lv = lv;
        this.hp = hp;
        this.mp = mp;
        this.atk = atk;
        this.def = def;
        this.acc = acc;
        this.cri = cri;
        this.agi = agi;
        this.cooltime = cooltime;
    }
}

