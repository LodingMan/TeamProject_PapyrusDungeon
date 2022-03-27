using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class ShopManager : MonoBehaviour
{
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

    public void ItemSave() // ���� �̱���
    {

        string jdata = JsonConvert.SerializeObject(hasItemList);
        File.WriteAllText(Application.dataPath + "/ItemSave.Json", jdata);
    }
}
