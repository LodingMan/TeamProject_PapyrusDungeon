using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillClass
{
    public string name;
    public int dmg;
    public int mp;
    public int cooltime;

    public SkillClass(string name, int dmg, int mp, int cooltime)
    {
        this.name = name;
        this.dmg = dmg;
        this.mp = mp;
        this.cooltime = cooltime;
    }
}
