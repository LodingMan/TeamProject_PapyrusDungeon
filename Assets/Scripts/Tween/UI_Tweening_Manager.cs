using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

//==================================================================================================//
//UI의 움직임을 Tween으로 컨트롤 할때 TweenManager오브젝트의 이 컴포넌트에 넣고 제어 (Stage 씬에서만 사용)//
//==================================================================================================//
public class UI_Tweening_Manager : MonoBehaviour
{
    public RectTransform UI_guildPanelPos;
    public RectTransform UI_StatusPanelPos;
    public RectTransform UI_churchPanelPos;
    public RectTransform UI_trainingPanelPos;
    public RectTransform UI_shopPanelPos;
    public RectTransform UI_inventoryPanelPos;
    public RectTransform UI_smithPanelPos;

    bool UI_isGuildPanel_On = false;
    bool UI_isChurchPanel_On = false;
    bool UI_isTrainingPanel_On = false;
    bool UI_isShopPanel_On = false;
    bool UI_isInventoryPanel_On = false;
    bool UI_isSmithPanel_On = false;
    public bool UI_isStatusPanel_On = false;




    public void UI_GuildPanel_On_Off()
    {

        if(UI_isGuildPanel_On)
        {
            UI_guildPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
            UI_isGuildPanel_On = false;
        }
        else
        {
            UI_guildPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isGuildPanel_On = true;
        }
    }
    public void UI_StatusPanel_On_Off()
    {
        if(UI_isStatusPanel_On)
        {
            UI_StatusPanelPos.DOAnchorPos(new Vector2(0,2170), 1f);
            UI_isStatusPanel_On = false;
        }
        else
        {
            UI_StatusPanelPos.DOAnchorPos(new Vector2(0, 0), 1f);
            UI_isStatusPanel_On = true;
        }
    }

    public void UI_churchPanelPos_On_Off()
    {
        if (UI_isChurchPanel_On)
        {
            UI_churchPanelPos.DOAnchorPos(new Vector2(-1950, 0), 0.5f);
            UI_isChurchPanel_On = false;
        }
        else
        {
            UI_churchPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isChurchPanel_On = true;
        }
    }

    public void UI_Training_PanelPos_On_Off()
    {
        if (UI_isTrainingPanel_On)
        {
            UI_trainingPanelPos.DOAnchorPos(new Vector2(-1950, 0), 0.5f);
            UI_isTrainingPanel_On = false;
        }
        else
        {
            UI_trainingPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isTrainingPanel_On = true;
        }
    }

    public void UI_Shop_PanelPos_On_Off()
    {
        if (UI_isShopPanel_On)
        {
            UI_shopPanelPos.DOAnchorPos(new Vector2(-1950, 0), 0.5f);
            UI_isShopPanel_On = false;

        }
        else
        {
            UI_shopPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isShopPanel_On = true;
        }
    }

    public void UI_Inventory_PanelPos_On_Off()
    {
        if (UI_isInventoryPanel_On)
        {
            UI_inventoryPanelPos.DOAnchorPos(new Vector2(-1950, 0), 0.5f);
            UI_isInventoryPanel_On = false;

        }
        else
        {
            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isInventoryPanel_On = true;
        }
    }

    public void UI_Smith_PanelPos_On_Off()
    {
        if (UI_isSmithPanel_On)
        {
            UI_smithPanelPos.DOAnchorPos(new Vector2(-1950, 0), 0.5f);
            UI_isSmithPanel_On = false;
        }
        else
        {
            UI_smithPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isSmithPanel_On = true;
        }
    }
}
