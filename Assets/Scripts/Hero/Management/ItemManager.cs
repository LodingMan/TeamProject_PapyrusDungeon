using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public ItemTable itemTable = new ItemTable();

    public List<GameObject> itemPrefabs = new List<GameObject>();


    private void Start()
    {
        switch (gameObject.tag)
        {
            case "HP":
                

                break;

            case "MP":

                break;

            default:
                break;
        }
    }

}
