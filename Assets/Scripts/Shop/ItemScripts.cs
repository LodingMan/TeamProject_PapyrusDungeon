using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour //�κ��丮 �����ۿ� �޸��� ��ũ��Ʈ�Դϴ�. 03-27 ������
{                                        //������ ��� ������ �� �̺�Ʈ�� �����մϴ�.
    public Item item;
    public ItemUseManager itemUseManager;
    public ItemTable itemTable = new ItemTable();
    public int itemIndex; // ������Ʈ�� �����ϱ� ���� ���� �����Դϴ�.



    private void Start()
    {
        itemUseManager = GameObject.Find("UIManager").GetComponent<ItemUseManager>();


        switch (gameObject.name) // ���� ������Ʈ�� �̸��� ã�Ƽ� �׿� �´� ������ �������� �Լ��� �����մϴ�.
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
    public void ItemParamInit() //itemTable�� �ִ� ������ �����ɴϴ�. ������ itemIndex�� �ִ� Index�� ������� �����ɴϴ�.
    {
        item.Index = itemTable.Item_Dictionary[itemIndex].Index;
        item.Name = itemTable.Item_Dictionary[itemIndex].Name;
        item.Pram = itemTable.Item_Dictionary[itemIndex].Pram;
        item.cost = itemTable.Item_Dictionary[itemIndex].cost;
        item.TargetStatus = itemTable.Item_Dictionary[itemIndex].TargetStatus;
        gameObject.name = item.Name;
    }

    public void UseItem() // ������ ��� �� UIManager�� �ִ� ������ �����մϴ�.
    {

            switch (item.TargetStatus)
            {
                case "HP":
                if (itemUseManager.isActive) // ������Ʈ�� ���õǾ���� ������ �����ϰ� ��������ϴ�.
                {
                    itemUseManager.stats.HP += item.Pram; // ���õ� ������Ʈ�� HP���� ���� �����ݴϴ�. �������� itemTable�� �ִ� ��ġ�� ������� �մϴ�.
                    itemUseManager.isActive = false; // �ߺ� Ŭ�� ������ ���� �־����ϴ�.
                    itemUseManager.stats = null; // ������ ��� �� ������ �����͸� �����մϴ�.
                    Destroy(gameObject);

                }

                    break;
                case "MP":
                if (itemUseManager.isActive)
                {
                    itemUseManager.stats.MP += item.Pram;
                    itemUseManager.isActive = false;
                    itemUseManager.stats = null;
                    Destroy(gameObject);

                }

                break;
                default:
                    break;
            }
        

    }

}
