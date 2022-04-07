using DG.Tweening;
using UnityEngine;

//==================================================================================================//
//UI�� �������� Tween���� ��Ʈ�� �Ҷ� TweenManager������Ʈ�� �� ������Ʈ�� �ְ� ���� (Stage �������� ���)//
//==================================================================================================//
public class UI_Tweening_Manager : MonoBehaviour
{
    public RectTransform UI_guildPanelPos;
    public RectTransform UI_StatusPanelPos;
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
    public RectTransform UI_ChurchWarningPanel_Pos;
    public RectTransform UI_TrainWarningPanel_Pos;
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
    public bool isTentOn = false; // shin
    public bool isShopOn = false;
    public bool isSmith = false;

    public ShopManager shopMgr;
    public SmithManager smithMgr;

    public RectTransform[] UIStack = new RectTransform[4];
    public int StackCount = 0;
    public Shin.UI_DungeonInitButton uI_DungeonInitButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isTentOn == true && StackCount == 0)
            {
                if (uI_DungeonInitButton.canvas_Tent.activeSelf)
                {
                    uI_DungeonInitButton.canvas_Tent.SetActive(false);
                }
                UI_loadingPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
                StartCoroutine(uI_DungeonInitButton.TweenLoadingPanelToTown());
                // 텐트에서 아무 Stack도 없는 상태에서 esc누르면 마을 캔버스로 돌아감.
            }
            if (isShopOn || isSmith)
            {
                isShopOn = false;
                shopMgr.isShop = false;
                isSmith = false;
                UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
            }
            StackCountFun();

        }
    }

    public void StackCountFun()
    {
        if (StackCount > 0)
        {
            if (UIStack[StackCount - 1] != null)
            {
                UIStack[StackCount - 1].DOAnchorPos(new Vector2(0, 1090), 0.5f);
                UIStack[StackCount - 1] = null;
                StackCount--;
                isShopOn = false;
                smithMgr.EquipReturnToInven();

            }
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

        UI_StatusPanelPos.DOAnchorPos(new Vector2(0, 0), 1f);
        UIStack[StackCount] = UI_StatusPanelPos;
        StackCount++;


    }

    public void UI_DungeonSelectPanel_On()
    {

        UI_DungeonSelectPanelPos.DOAnchorPos(new Vector2(0, 0), 1f);
        UIStack[StackCount] = UI_DungeonSelectPanelPos;
        StackCount++;

    }

    public void UI_ChurchPanel_On()
    {
        UI_churchPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_churchPanelPos;
        StackCount++;
        UI_BackGroundPanel_On_Off();


    }
    public void UI_ChurchWarningPanel_On()
    {
        UI_ChurchWarningPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_ChurchWarningPanel_Pos;
        StackCount++;
    }
    public void UI_ChurchWarningPanel_Off()
    {
        if (StackCount > 0)
        {
            if (UIStack[StackCount - 1] != null)
            {
                UIStack[StackCount - 1].DOAnchorPos(new Vector2(0, 1090), 0.5f);
                UIStack[StackCount - 1] = null;
                StackCount--;
            }
        }
    }

    public void UI_TrainingPanel_On()
    {

        UI_trainingPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_trainingPanelPos;
        StackCount++;
        UI_BackGroundPanel_On_Off();

    }
    public void UI_TrainWarningPanel_On()
    {
        UI_TrainWarningPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_TrainWarningPanel_Pos;
        StackCount++;
    }
    public void UI_TrainWarningPanel_Off()
    {
        if (StackCount > 0)
        {
            if (UIStack[StackCount - 1] != null)
            {
                UI_TrainWarningPanel_Pos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
                UIStack[StackCount - 1] = null;
                StackCount--;
            }
        }
    }
    public void UI_TrainingSecPanel_On()
    {

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
        if (!isShopOn)
        {
            isShopOn = true;
            UI_shopPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_shopPanelPos;
            StackCount++;
            UI_BackGroundPanel_On_Off();
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
            UI_BackGround_Pos.DOAnchorPos(new Vector2(0, 150), 0.5f);
            UI_isBackground_On = true;
        }
    }


}
