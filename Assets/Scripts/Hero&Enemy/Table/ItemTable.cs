using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTable
{
    public Dictionary<int, Item> Item_Dictionary = new Dictionary<int, Item>()    // 03-26 Lv �߰�
    {                                                                             // �������� �����ϰų� �����ϴ� ��ũ��Ʈ�� public ItemTable itemTable = new Item();
        {0 , new Item(0,"ü�¹���",10, 10,"HP") },                                 // mygold -= itemTable.Item_Dictionary[0].cost;
        {1 , new Item(1, "��������",10 , 10, "MP") }
       // {1, new Item() }
       
    }; 


}
