using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//==================================================================================================//
// ��ü���� ������ �� ��� ���� �ҷ����� ��ũ��Ʈ�Դϴ�. �̸� ���� �����Դϴ�. 03-29 ������
//==================================================================================================//

public class ShopManager : MonoBehaviour
{
    public List<Item> item = new List<Item>(); //���� ũ�� �Ҵ��� ���� �迭���� ����Ʈ�� �ٲ���ϴ�. 03-27 ������
    public List<Equip> equip = new List<Equip>();

    public ItemScripts itemScripts;

    public GameObject itemPrefab; //�����Ǵ� ������ ������
    public GameObject equipPrefab; // �����Ǵ� ��� ������

    public List<GameObject> ShopItemList = new List<GameObject>(); //������ ��Ÿ���� ������ ������ ����Ʈ
    public List<GameObject> shopEquipList = new List<GameObject>();
    public List<GameObject> itemList = new List<GameObject>(); //�κ��丮�� ���� ������ ������ ����Ʈ
    public List<GameObject> equipList = new List<GameObject>(); //�κ��丮�� ���� ��� ������ ����Ʈ
    public List<GameObject> hasItemList = new List<GameObject>(); //������ �ִ� ������ ����Ʈ�Դϴ�. ������ ���� �Ҷ� �ʿ��մϴ�.
    public List<GameObject> hasEquipList = new List<GameObject>(); //������ �ִ� ��� ����Ʈ�Դϴ�. ������ ���� �Ҷ� �ʿ��մϴ�.
    public List<EquipSavingData> equipSavingDatas = new List<EquipSavingData>(); //����, ��� �����͸� ���� �Ҷ� �ʿ��մϴ�.
    public List<ItemSavingData> itemSavingDatas = new List<ItemSavingData>(); //������ ���� �Ҷ� �ʿ��մϴ�.
    public string textData = null;


    public GameObject inventory; // �κ��丮 �г� ��ġ
    public GameObject shopPanel; // ���� �г� ��ġ

    public int money = 0;
    public bool isShop = false; // ������ �����ִ��� Ȯ���ϴ� bool���Դϴ�.

    public Button BuyBtn; // ���� ��ư

    public Text popupText;


