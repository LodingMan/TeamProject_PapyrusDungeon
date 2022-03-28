using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour //�κ��丮 �����ۿ� �޸��� ��ũ��Ʈ�Դϴ�. 03-27 ������
{                                        //������ ��� ������ �� �̺�Ʈ�� �����մϴ�.
    public Item item;
    public ItemUseManager itemUseManager;
    public ShopManager shopManager;
    public ItemTable itemTable = new ItemTable();
    public int itemIndex; // ������Ʈ�� �����ϱ� ���� ���� �����Դϴ�.
    public bool isUsed = false;



    private void Start()
    {
        itemUseManager = GameObject.Find("UIManager").GetComponent<ItemUseManager>();
        shopManager = GameObject.Find("UIManager").GetComponent<ShopManager>();


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
                    isUsed = true; // ������ ��� ���� üũ
                    itemUseManager.stats.HP += item.Pram; // ���õ� ������Ʈ�� HP���� ���� �����ݴϴ�. �������� itemTable�� �ִ� ��ġ�� ������� �մϴ�.
                    itemUseManager.isActive = false; // �ߺ� Ŭ�� ������ ���� �־����ϴ�.
                    itemUseManager.stats = null; // ������ ��� �� ������ �����͸� �����մϴ�.
                    for (int i = shopManager.hasItemList.Count -1; i >= 0; i--) //������ ��� �� ����Ʈ�� �ִ� ������Ʈ ���� �� �ߺ����� �����Ǵ°� ���� �ϱ� ���� ���� 03-28 ������
                    {
                        if (shopManager.hasItemList[i].GetComponent<ItemScripts>().isUsed)
                        {
                            shopManager.hasItemList.RemoveAt(i);
                        }
                    }
                    Destroy(gameObject);

                }

                    break;
                case "MP":
                if (itemUseManager.isActive)
                {
                    isUsed = true;
                    itemUseManager.stats.MP += item.Pram;
                    itemUseManager.isActive = false;
                    itemUseManager.stats = null;
                    for (int i = shopManager.hasItemList.Count - 1; i >= 0; i--)
                    {
                        if (shopManager.hasItemList[i].GetComponent<ItemScripts>().isUsed)
                        {
                            shopManager.hasItemList.RemoveAt(i);
                        }
                    }
                    Destroy(gameObject);

                }

                break;
                default:
                    break;
            }
        

    }

}
