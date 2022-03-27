using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour //�κ��丮 �����ۿ� �޸��� ��ũ��Ʈ�Դϴ�. 03-27 ������
{                                        //������ ��� ������ �� �̺�Ʈ ���� �����Դϴ�.
    public Item item;
    public ItemUseManager itemUseManager;
    public ItemTable itemTable = new ItemTable();
    public int itemIndex; // ������Ʈ�� �����ϱ� ���� ���� �����Դϴ�.
    public Button useBtn;


    private void Start()
    {
        itemUseManager = GameObject.Find("UIManager").GetComponent<ItemUseManager>();
        useBtn = gameObject.transform.GetChild(1).GetComponent<Button>();

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

    public void UseItem()
    {
        if (itemUseManager.name != "0")
        {
            switch (item.TargetStatus)
            {
                case "HP":
                    itemUseManager.stats.HP += item.Pram;

                    break;
                case "MP":
                    itemUseManager.stats.MP += item.Pram;
                    break;
                default:
                    break;
            }
        }

    }

}
