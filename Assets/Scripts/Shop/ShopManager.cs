using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//==================================================================================================//
// 전체적인 아이템 및 장비 저장 불러오기 스크립트입니다. 이름 변경 예정입니다. 03-29 윤성근
//==================================================================================================//

public class ShopManager : MonoBehaviour
{
    public List<Item> item = new List<Item>(); //동적 크기 할당을 위해 배열에서 리스트로 바꿨습니다. 03-27 윤성근
    public List<Equip> equip = new List<Equip>();

    public ItemScripts itemScripts;

    public GameObject itemPrefab; //생성되는 아이템 프리팹
    public GameObject equipPrefab; // 생성되는 장비 프리팹

    public List<GameObject> ShopItemList = new List<GameObject>(); //상점에 나타나는 아이템 프리팹 리스트
    public List<GameObject> shopEquipList = new List<GameObject>();
    public List<GameObject> itemList = new List<GameObject>(); //인벤토리에 들어올 아이템 프리팹 리스트
    public List<GameObject> equipList = new List<GameObject>(); //인벤토리에 들어올 장비 프리팹 리스트
    public List<GameObject> hasItemList = new List<GameObject>(); //가지고 있는 아이템 리스트입니다. 데이터 저장 할때 필요합니다.
    public List<GameObject> hasEquipList = new List<GameObject>(); //가지고 있는 장비 리스트입니다. 데이터 저장 할때 필요합니다.
    public List<EquipSavingData> equipSavingDatas = new List<EquipSavingData>(); //무기, 장비 데이터를 저장 할때 필요합니다.
    public List<ItemSavingData> itemSavingDatas = new List<ItemSavingData>(); //아이템 저장 할때 필요합니다.
    public string textData = null;


    public GameObject inventory; // 인벤토리 패널 위치
    public GameObject shopPanel; // 상점 패널 위치

    public int money = 0;
    public bool isShop = false; // 상점이 열려있는지 확인하는 bool값입니다.

    public Button BuyBtn; // 구매 버튼

    public Text popupText;


    public void IsShop()
    {
        isShop = true;

    }
    public void ItemSpawn() //상점 버튼을 눌렀을 시 아이템을 생성합니다. (나중에 랜덤으로 바꿀 예정) 03-27 윤성근
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



    public void CloseTab() // 상점이나 인벤토리 탭을 닫으면 아이템의 사용 버튼을 숨겨줍니다.
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

    public void ItemSave() // item 배열에 있는 정보를 Json에 저장합니다.
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
    public void SellItemSave() // item 배열에 있는 정보를 Json에 저장합니다.
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

    public void LoadItemCreate(ItemSavingData LodingItemSavingData) // 이름에 맞게 아이템을 인벤토리에 생성합니다.
    {
        switch (LodingItemSavingData.item.Name)
        {
            case "체력물약":
                itemPrefab = Instantiate(itemList[0]);
                itemPrefab.transform.SetParent(inventory.transform); // 인벤토리 위치에 생성을 합니다.
                itemPrefab.transform.localPosition = inventory.transform.localPosition;
                itemPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "마나물약":
                itemPrefab = Instantiate(itemList[1]);
                itemPrefab.transform.SetParent(inventory.transform);
                itemPrefab.transform.localPosition = inventory.transform.localPosition;
                itemPrefab.transform.localScale = new Vector3(1, 1, 1);
                break;

            default:
                break;
        }
        itemPrefab.GetComponent<ItemDataSave>().itemSavingData.item = LodingItemSavingData.item;
        hasItemList.Add(itemPrefab); // 아이템을 인벤토리 리스트에 추가합니다.

    }
    public void LoadEquipCreate(EquipSavingData LodingEquipSavingData) // 이름에 맞게 아이템을 인벤토리에 생성합니다.
    {
        switch (LodingEquipSavingData.equip.Name)
        {
            case "Sword":
                equipPrefab = Instantiate(equipList[1]);
                equipPrefab.transform.SetParent(inventory.transform); // 인벤토리 위치에 생성을 합니다.
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

        hasEquipList.Add(equipPrefab); // 아이템을 인벤토리 리스트에 추가합니다.

    }

    public void ItemLoad() // Json파일을 불러온 다음 LoadItemCreate 함수를 실행 시킵니다.
    {

        string jdata = File.ReadAllText(Application.persistentDataPath + "/Resources/ItemSave.Json"); //ItemSave.Json 파일에 인벤토리 아이템을 저장합니다.
        string jdata2 = File.ReadAllText(Application.persistentDataPath + "/Resources/EquipSave.Json");
        itemSavingDatas = JsonConvert.DeserializeObject<List<ItemSavingData>>(jdata);
        equipSavingDatas = JsonConvert.DeserializeObject<List<EquipSavingData>>(jdata2);

        if (jdata != "null" && jdata2 != "null")
        {
            for (int i = 0; i < itemSavingDatas.Count; i++)
            {
                if (itemSavingDatas[i].item.Name == "") // item이 배열이였을때 빈 공간까지 아이템으로 채워지는 오류가 있어서 리스트로 바꾸고, 아이템 Name에 공백이 있으면 스킵하는 방식으로 수정 하였습니다.
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
        popupText.text = "재화가 부족합니다!";
        popupText.transform.DOLocalMove(new Vector3(0, 300, 0), 1f);
        yield return new WaitForSeconds(1f);
        popupText.transform.DOLocalMove(new Vector3(0, 450, 0), 1f);
    }
}
