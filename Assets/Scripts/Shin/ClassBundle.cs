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

public class HeroClass //Hero오브젝트 생성시 가지게 될 파라미터
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

    public HeroClass(int index, string name, string job, int lv, int hp, int mp, int atk, int def, int cri, int acc, int agi,
        string weapon, string armor, string skill01, string skill02, string skill03, string skill04, string skill05)
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
}

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

public class EnemyClass // Enemy생성시 가지게 될 파라미터
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


