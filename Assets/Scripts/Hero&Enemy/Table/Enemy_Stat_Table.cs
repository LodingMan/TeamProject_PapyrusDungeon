using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stat_Table 
{
    public Dictionary<int, Stat> Enemys = new Dictionary<int, Stat>()
    {
        {0, new Stat(0,"AxeDragon","", 75 , 75 , 0 , 0 ,18 , 12 , 5 , 100 , 5 , 8 )},
        {1, new Stat(0,"Beatle","", 25 , 25 , 0 , 0 , 10 , 15 , 5 , 100 , 5 , 6 )},
        {2, new Stat(0,"Golem","", 50 , 50 , 0 , 0, 15 , 20 , 5 , 100 , 5 , 3 )}
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
