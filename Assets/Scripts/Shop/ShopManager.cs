using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class ShopManager : MonoBehaviour
{
    public Item[] item = new Item[10];
    public ItemScripts itemScripts;
    public GameObject itemPrefab;
    public List<GameObject> ShopItemList = new List<GameObject>(); //������ ��Ÿ���� ������ ������ ����Ʈ
    public List<GameObject> itemList = new List<GameObject>(); //�κ��丮�� ���� ������ ������ ����Ʈ
    public List<GameObject> hasItemList = new List<GameObject>(); //������ �ִ� ������ ����Ʈ�Դϴ�. ������ ���� �Ҷ� �ʿ�

    public GameObject inventory;
    public GameObject shopPanel;


    public void ItemSpawn() //���� ��ư�� ������ �� �������� �����մϴ�. (���߿� �������� �ٲ� ����) 03-27 ������
    {
        Instantiate(ShopItemList[0], shopPanel.transform);
        Instantiate(ShopItemList[1], shopPanel.transform);
    }

    public void ItemSave() // item �迭�� �ִ� ������ Json�� �����մϴ�.
    {
        for (int i = 0; i < hasItemList.Count; i++)
        {
            item[i] = hasItemList[i].GetComponent<ItemScripts>().item;
        }

        string jdata = JsonConvert.SerializeObject(item);
        File.WriteAllText(Application.dataPath + "/ItemSave.Json", jdata);
    }

    public void LoadItemCreate(Item LodingItemSavingData) // �̸��� �°� �������� �κ��丮�� �����մϴ�.
    {
        switch (LodingItemSavingData.Name)
        {
            case "ü�¹���":
                itemPrefab = Instantiate(itemList[0]);
                itemPrefab.transform.SetParent(inventory.transform);
                itemPrefab.transform.localPosition = inventory.transform.localPosition;
                itemPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "��������":
                itemPrefab = Instantiate(itemList[1]);
                itemPrefab.transform.SetParent(inventory.transform);
                itemPrefab.transform.localPosition = inventory.transform.localPosition;
                itemPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;

            default:
                break;
        }

        hasItemList.Add(itemPrefab);

    }

    public void ItemLoad() // Json������ �ҷ��� ���� LoadItemCreate �Լ��� ���� ��Ű���.
    {
        string jdata = File.ReadAllText(Application.dataPath + "/ItemSave.Json");
        item = JsonConvert.DeserializeObject<Item[]>(jdata);

        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] == null)
            {
                break;
            }
            LoadItemCreate(item[i]);
        }
    }
}
