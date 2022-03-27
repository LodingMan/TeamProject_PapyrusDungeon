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
    public List<GameObject> ShopItemList = new List<GameObject>(); //상점에 나타나는 아이템 프리팹 리스트
    public List<GameObject> itemList = new List<GameObject>(); //인벤토리에 들어올 아이템 프리팹 리스트
    public List<GameObject> hasItemList = new List<GameObject>(); //가지고 있는 아이템 리스트입니다. 데이터 저장 할때 필요

    public GameObject inventory;
    public GameObject shopPanel;


    public void ItemSpawn() //상점 버튼을 눌렀을 시 아이템을 생성합니다. (나중에 랜덤으로 바꿀 예정) 03-27 윤성근
    {
        Instantiate(ShopItemList[0], shopPanel.transform);
        Instantiate(ShopItemList[1], shopPanel.transform);
    }

    public void ItemSave() // item 배열에 있는 정보를 Json에 저장합니다.
    {
        for (int i = 0; i < hasItemList.Count; i++)
        {
            item[i] = hasItemList[i].GetComponent<ItemScripts>().item;
        }

        string jdata = JsonConvert.SerializeObject(item);
        File.WriteAllText(Application.dataPath + "/ItemSave.Json", jdata);
    }

    public void LoadItemCreate(Item LodingItemSavingData) // 이름에 맞게 아이템을 인벤토리에 생성합니다.
    {
        switch (LodingItemSavingData.Name)
        {
            case "체력물약":
                itemPrefab = Instantiate(itemList[0]);
                itemPrefab.transform.SetParent(inventory.transform);
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

        hasItemList.Add(itemPrefab);

    }

    public void ItemLoad() // Json파일을 불러온 다음 LoadItemCreate 함수를 실행 시키빈다.
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
