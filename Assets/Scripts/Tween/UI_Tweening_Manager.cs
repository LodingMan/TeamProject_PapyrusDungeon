using DG.Tweening;
using System.Collections;
using UnityEngine;
//==================================================================================================//
//UI�� �������� Tween���� ��Ʈ�� �Ҷ� TweenManager������Ʈ�� �� ������Ʈ�� �ְ� ���� (Stage �������� ���)//
//==================================================================================================//
public class UI_Tweening_Manager : MonoBehaviour
{
    public TownManager townMgr;
    public ManagerTable MgrTable;
    public RectTransform UI_guildPanelPos;
    public RectTransform UI_StatusPanelPos;
    public RectTransform UI_StatusPanel_Tent_Pos;
    public RectTransform UI_DungeonSelectPanelPos;
    public RectTransform UI_churchPanelPos;
    public RectTransform UI_trainingPanelPos;
    public RectTransform UI_trainingSecPanelPos;
    public RectTransform UI_shopPanelPos;
    public RectTransform UI_inventoryPanelPos;
    public RectTransform UI_smithPanelPos;
    public RectTransform UI_inventoryPanel_TentPos;
    public RectTransform UI_BackGround_Pos;
    public RectTransform UI_DunGeonEntrance_Pos;
    public RectTransform UI_loadingPanel_Pos;
    public RectTransform UI_ChurchWarning_Pos;
    public RectTransform UI_TrainWarning_Pos;
    public RectTransform UI_Option_Pos;
    public RectTransform UI_Tent_Option_Pos;
    public RectTransform UI_QuitPanel_Pos;
    public RectTransform UI_EquipInfo_Pos;
    //public RectTransform UI_BM_Panel;
    public GameObject blackscreen;
    public CameraMoving camMove;

    public bool UI_isBackground_On = true;
    //bool UI_isGuildPanel_On = false;
    //bool UI_isChurchPanel_On = false;
    //bool UI_isTrainingPanel_On = false;
    //bool UI_isTrainingSecPanel_On = false;
    //bool UI_isShopPanel_On = false;
    //bool UI_isInventoryPanel_On = false;
    //bool UI_isSmithPanel_On = false;
    public bool UI_isStatusPanel_On = false;

    // shin
    /*public bool isTownOn = false;
    public bool isTentOn = false; 
    public bool isCombatOn = false;*/
    public bool isTuto = false;
    public bool isGuild = false;
    public bool isShop = false;
    public bool isSmith = false;
    public bool isChurch = false;
    public bool isTrain = false;
    public bool isTrainDetail = false;
    public bool isOption = false;
    public bool isBM = false;
    public bool isCoin = false;
    public bool isGem = false;
    public bool isTentOption = false;
    public bool isTentStatus = false;

    public ShopManager shopMgr;
    public SmithManager smithMgr;
    public GameObject tentInven;
    public GameObject originInven;

    public RectTransform[] UIStack = new RectTransform[4];
    public int StackCount = 0;
    public Shin.UI_DungeonInitButton uI_DungeonInitButton;
    public Shin.UI_ChurchManager uI_ChurchManager;
    public Shin.UI_TrainingManager uI_TrainingManager;
    public GameObject option_Btn;
    public RewardAds adsMgr;


