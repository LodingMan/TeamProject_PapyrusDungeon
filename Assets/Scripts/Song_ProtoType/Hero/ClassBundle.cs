using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public int Index;
    public string Name;
    public string Job;
    public int HP;
    public int MP;
    public int Atk;
    public int Def;
    public int Cri;
    public int Acc;
    public int Agi;
    
    public Stat(int index, string name, string job, int hp, int mp, int atk, int def, int cri, int acc, int agi)
    {
        this.Index = index;
        this.Name = name;
        this.Job = job;
        this.HP = hp;
        this.MP = mp;
        this.Atk = atk;
        this.Def = def;
        this.Cri = cri;
        this.Acc = acc;
        this.Agi = agi;

    }
}
public class skill
{
    public int Index;
    public string Name;
    public int ATK;
    public int DEF;
    public int[] MyPosition;
    public int[] EnemyPosition;
   
    public skill(int index, string name, int atk, int def , int[] myPosition, int[] enemyPosition)
    {
        this.Index = index;
        this.Name = name;
        this.ATK = atk;
        this.DEF = def;
        this.MyPosition = myPosition;
        this.EnemyPosition = enemyPosition;
    }
}

public class Item
{
    public int Index;
    public string Name;
    public int ATK;
    public int Def;

}

public class HeroSavingData
{
    public int Index;
    public string Name;
    public string Job;
    public int HP;
    public int MP;
    public int Atk;
    public int Def;
    public int Cri;
    public int Acc;
    public int Agi;

    public skill[] skills;

}
