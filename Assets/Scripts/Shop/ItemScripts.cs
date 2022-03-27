using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScripts : MonoBehaviour //�κ��丮 �����ۿ� �޸��� ��ũ��Ʈ�Դϴ�. 03-27 ������
{                                        //������ ��� ������ �� �̺�Ʈ ���� �����Դϴ�.
    public Item item;
    public ItemTable itemTable = new ItemTable();
    public int itemIndex; // ������Ʈ�� �����ϱ� ���� ���� �����Դϴ�.


    private void Start()
    {

        switch (gameObject.name) // ���� ������Ʈ�� �̸��� ã�Ƽ� �׿� �´� �Լ��� ȣ���մϴ�.
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
    public void ItemParamInit() //itemTable�� �ִ� ������ �����ɴϴ�.
    {
        item.Index = itemTable.Item_Dictionary[itemIndex].Index;
        item.Name = itemTable.Item_Dictionary[itemIndex].Name;
        item.Pram = itemTable.Item_Dictionary[itemIndex].Pram;
        item.cost = itemTable.Item_Dictionary[itemIndex].cost;
        item.TargetStatus = itemTable.Item_Dictionary[itemIndex].TargetStatus;
        gameObject.name = item.Name;
    }



}
