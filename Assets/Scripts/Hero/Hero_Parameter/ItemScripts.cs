using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripts : MonoBehaviour
{
    public Item item;
    public ItemTable itemTable = new ItemTable();
    public int i; // 오브젝트를 구별하기 위해 넣은 변수


    private void Start()
    {

        switch (gameObject.name) // 현재 오브젝트의 이름을 찾아서 그에 맞는 정보를 기입
        {
            case "HP_POTION":
                i = 0;
                ItemParamInit();

                break;

            case "MP_POTION":
                i = 1;
                ItemParamInit();

                break;


            default:
                break;
        }


    }
    public void ItemParamInit() // 정보 목록
    {
        item.Index = itemTable.Item_Dictionary[i].Index;
        item.Name = itemTable.Item_Dictionary[i].Name;
        item.Pram = itemTable.Item_Dictionary[i].Pram;
        item.cost = itemTable.Item_Dictionary[i].cost;
        item.TargetStatus = itemTable.Item_Dictionary[i].TargetStatus;
    }



}
