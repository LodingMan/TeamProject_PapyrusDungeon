using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class ShopManager : MonoBehaviour
{
    public List<Item> item = new List<Item>(); //���� ũ�� �Ҵ��� ���� �迭���� ����Ʈ�� �ٲ���ϴ�. 03-27 ������
    public ItemScripts itemScripts;
    public GameObject itemPrefab;
    public List<GameObject> ShopItemList = new List<GameObject>(); //������ ��Ÿ���� ������ ������ ����Ʈ
    public List<GameObject> itemList = new List<GameObject>(); //�κ��丮�� ���� ������ ������ ����Ʈ
    public List<GameObject> hasItemList = new List<GameObject>(); //������ �ִ� ������ ����Ʈ�Դϴ�. ������ ���� �Ҷ� �ʿ��մϴ�.

    public GameObject inventory; // �κ��丮 �г� ��ġ
    public GameObject shopPanel; // ���� �г� ��ġ


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
                itemPrefab.transform.SetParent(inventory.transform); // �κ��丮 ��ġ�� ������ �մϴ�.
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

        hasItemList.Add(itemPrefab); // �������� �κ��丮 ����Ʈ�� �߰��մϴ�.

    }

    public void ItemLoad() // Json������ �ҷ��� ���� LoadItemCreate �Լ��� ���� ��ŵ�ϴ�.
    {
        string jdata = File.ReadAllText(Application.dataPath + "/ItemSave.Json"); //ItemSave.Json ���Ͽ� �κ��丮 �������� �����մϴ�.
        item = JsonConvert.DeserializeObject<List<Item>>(jdata);

        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].Name == "" ) // item�� �迭�̿����� �� �������� ���������� ä������ ������ �־ ����Ʈ�� �ٲٰ�, ������ Name�� ������ ������ ��ŵ�ϴ� ������� ���� �Ͽ����ϴ�.
            {
                break;
            }
            LoadItemCreate(item[i]);
        }
    }
}
