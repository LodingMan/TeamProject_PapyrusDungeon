using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;
//==================================================================================================//
// ��ü���� ������ �� ��� ���� �ҷ����� ��ũ��Ʈ�Դϴ�. �̸� ���� �����Դϴ�. 03-28 ������
//==================================================================================================//

public class ShopManager : MonoBehaviour
{
    public List<Item> item = new List<Item>(); //���� ũ�� �Ҵ��� ���� �迭���� ����Ʈ�� �ٲ���ϴ�. 03-27 ������
    public List<Equip> equip = new List<Equip>();

    public ItemScripts itemScripts;

    public GameObject itemPrefab; //�����Ǵ� ������ ������
    public GameObject equipPrefab; // �����Ǵ� ��� ������

    public List<GameObject> ShopItemList = new List<GameObject>(); //������ ��Ÿ���� ������ ������ ����Ʈ
    public List<GameObject> itemList = new List<GameObject>(); //�κ��丮�� ���� ������ ������ ����Ʈ
    public List<GameObject> equipList = new List<GameObject>(); //�κ��丮�� ���� ��� ������ ����Ʈ
    public List<GameObject> hasItemList = new List<GameObject>(); //������ �ִ� ������ ����Ʈ�Դϴ�. ������ ���� �Ҷ� �ʿ��մϴ�.
    public List<GameObject> hasEquipList = new List<GameObject>(); //������ �ִ� ��� ����Ʈ�Դϴ�. ������ ���� �Ҷ� �ʿ��մϴ�.

    public GameObject inventory; // �κ��丮 �г� ��ġ
    public GameObject shopPanel; // ���� �г� ��ġ

    public bool isShop = false;

    public Button BuyBtn;

    public void ItemSpawn() //���� ��ư�� ������ �� �������� �����մϴ�. (���߿� �������� �ٲ� ����) 03-27 ������
    {
        isShop = true;
        Instantiate(ShopItemList[0], shopPanel.transform);
        Instantiate(ShopItemList[1], shopPanel.transform);
    }
    public void CloseTab()
    {
        isShop = false;
    }

    public void ItemSave() // item �迭�� �ִ� ������ Json�� �����մϴ�.
    {
        for (int i = 0; i < hasItemList.Count; i++)
        {

            item[i] = hasItemList[i].GetComponent<ItemScripts>().item;

        }
        for (int i = 0; i < hasEquipList.Count; i++)
        {
            equip[i] = hasEquipList[i].GetComponent<EquipScripts_ysg>().equip;
        }

        string jdata = JsonConvert.SerializeObject(item);
        string jdata2 = JsonConvert.SerializeObject(equip);
        File.WriteAllText(Application.dataPath + "/ItemSave.Json", jdata);
        File.WriteAllText(Application.dataPath + "/EquipSave.Json", jdata2);

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
    public void LoadEquipCreate(Equip LodingEquipSavingData) // �̸��� �°� �������� �κ��丮�� �����մϴ�.
    {
        switch (LodingEquipSavingData.Name)
        {
            case "Sword":
                equipPrefab = Instantiate(equipList[0]);
                equipPrefab.transform.SetParent(inventory.transform); // �κ��丮 ��ġ�� ������ �մϴ�.
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Shield":
                equipPrefab = Instantiate(equipList[1]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;

            default:
                break;
        }

        hasEquipList.Add(equipPrefab); // �������� �κ��丮 ����Ʈ�� �߰��մϴ�.

    }

    public void ItemLoad() // Json������ �ҷ��� ���� LoadItemCreate �Լ��� ���� ��ŵ�ϴ�.
    {
        string jdata = File.ReadAllText(Application.dataPath + "/ItemSave.Json"); //ItemSave.Json ���Ͽ� �κ��丮 �������� �����մϴ�.
        string jdata2 = File.ReadAllText(Application.dataPath + "/EquipSave.Json");
        item = JsonConvert.DeserializeObject<List<Item>>(jdata);
        equip = JsonConvert.DeserializeObject<List<Equip>>(jdata2);

        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].Name == "") // item�� �迭�̿����� �� �������� ���������� ä������ ������ �־ ����Ʈ�� �ٲٰ�, ������ Name�� ������ ������ ��ŵ�ϴ� ������� ���� �Ͽ����ϴ�.
            {
                break;
            }
            LoadItemCreate(item[i]);
        }
        for (int i = 0; i < equip.Count; i++)
        {
            if (equip[i].Name == "")
            {
                break;
            }
            LoadEquipCreate(equip[i]);
        }
    }
}