    public void IsShop()
    {
        isShop = true;

    }
    public void ItemSpawn() //���� ��ư�� ������ �� �������� �����մϴ�. (���߿� �������� �ٲ� ����) 03-27 ������
    {
        for (int i = 0; i < shopPanel.transform.childCount; i++)
        {
            if (shopPanel.transform.GetChild(i).tag == "Equip")
            {
                Destroy(shopPanel.transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            int rnd = Random.Range(0, shopEquipList.Count);
            Instantiate(shopEquipList[rnd], shopPanel.transform);
        }

    }



    public void CloseTab() // �����̳� �κ��丮 ���� ������ �������� ��� ��ư�� �����ݴϴ�.
    {
        isShop = false;
        for (int i = 0; i < hasItemList.Count; i++)
        {
            if (hasItemList != null)
            {
                hasItemList[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < hasEquipList.Count; i++)
        {
            if (hasEquipList != null)
            {

                hasEquipList[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void ItemSave() // item �迭�� �ִ� ������ Json�� �����մϴ�.
    {
        for (int i = 0; i < hasItemList.Count; i++)
        {
            if (itemSavingDatas != null)
            {
                itemSavingDatas.Clear();
            }

            for (int f = 0; f < hasItemList.Count; f++)
            {
                itemSavingDatas.Add(hasItemList[f].GetComponent<ItemDataSave>().itemSavingData);
            }


        }
        for (int j = 0; j < hasEquipList.Count; j++)
        {
            if (equipSavingDatas != null)
            {
                equipSavingDatas.Clear();
            }
            for (int k = 0; k < hasEquipList.Count; k++)
            {
                equipSavingDatas.Add(hasEquipList[k].GetComponent<EquipDataSave>().equipSavingData);
            }
        }

        if (!Directory.Exists(Application.persistentDataPath + "/Resources"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Resources");
        }

        string jdata = JsonConvert.SerializeObject(itemSavingDatas);
        string jdata2 = JsonConvert.SerializeObject(equipSavingDatas);
        File.WriteAllText(Application.persistentDataPath + "/Resources/ItemSave.Json", jdata);
        File.WriteAllText(Application.persistentDataPath + "/Resources/EquipSave.Json", jdata2);


    }
    public void SellItemSave() // item �迭�� �ִ� ������ Json�� �����մϴ�.
    {

        itemSavingDatas.Clear();

        equipSavingDatas.Clear();


        if (!Directory.Exists(Application.persistentDataPath + "/Resources"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Resources");
        }

        string jdata = JsonConvert.SerializeObject(itemSavingDatas);
        string jdata2 = JsonConvert.SerializeObject(equipSavingDatas);
        File.WriteAllText(Application.persistentDataPath + "/Resources/ItemSave.Json", jdata);
        File.WriteAllText(Application.persistentDataPath + "/Resources/EquipSave.Json", jdata2);

    }

    public void LoadItemCreate(ItemSavingData LodingItemSavingData) // �̸��� �°� �������� �κ��丮�� �����մϴ�.
    {
        switch (LodingItemSavingData.item.Name)
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
        itemPrefab.GetComponent<ItemDataSave>().itemSavingData.item = LodingItemSavingData.item;
        hasItemList.Add(itemPrefab); // �������� �κ��丮 ����Ʈ�� �߰��մϴ�.

    }
    public void LoadEquipCreate(EquipSavingData LodingEquipSavingData) // �̸��� �°� �������� �κ��丮�� �����մϴ�.
    {
        switch (LodingEquipSavingData.equip.Name)
        {
            case "Sword":
                equipPrefab = Instantiate(equipList[1]);
                equipPrefab.transform.SetParent(inventory.transform); // �κ��丮 ��ġ�� ������ �մϴ�.
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Axe":
                equipPrefab = Instantiate(equipList[2]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Bow":
                equipPrefab = Instantiate(equipList[3]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Knife":
                equipPrefab = Instantiate(equipList[4]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "DoubleAxe":
                equipPrefab = Instantiate(equipList[5]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Saber":
                equipPrefab = Instantiate(equipList[6]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Wand":
                equipPrefab = Instantiate(equipList[7]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Amulet1":
                equipPrefab = Instantiate(equipList[8]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Amulet2":
                equipPrefab = Instantiate(equipList[9]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Amulet3":
                equipPrefab = Instantiate(equipList[10]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Armor1":
                equipPrefab = Instantiate(equipList[11]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Armor2":
                equipPrefab = Instantiate(equipList[12]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Boot1":
                equipPrefab = Instantiate(equipList[13]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Boot2":
                equipPrefab = Instantiate(equipList[14]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Boot3":
                equipPrefab = Instantiate(equipList[15]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Armor3":
                equipPrefab = Instantiate(equipList[16]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Armor4":
                equipPrefab = Instantiate(equipList[17]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Glove1":
                equipPrefab = Instantiate(equipList[18]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Glove2":
                equipPrefab = Instantiate(equipList[19]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Armor5":
                equipPrefab = Instantiate(equipList[20]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Helmet1":
                equipPrefab = Instantiate(equipList[21]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Helmet2":
                equipPrefab = Instantiate(equipList[22]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Helmet3":
                equipPrefab = Instantiate(equipList[23]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Ring1":
                equipPrefab = Instantiate(equipList[24]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Ring2":
                equipPrefab = Instantiate(equipList[25]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "Shield":
                equipPrefab = Instantiate(equipList[26]);
                equipPrefab.transform.SetParent(inventory.transform);
                equipPrefab.transform.localPosition = inventory.transform.localPosition;
                equipPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                break;
        }

        equipPrefab.GetComponent<EquipDataSave>().equipSavingData.equip = LodingEquipSavingData.equip;
        equipPrefab.GetComponent<EquipScripts_ysg>().equip = LodingEquipSavingData.equip;

        hasEquipList.Add(equipPrefab); // �������� �κ��丮 ����Ʈ�� �߰��մϴ�.

    }

    public void ItemLoad() // Json������ �ҷ��� ���� LoadItemCreate �Լ��� ���� ��ŵ�ϴ�.
    {

        string jdata = File.ReadAllText(Application.persistentDataPath + "/Resources/ItemSave.Json"); //ItemSave.Json ���Ͽ� �κ��丮 �������� �����մϴ�.
        string jdata2 = File.ReadAllText(Application.persistentDataPath + "/Resources/EquipSave.Json");
        itemSavingDatas = JsonConvert.DeserializeObject<List<ItemSavingData>>(jdata);
        equipSavingDatas = JsonConvert.DeserializeObject<List<EquipSavingData>>(jdata2);

        if (jdata != "null" && jdata2 != "null")
        {
            for (int i = 0; i < itemSavingDatas.Count; i++)
            {
                if (itemSavingDatas[i].item.Name == "") // item�� �迭�̿����� �� �������� ���������� ä������ ������ �־ ����Ʈ�� �ٲٰ�, ������ Name�� ������ ������ ��ŵ�ϴ� ������� ���� �Ͽ����ϴ�.
                {
                    break;
                }

                LoadItemCreate(itemSavingDatas[i]);

            }
            for (int i = 0; i < equipSavingDatas.Count; i++)
            {
                if (equipSavingDatas[i].equip.Name == "")
                {
                    break;
                }
                LoadEquipCreate(equipSavingDatas[i]);

            }
        }



    }

    public void WipeInventory()
    {
        StartCoroutine(WipeInventoryCo());
        if (File.Exists(Application.persistentDataPath + "/Resources/ItemSave.Json") && File.Exists(Application.persistentDataPath + "/Resources/EquipSave.Json"))
        {
            ItemLoad();
        }


    }

    IEnumerator WipeInventoryCo()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Resources"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Resources");
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
    }


    public void NotEnoughMoney()
    {
        StartCoroutine(MoneyDelay());
    }

    IEnumerator MoneyDelay()
    {
        popupText.text = "��ȭ�� �����մϴ�!";
        popupText.transform.DOLocalMove(new Vector3(0, 300, 0), 1f);
        yield return new WaitForSeconds(1f);
        popupText.transform.DOLocalMove(new Vector3(0, 450, 0), 1f);
    }
}
