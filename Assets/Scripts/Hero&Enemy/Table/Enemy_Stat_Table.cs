using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stat_Table 
{
    public Dictionary<int, Stat> Enemys = new Dictionary<int, Stat>()
    {
        {0, new Stat(0,"AxeDragon","", 5 , 5 , 0 , 0 ,5 , 5 , 5 , 100 , 5 , 5 )},
        {1, new Stat(0,"Beatle","", 5 , 5 , 0 , 0 , 5 , 5 , 5 , 100 , 5 , 5 )},
        {2, new Stat(0,"Golem","", 5 , 5 , 0 , 0, 5 , 5 , 5 , 100 , 5 , 5 )}
    };

}

public class Enemy_Sequence_Table
{
    public Dictionary<int, int[]> Enemy_Sequence = new Dictionary<int, int[]>()
    {
        {0, new int[3]{0,1,2} },  //슬라임, 늑대 고블린
        {1, new int[2]{1,2} }
    };

}
