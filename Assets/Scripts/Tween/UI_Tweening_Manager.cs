using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

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
    public RectTransform UI_HeroStatPanel_TentPos;
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
    public bool isShopOn = false;
    public bool isSmithOn = false;
    public bool isTentOn = false; // shin

    public ShopManager shopMgr;

    public RectTransform[] UIStack = new RectTransform[4];
    public int StackCount = 0;
    public Shin.UI_DungeonInitButton uI_DungeonInitButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isTentOn == true && StackCount == 0)
            {
                if (uI_DungeonInitButton.canvas_Tent.enabled)
                {
                    uI_DungeonInitButton.canvas_Tent.enabled = false;
                }
                UI_loadingPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
                StartCoroutine(uI_DungeonInitButton.TweenLoadingPanelToTown());
                // 텐트에서 아무 Stack도 없는 상태에서 esc누르면 마을 캔버스로 돌아감.
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
                isSmithOn = false;
                shopMgr.isShop = false;

            }
        }

        if (StackCount == 0)
        {
            camMove.ReturnToOrigin();
        }
    }

    public void UI_GuildPanel_On()
    {
        if (!isShopOn && !isSmithOn)
        {
            UI_guildPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_guildPanelPos;
            StackCount++;
        }

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
        if (!isShopOn && !isSmithOn)
        {
            UI_StatusPanelPos.DOAnchorPos(new Vector2(0, 0), 1f);
            UIStack[StackCount] = UI_StatusPanelPos;
            StackCount++;
        }

    }

    public void UI_DungeonSelectPanel_On()
    {
        if (!isShopOn && !isSmithOn)
        {
            UI_DungeonSelectPanelPos.DOAnchorPos(new Vector2(0, 0), 1f);
            UIStack[StackCount] = UI_DungeonSelectPanelPos;
            StackCount++;
        }

    }

    public void UI_ChurchPanel_On()
    {
        if (!isShopOn && !isSmithOn)
        {
            UI_churchPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_churchPanelPos;
            StackCount++;
            UI_BackGroundPanel_On_Off();
        }
        

    }
    public void UI_ChurchWarningPanel_On()
    {
        UI_ChurchWarningPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_ChurchWarningPanel_Pos;
        StackCount++;
    }
    public void UI_ChurchWaringPanel_Off()
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
        if (!isShopOn && !isSmithOn)
        {
            UI_trainingPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_trainingPanelPos;
            StackCount++;
            UI_BackGroundPanel_On_Off();
        }
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
        if (!isShopOn && !isSmithOn)
        {
            UI_trainingSecPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_trainingSecPanelPos;
            StackCount++;
        }

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
        if(!isShopOn && !isSmithOn)
        {
            UI_shopPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_shopPanelPos;
            StackCount++;
            isShopOn = true;

        }
    }

    public void UI_Inventory_PanelPos_On_Off()
    {
        UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_inventoryPanelPos;
        StackCount++;
    }

    public void UI_Inventory_Tent_PanelPos_On_Off()
    {
        UI_inventoryPanel_TentPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_inventoryPanel_TentPos;
        StackCount++;
    }

    public void UI_HeroStat_Tent_PanelPos_On_Off()
    {
        UI_HeroStatPanel_TentPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_HeroStatPanel_TentPos;
        StackCount++;
    }
    public void UI_Smith_PanelPos_On_Off()
    {
        if(!isSmithOn && !isShopOn)
        {
            UI_smithPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_smithPanelPos;
            StackCount++;
            isSmithOn = true;

        }
    }
    public void UI_DunGeonEntrance_On()
    {
        if (!isShopOn && !isSmithOn)
        {
            UI_DunGeonEntrance_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UIStack[StackCount] = UI_DunGeonEntrance_Pos;
            StackCount++;
        }

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
