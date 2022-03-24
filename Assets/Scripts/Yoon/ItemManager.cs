using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;


public class ItemManager : MonoBehaviour
{
    public List<ItemClass> itemData = new List<ItemClass>();
    public List<GameObject> shopPrefabs = new List<GameObject>();
    public List<GameObject> itemPrefabs = new List<GameObject>();
    public List<GameObject> hasItems = new List<GameObject>();
    public GameObject Inventory;
    public Transform ShopSlot;

    void Awake()
    {
        string itemDatas = File.ReadAllText(Application.dataPath + "/" + "Resources" + "/" + "Item.json");

        itemData = JsonConvert.DeserializeObject<List<ItemClass>>(itemDatas);
    }

}
