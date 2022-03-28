using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;
//==================================================================================================//
// 전체적인 아이템 및 장비 저장 불러오기 스크립트입니다. 이름 변경 예정입니다. 03-28 윤성근
//==================================================================================================//

public class ShopManager : MonoBehaviour
{
    public List<Item> item = new List<Item>(); //동적 크기 할당을 위해 배열에서 리스트로 바꿨습니다. 03-27 윤성근
    public List<Equip> equip = new List<Equip>();

    public ItemScripts itemScripts;

    public GameObject itemPrefab; //생성되는 아이템 프리팹
    public GameObject equipPrefab; // 생성되는 장비 프리팹

    public List<GameObject> ShopItemList = new List<GameObject>(); //상점에 나타나는 아이템 프리팹 리스트
    public List<GameObject> itemList = new List<GameObject>(); //인벤토리에 들어올 아이템 프리팹 리스트
    public List<GameObject> equipList = new List<GameObject>(); //인벤토리에 들어올 장비 프리팹 리스트
    public List<GameObject> hasItemList = new List<GameObject>(); //가지고 있는 아이템 리스트입니다. 데이터 저장 할때 필요합니다.
    public List<GameObject> hasEquipList = new List<GameObject>(); //가지고 있는 장비 리스트입니다. 데이터 저장 할때 필요합니다.

    public GameObject inventory; // 인벤토리 패널 위치
    public GameObject shopPanel; // 상점 패널 위치

    public bool isShop = false;

    public Button BuyBtn;

    public void ItemSpawn() //상점 버튼을 눌렀을 시 아이템을 생성합니다. (나중에 랜덤으로 바꿀 예정) 03-27 윤성근
    {
        isShop = true;
        Instantiate(ShopItemList[0], shopPanel.transform);
        Instantiate(ShopItemList[1], shopPanel.transform);
    }
    public void CloseTab()
    {
        isShop = false;
    }

    public void ItemSave() // item 배열에 있는 정보를 Json에 저장합니다.
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

    public void LoadItemCreate(Item LodingItemSavingData) // 이름에 맞게 아이템을 인벤토리에 생성합니다.
    {
        switch (LodingItemSavingData.Name)
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

        hasItemList.Add(itemPrefab); // 아이템을 인벤토리 리스트에 추가합니다.

    }
    public void LoadEquipCreate(Equip LodingEquipSavingData) // 이름에 맞게 아이템을 인벤토리에 생성합니다.
    {
        switch (LodingEquipSavingData.Name)
        {
            case "Sword":
                equipPrefab = Instantiate(equipList[0]);
                equipPrefab.transform.SetParent(inventory.transform); // 인벤토리 위치에 생성을 합니다.
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

        hasEquipList.Add(equipPrefab); // 아이템을 인벤토리 리스트에 추가합니다.

    }

    public void ItemLoad() // Json파일을 불러온 다음 LoadItemCreate 함수를 실행 시킵니다.
    {
        string jdata = File.ReadAllText(Application.dataPath + "/ItemSave.Json"); //ItemSave.Json 파일에 인벤토리 아이템을 저장합니다.
        string jdata2 = File.ReadAllText(Application.dataPath + "/EquipSave.Json");
        item = JsonConvert.DeserializeObject<List<Item>>(jdata);
        equip = JsonConvert.DeserializeObject<List<Equip>>(jdata2);

        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].Name == "") // item이 배열이였을때 빈 공간까지 아이템으로 채워지는 오류가 있어서 리스트로 바꾸고, 아이템 Name에 공백이 있으면 스킵하는 방식으로 수정 하였습니다.
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
