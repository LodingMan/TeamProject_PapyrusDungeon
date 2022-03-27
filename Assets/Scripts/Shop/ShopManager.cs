using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class ShopManager : MonoBehaviour
{
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

    public void ItemSave() // 아직 미구현
    {

        string jdata = JsonConvert.SerializeObject(hasItemList);
        File.WriteAllText(Application.dataPath + "/ItemSave.Json", jdata);
    }
}
