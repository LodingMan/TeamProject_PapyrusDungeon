using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//해당 스크립트파일은 Enemy도 사용하므로 Param폴더를 따로 생성해 옮겨놓을 예정 -> 송하늘 03/26
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
        this.Speed = speed; // 03 - 25 Speed 추가

    }
}
public class skill // 03-26 Lv 추가
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


public class Item // Item은 이후 상점에서 별도로 쓰일 가능성이 있을거 같아 일단 장비는 Equip클래스를 사용하겠습니다 -> 송하늘 03-25
{
}

public class HeroSavingData
{
    #region //03-25 스텟 파라미터 수정// 사유 : 재훈씨 말대로 두번 사용할 이유가 없음
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