    private void Start()
    {
        BlackScreenUnenabled();
    }
    private void Update()
    {
        if (!isTuto)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                adsMgr.OnDestroy();
                if (townMgr.isTent == true)
                {
                    if (StackCount == 0)
                    {
                        if (uI_DungeonInitButton.canvas_Tent.activeSelf)
                        {
                            uI_DungeonInitButton.canvas_Tent.SetActive(false);
                        }
                        UI_loadingPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
                        StartCoroutine(uI_DungeonInitButton.TweenLoadingPanelToTown());
                        TentInvenToOriginInven();
                        BlackScreenUnenabled();
                        // 텐트에서 아무 Stack도 없는 상태에서 esc누르면 마을 캔버스로 돌아감.
                    }
                    else
                    {
                        if (!isTentOption)
                        {
                            if (isTentStatus)
                            {
                                isTentStatus = false;
                            }
                            else
                            {
                                if (!MgrTable.itemUseMgr.TentText01.gameObject.activeSelf)
                                    MgrTable.itemUseMgr.TentText01.gameObject.SetActive(true);
                            }

                        }
                    }
                    if (isTentOption)
                        isTentOption = false;

                }
                if (townMgr.isTown == true)
                {
                    if (isOption == false)
                    {
                        if (isShop)
                        {
                            isShop = false;
                            shopMgr.isShop = false;
                            InvenSellRefresh();
                            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
                        }
                        if (isSmith)
                        {
                            isSmith = false;
                            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
                        }
                        if (isGuild)
                        {
                            isGuild = false;
                        }
                        if (isChurch)
                        {
                            isChurch = false;
                            uI_ChurchManager.EmployedDestroy_UI();
                            uI_ChurchManager.isWarning = false;
                        }
                        if (isTrain)
                        {
                            if (isTrainDetail)
                            {
                                uI_TrainingManager.EmployedDestroy_UI();
                                uI_TrainingManager.EmployedInit_UI();
                                isTrainDetail = false;
                            }
                            else
                            {
                                uI_TrainingManager.isWarning = false;
                                uI_TrainingManager.EmployedDestroy_UI();
                                isTrain = false;
                            }
                        }
                        if (townMgr.isInven)
                        {
                            townMgr.isInven = false;
                            townMgr.equipInfoCanvus.SetActive(false);
                        }
                    }
                    else // 옵션이 켜져있는 상태
                    {
                        isOption = false;
                    }

                    if (!isTrainDetail)
                        option_Btn.SetActive(true);
                }
                StackCountFun();
            }
        }
        else
        {
            if (townMgr.Week == 1)
            {
                if (isGuild && Input.GetKeyDown(KeyCode.Escape))
                {
                    if (MgrTable.TutorialMgr.guildTuto[3])
                    {
                        isGuild = false;
                        MgrTable.TutorialMgr.GuildTuto03Off();
                        StackCountFun();
                    }

                }
            }
        }

        //if (UI_isBackground_On == true)
        //{
        //    if (!isOption)
        //    {
        //        UI_BM_Panel.DOAnchorPos(new Vector2(0, 0), 0.5f);
        //        isBM = true;
        //    }
        //    if (isOption)
        //    {
        //        UI_BM_Panel.DOAnchorPos(new Vector2(-1500, 0), 0.5f);
        //        isBM = false;
        //    }
        //}
        //else
        //{
        //    UI_BM_Panel.DOAnchorPos(new Vector2(-1500, 0), 0.5f);
        //    isBM = false;
        //}

        //if (isBM)
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        if (isCoin)
        //        {
        //            isCoin = false;
        //        }
        //        if (isGem)
        //        {
        //            isGem = false;
        //        }
        //    }
        //}
    }

    public void StackCountFun()
    {
        if (StackCount > 0)
        {
            if (UIStack[StackCount - 1] != null)
            {
                UIStack[StackCount - 1].DOAnchorPos(new Vector2(0, 1090), 0.5f);
                if (!isTrain)
                {
                 OptimizationUI(UIStack[StackCount - 1]); //UI 껏다 켜줌
                }
                UIStack[StackCount - 1] = null;
                StackCount--;
                shopMgr.sellPrice.gameObject.SetActive(false);
                shopMgr.shopPriceText.gameObject.SetActive(false);
                shopMgr.shopPriceTextForBuy.gameObject.SetActive(false);
                smithMgr.isActive = false;
                smithMgr.EquipReturnToInven();

            }
        }
        else if (StackCount == 0)
        {
            if (townMgr.isTown)
                UI_QuitPanel_On();
        }
        if (StackCount == 0)
        {
            if (!UI_isBackground_On) // 패널 올라가고 나서 ESC 누르면 아래 패널 내려가는거 방지 04/06 윤성근
            {
                UI_BackGroundPanel_On_Off();
            }
            camMove.ReturnToOrigin();
        }
    }

    public void UI_GuildPanel_On()
    {
        isGuild = true;
        UI_guildPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_guildPanelPos;
        StackCount++;
        UI_BackGroundPanel_On_Off();

        //if(UI_isGuildPanel_On)
        //{
        //    UI_guildPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
        //    UI_isGuildPanel_On = false;
        //}
        //else
        //{
        //    UI_guildPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        //    UI_isGuildPanel_On = true;
        //}
    }
    public void UI_StatusPanel_On()
    {
        UI_StatusPanelPos.gameObject.SetActive(true);
        UI_StatusPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_StatusPanelPos;
        StackCount++;
    }

    public void UI_StatusPanel_Tent_On()
    {

        isTentStatus = true;
        UI_StatusPanel_Tent_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_StatusPanel_Tent_Pos;
        StackCount++;
    }

    public void UI_DungeonSelectPanel_On()
    {
        UI_DungeonSelectPanelPos.gameObject.SetActive(true);
        UI_DungeonSelectPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_DungeonSelectPanelPos;
        StackCount++;

    }

    public void UI_ChurchPanel_On()
    {

        isChurch = true;
        UI_churchPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_churchPanelPos;
        StackCount++;
        UI_BackGroundPanel_On_Off();


    }
    public void UI_ChurchWarning_On()
    {
        UI_ChurchWarning_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
    }
    public void UI_ChurchWarning_Off()
    {

        UI_ChurchWarning_Pos.DOAnchorPos(new Vector2(0, 800f), 0.5f);
    }

    public void UI_TrainingPanel_On()
    {

        isTrain = true;
        UI_trainingPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_trainingPanelPos;
        StackCount++;
        UI_BackGroundPanel_On_Off();
    }
    public void UI_TrainWarning_On()
    {
        UI_TrainWarning_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
    }
    public void UI_TrainWarning_Off()
    {
        UI_TrainWarning_Pos.DOAnchorPos(new Vector2(0, 800f), 0.5f);
    }
    public void UI_TrainingSecPanel_On()
    {

        isTrainDetail = true;
        option_Btn.SetActive(false);
        UI_trainingSecPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_trainingSecPanelPos;
        StackCount++;

    }
    public void UI_TrainingSecPanel_Off()
    {
        if (StackCount > 0)
        {
            if (UIStack[StackCount - 1] != null)
            {

                UI_trainingSecPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
                UIStack[StackCount - 1] = null;
                StackCount--;
            }
        }
    }

    public void UI_Shop_PanelPos_On_Off()
    {
        if (!isShop)
        {

            isShop = true;
            UI_shopPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_shopPanelPos;
            StackCount++;
            UI_BackGroundPanel_On_Off();
        }
        else
        {

            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
        }

    }

    public void UI_Inventory_PanelPos_On_Off()
    {

        UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_inventoryPanelPos;
        StackCount++;
        UI_BackGroundPanel_On_Off();

    }

    public void UI_Inventory_Tent_PanelPos_On_Off()
    {

        UI_inventoryPanel_TentPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_inventoryPanel_TentPos;
        StackCount++;
    }

    public void UI_Smith_PanelPos_On_Off()
    {
        if (!isSmith)
        {
            isSmith = true;
            UI_smithPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_smithPanelPos;
            StackCount++;
            UI_BackGroundPanel_On_Off();
        }

    }
    public void UI_DunGeonEntrance_On()
    {

        UI_DunGeonEntrance_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_DunGeonEntrance_Pos;
        StackCount++;


    }

    public void UI_BackGroundPanel_On_Off()
    {
        if (UI_isBackground_On)
        {

            UI_BackGround_Pos.DOAnchorPos(new Vector2(0, -200), 0.5f);
            UI_isBackground_On = false;
        }
        else
        {

            UI_BackGround_Pos.DOAnchorPos(new Vector2(0, 140), 0.5f);
            UI_isBackground_On = true;
        }
    }

    public void UI_OptionPanel_On()
    {
        isOption = true;
        UI_Option_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_Option_Pos;
        StackCount++;
    }

    public void UI_Tent_OptionPanel_On()
    {
        isTentOption = true;
        UI_Tent_Option_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_Tent_Option_Pos;
        StackCount++;
    }

    public void UI_QuitPanel_On()
    {
        UI_QuitPanel_Pos.gameObject.SetActive(true);
        UI_QuitPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_QuitPanel_Pos;
        StackCount++;
    }
    public void UI_QuitPanel_Off()
    {
        if (StackCount > 0)
        {
            if (UIStack[StackCount - 1] != null)
            {
                UI_trainingSecPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
                UI_QuitPanel_Pos.gameObject.SetActive(false);
                UIStack[StackCount - 1] = null;
                StackCount--;
            }
        }
    }

    public void TentInvenToOriginInven()
    {
        for (int i = 0; i < shopMgr.hasItemList.Count; i++)
        {
            shopMgr.hasItemList[i].transform.SetParent(originInven.transform);
            shopMgr.hasItemList[i].transform.localPosition = originInven.transform.localPosition;
            shopMgr.hasItemList[i].transform.localScale = new Vector3(1, 1, 1);
        }
        for (int i = 0; i < shopMgr.hasEquipList.Count; i++)
        {
            shopMgr.hasEquipList[i].transform.SetParent(originInven.transform);
            shopMgr.hasEquipList[i].transform.localPosition = originInven.transform.localPosition;
            shopMgr.hasEquipList[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void InvenSellRefresh() //상점 닫을때 아이템들 변수를 초기화 해주는 함수입니다.
    {
        for (int i = 0; i < shopMgr.inventory.transform.childCount; i++)
        {
            if (shopMgr.inventory.transform.GetChild(i).tag == "Item")
            {
                shopMgr.inventory.transform.GetChild(i).GetComponent<ItemScripts>().sell = 0;
            }
            else if (shopMgr.inventory.transform.GetChild(i).tag == "Equip")
            {
                shopMgr.inventory.transform.GetChild(i).GetComponent<EquipScripts_ysg>().sell = 0;
            }
        }

        for (int i = 0; i < shopMgr.shopPanel.transform.childCount; i++)
        {
            if (shopMgr.shopPanel.transform.GetChild(i).tag == "Item" || shopMgr.shopPanel.transform.GetChild(i).tag == "Equip")
            {
                shopMgr.shopPanel.transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void OptimizationUI(RectTransform target) // UI 껏다 켜줌
    {
        UI_inventoryPanelPos.gameObject.SetActive(false);
        UI_StatusPanelPos.gameObject.SetActive(false);
        target.gameObject.SetActive(false);
    }

    public void BlackScreenUnenabled() //블랙 스크린 딜레이
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        blackscreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        blackscreen.gameObject.SetActive(false);
    }




}
