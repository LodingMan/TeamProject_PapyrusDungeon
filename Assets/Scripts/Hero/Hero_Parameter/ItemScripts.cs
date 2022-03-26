using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripts : MonoBehaviour
{
    public Item item;
    public ItemTable itemTable = new ItemTable();
    public int i; // ������Ʈ�� �����ϱ� ���� ���� ����


    private void Start()
    {

        switch (gameObject.name) // ���� ������Ʈ�� �̸��� ã�Ƽ� �׿� �´� ������ ����
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
    public void ItemParamInit() // ���� ���
    {
        item.Index = itemTable.Item_Dictionary[i].Index;
        item.Name = itemTable.Item_Dictionary[i].Name;
        item.Pram = itemTable.Item_Dictionary[i].Pram;
        item.cost = itemTable.Item_Dictionary[i].cost;
        item.TargetStatus = itemTable.Item_Dictionary[i].TargetStatus;
    }



}
