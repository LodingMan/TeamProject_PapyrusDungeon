using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//해당 스크립트파일은 Enemy도 사용하므로 Param폴더를 따로 생성해 옮겨놓을 예정 -> 송하늘 03/26
[System.Serializable]
public class Stat
{
    public int Index;
    public int Lv;
    public string Name;
    public string Job;
    public int HP;
    public int MAXHP;
    public int MP;
    public int MAXMP;
    public int Atk;
    public int Def;
    public int Cri;
    public int Acc;
    public int Agi;
    public int Speed;

    public Stat(int index, string name, string job, int hp, int maxhp, int mp, int maxmp, int atk, int def, int cri, int acc, int agi, int speed)
    {
        this.Index = index;
        this.Name = name;
        this.Job = job;
        this.HP = hp;
        this.MAXHP = maxhp;
        this.MP = mp;
        this.MAXMP = maxmp;
        this.Atk = atk;
        this.Def = def;
        this.Cri = cri;
        this.Acc = acc;
        this.Agi = agi;
        this.Speed = speed; // 03 - 25 Speed 추가


    }
    public Stat(Stat nStat)
    {

        this.Index = nStat.Index;
        this.Name = nStat.Name;
        this.Job = nStat.Job;
        this.HP = nStat.HP;
        this.MAXHP = nStat.MAXHP;
        this.MP = nStat.MP;
        this.MAXMP = nStat.MAXMP;
        this.Atk = nStat.Atk;
        this.Def = nStat.Def;
        this.Cri = nStat.Cri;
        this.Acc = nStat.Acc;
        this.Agi = nStat.Agi;
        this.Speed = nStat.Speed;
    }
}
[System.Serializable]
public class skill // 03-26 Lv 추가
{
    public int Index;
    public string Name;
    public int LV;
    public int ATK;
    public int Type;
    public int[] MyPosition;
    public int[] EnemyPosition;
   
    public skill(int index, string name, int lv, int atk, int type , int[] myPosition, int[] enemyPosition)
    {
        this.Index = index;
        this.Name = name;
        this.LV = lv;
        this.ATK = atk;
        this.Type = type;
        this.MyPosition = myPosition;
        this.EnemyPosition = enemyPosition;
    }
}

[System.Serializable]
public class Item // Item은 이후 상점에서 별도로 쓰일 가능성이 있을거 같아 일단 장비는 Equip클래스를 사용하겠습니다 -> 송하늘 03-25
{
    public int Index; 
    public string Name;   //체력물약
    public int Pram = -30; // Ex) TargetStatus가 "HP"라면 대상의 HP를 -30.  "MP" 라면 MP를 -30. Switch문으로 제어할 예정 
    public int cost; //가격
    public string TargetStatus = "HP"; // 아이템이 대상에게 영향을 미칠 스테이터스 


    public Item(int index, string name, int pram, int cost, string targetStatus)
    {
        this.Index = index;
        this.Name = name;
        this.Pram = pram;
        this.cost = cost;
        this.TargetStatus = targetStatus;
    }
}
public class HeroSavingData
{

    public Stat stat;
    public skill[] skills;
    public Equip[] equips;
    public int ColorType;

}

[System.Serializable]
public class Equip
{
    public int Index;
    public string Name;
    public string Job;
    public int Lv;
    public int Hp;
    public int Mp;
    public int Atk;
    public int Def;
    public int Cri;
    public int Acc;
    public int Cost;

    public Equip(int index, string name, string job, int lv, int hp, int mp, int atk, int def, int cri, int acc, int cost)
    {
        Index = index;
        Name = name;
        Job = job;
        Lv = lv;
        Hp = hp;
        Mp = mp;
        Atk = atk;
        Def = def;
        Cri = cri;
        Acc = acc;
        Cost = cost;
    }
}

[System.Serializable]
public class EquipSavingData
{
    public Equip equip;
}

[System.Serializable]
public class ItemSavingData
{
    public Item item;
}

namespace Shin
{
    public class SkillDetail
    {
        public int skillindex;
        public string skillname;
        public string skilldetail;

        public SkillDetail(int skillindex, string skillname, string skilldetail)
        {
            this.skillindex = skillindex;
            this.skillname = skillname;
            this.skilldetail = skilldetail;
        }
    }
}
