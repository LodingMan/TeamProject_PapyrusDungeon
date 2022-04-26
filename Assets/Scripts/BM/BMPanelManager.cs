using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BMPanelManager : MonoBehaviour
{
    ManagerTable MgrTable;
    UI_Tweening_Manager tweenMgr;
    public Button CoinBtn;
    public Button GemBtn;
    public RectTransform CoinPanel;
    public RectTransform GemPanel;
    public Button CoinCloseBtn;
    public Button GemCloseBtn;
    // Start is called before the first frame update
    void Start()
    {
        MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
        tweenMgr = MgrTable.tweenManager;
        CoinBtn.onClick.AddListener(CoinPanel_On);
        //GemBtn.onClick.AddListener(GemPanel_On);
        //CoinCloseBtn.onClick.AddListener(CoinPanel_Off);
        //GemCloseBtn.onClick.AddListener(GemPanel_Off);
    }

    public void CoinPanel_On()
    {
        tweenMgr.isCoin = true;
        CoinPanel.DOAnchorPos(new Vector2(0, 0), 0.5f);
        tweenMgr.UIStack[tweenMgr.StackCount] = CoinPanel;
        tweenMgr.StackCount++;
    }
    public void CoinPanel_Off()
    {
        tweenMgr.StackCountFun();
    }
    public void GemPanel_On()
    {
        tweenMgr.isGem = true;
        GemPanel.DOAnchorPos(new Vector2(0, 0), 0.5f);
        tweenMgr.UIStack[tweenMgr.StackCount] = GemPanel;
        tweenMgr.StackCount++;
    }
    public void GemPanel_Off()
    {
        tweenMgr.StackCountFun();
    }
}
