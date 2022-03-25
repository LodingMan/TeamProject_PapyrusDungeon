using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass
{
    public int index;
    public string name;
    public int dmg;
    public int def;

    public ItemClass(int index, string name, int dmg, int def)
    {
        this.index = index;
        this.name = name;
        this.dmg = dmg;
        this.def = def;
    }
}


