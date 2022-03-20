using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameMgr mgr;
    public Button btn;

    private void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        btn = GameObject.FindWithTag("BuyBtn").GetComponent<Button>();
    }

    public void BuyBtn()
    {
        if (gameObject.tag == "Sword")
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(mgr.buySword);
        }
        else if (gameObject.tag == "Wood")
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(mgr.buyWood);
        }
        else if (gameObject.tag == "Bow")
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(mgr.buyBow);
        }
        else if (gameObject.tag == "Knuckle")
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(mgr.buyKnuckle);
        }
    }

}
