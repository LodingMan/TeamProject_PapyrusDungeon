using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�ش� ��ũ��Ʈ������ Enemy�� ����ϹǷ� Param������ ���� ������ �Űܳ��� ���� -> ���ϴ� 03/26
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
        this.Speed = speed; // 03 - 25 Speed �߰�


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
public class skill // 03-26 Lv �߰�
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
public class Item // Item�� ���� �������� ������ ���� ���ɼ��� ������ ���� �ϴ� ���� EquipŬ������ ����ϰڽ��ϴ� -> ���ϴ� 03-25
{
    public int Index; 
    public string Name;   //ü�¹���
    public int Pram = -30; // Ex) TargetStatus�� "HP"��� ����� HP�� -30.  "MP" ��� MP�� -30. Switch������ ������ ���� 
    public int cost; //����
    public string TargetStatus = "HP"; // �������� ��󿡰� ������ ��ĥ �������ͽ� 


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
