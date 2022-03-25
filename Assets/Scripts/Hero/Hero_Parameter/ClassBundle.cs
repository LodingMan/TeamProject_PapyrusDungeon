using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ش� ��ũ��Ʈ������ Enemy�� ����ϹǷ� Param������ ���� ������ �Űܳ��� ���� -> ���ϴ� 03/26
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
    public int Speed;
    
    public Stat(int index, string name, string job, int hp, int mp, int atk, int def, int cri, int acc, int agi, int speed)
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
        this.Speed = speed; // 03 - 25 Speed �߰�

    }
}
public class skill // 03-26 Lv �߰�
{
    public int Index;
    public string Name;
    public int LV;
    public int ATK;
    public int DEF;
    public int[] MyPosition;
    public int[] EnemyPosition;
   
    public skill(int index, string name, int lv, int atk, int def , int[] myPosition, int[] enemyPosition)
    {
        this.Index = index;
        this.Name = name;
        this.LV = lv;
        this.ATK = atk;
        this.DEF = def;
        this.MyPosition = myPosition;
        this.EnemyPosition = enemyPosition;
    }
}


public class Item // Item�� ���� �������� ������ ���� ���ɼ��� ������ ���� �ϴ� ���� EquipŬ������ ����ϰڽ��ϴ� -> ���ϴ� 03-25
{
}

public class HeroSavingData
{
    #region //03-25 ���� �Ķ���� ����// ���� : ���ƾ� ����� �ι� ����� ������ ����
    //public int Index;
    //public string Name;
    //public string Job;
    //public int HP;
    //public int MP;
    //public int Atk;
    //public int Def;
    //public int Cri;
    //public int Acc;
    //public int Agi;
    //public int Speed;
    #endregion

    public Stat stat;
    public skill[] skills;
    public Equip[] equips;

}
public class Equip
{
    public int Index;
    public string Name;
    public int Atk;
    public int Def;
    
    public Equip(int index, string name, int atk, int def)
    {
        this.Index = index;
        this.Name = name;
        this.Atk = atk;
        this.Def = def;
    }
}
