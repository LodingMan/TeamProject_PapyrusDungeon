using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

//==================================================================================================//
//UI의 움직임을 Tween으로 컨트롤 할때 TweenManager오브젝트의 이 컴포넌트에 넣고 제어 (Stage 씬에서만 사용)//
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
    public CameraMoving camMove;
    public Text panelOpenBtn;

    bool UI_isBackground_On = false;
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
    public ShopManager shopMgr;

    public RectTransform[] UIStack = new RectTransform[4];
    public int StackCount = 0;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }


    public void UI_GuildPanel_On()
    {
        UI_guildPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_guildPanelPos;
        StackCount++;
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
    }

    public void UI_TrainingPanel_On()
    {
        UI_trainingPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_trainingPanelPos;
        StackCount++;
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

    public void UI_BackGroundPanel_On_Off()
    {
        if (UI_isBackground_On)
        {
            panelOpenBtn.text = "열\n기";
            UI_BackGround_Pos.DOAnchorPos(new Vector2(-769, 0), 0.5f);
            UI_isBackground_On = false;
        }
        else
        {
            panelOpenBtn.text = "닫\n기";
            UI_BackGround_Pos.DOAnchorPos(new Vector2(-515, 0), 0.5f);
            UI_isBackground_On = true;
        }
    }

}
