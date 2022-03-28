using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour //인벤토리 아이템에 달리는 스크립트입니다. 03-27 윤성근
{                                        //아이템 사용 눌렀을 시 이벤트를 실행합니다.
    public Item item;
    public ItemUseManager itemUseManager;
    public ShopManager shopManager;
    public ItemTable itemTable = new ItemTable();
    public int itemIndex; // 오브젝트를 구별하기 위해 넣은 변수입니다.
    public bool isUsed = false;



    private void Start()
    {
        itemUseManager = GameObject.Find("UIManager").GetComponent<ItemUseManager>();
        shopManager = GameObject.Find("UIManager").GetComponent<ShopManager>();


        switch (gameObject.name) // 현재 오브젝트의 이름을 찾아서 그에 맞는 정보를 가져오는 함수를 실행합니다.
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
    public void ItemParamInit() //itemTable에 있는 정보를 가져옵니다. 정보는 itemIndex에 있는 Index를 기반으로 가져옵니다.
    {
        item.Index = itemTable.Item_Dictionary[itemIndex].Index;
        item.Name = itemTable.Item_Dictionary[itemIndex].Name;
        item.Pram = itemTable.Item_Dictionary[itemIndex].Pram;
        item.cost = itemTable.Item_Dictionary[itemIndex].cost;
        item.TargetStatus = itemTable.Item_Dictionary[itemIndex].TargetStatus;
        gameObject.name = item.Name;
    }

    public void UseItem() // 아이템 사용 시 UIManager에 있는 정보를 수정합니다.
    {

             switch (item.TargetStatus)
                {
                case "HP":
                if (itemUseManager.isActive) // 오브젝트가 선택되어야지 실행이 가능하게 만들었습니다.
                {
                    isUsed = true; // 아이템 사용 유무 체크
                    itemUseManager.stats.HP += item.Pram; // 선택된 오브젝트의 HP값을 증가 시켜줍니다. 증가값은 itemTable에 있는 수치를 기반으로 합니다.
                    itemUseManager.isActive = false; // 중복 클릭 방지를 위해 넣었습니다.
                    itemUseManager.stats = null; // 아이템 사용 후 가비지 데이터를 제거합니다.
                    for (int i = shopManager.hasItemList.Count -1; i >= 0; i--) //아이템 사용 후 리스트에 있는 오브젝트 삭제 시 중복으로 삭제되는걸 방지 하기 위해 넣음 03-28 윤성근
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
