using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTable
{
    public Dictionary<int, Item> Item_Dictionary = new Dictionary<int, Item>()    // 03-26 Lv 추가
    {                                                                             // 아이템을 생성하거나 제어하는 스크립트는 public ItemTable itemTable = new Item();
        {0 , new Item(0,"체력물약",10, 10,"HP") },                                 // mygold -= itemTable.Item_Dictionary[0].cost;
        {1 , new Item(1, "마나물약",10 , 10, "MP") }
       // {1, new Item() }
       
    }; 


}
