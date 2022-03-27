using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripts : MonoBehaviour //인벤토리 아이템에 달리는 스크립트입니다. 03-27 윤성근
{                                        //아이템 사용 눌렀을 시 이벤트 생성 예정입니다.
    public Item item;
    public ItemTable itemTable = new ItemTable();
    public int itemIndex; // 오브젝트를 구별하기 위해 넣은 변수입니다.


    private void Start()
    {

        switch (gameObject.name) // 현재 오브젝트의 이름을 찾아서 그에 맞는 함수를 호출합니다.
        {
            case "HP_POTION(Clone)":
                itemIndex = 0;
                ItemParamInit();

                break;

            case "MP_POTION(Clone)":
                itemIndex = 1;
                ItemParamInit();

                break;


            default:
                break;
        }


    }
    public void ItemParamInit() //itemTable에 있는 정보를 가져옵니다.
    {
        item.Index = itemTable.Item_Dictionary[itemIndex].Index;
        item.Name = itemTable.Item_Dictionary[itemIndex].Name;
        item.Pram = itemTable.Item_Dictionary[itemIndex].Pram;
        item.cost = itemTable.Item_Dictionary[itemIndex].cost;
        item.TargetStatus = itemTable.Item_Dictionary[itemIndex].TargetStatus;
        gameObject.name = item.Name;
    }



}
