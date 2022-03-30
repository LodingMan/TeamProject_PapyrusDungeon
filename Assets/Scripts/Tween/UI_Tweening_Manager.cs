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
    public bool isShopOn = false;
    public bool isSmithOn = false;

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
                }
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
        if (UI_isShopPanel_On && isShopOn)
        {
            UI_shopPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
            UI_isShopPanel_On = false;
            isShopOn = false;

        }
        else if(!isShopOn && !isSmithOn)
        {
            UI_shopPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isShopPanel_On = true;
            isShopOn = true;

        }
    }

    public void UI_Inventory_PanelPos_On_Off()
    {
        if (UI_isInventoryPanel_On)
        {
            UI_inventoryPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
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
            UI_smithPanelPos.DOAnchorPos(new Vector2(0, 1090), 0.5f);
            UI_isSmithPanel_On = false;
            isSmithOn = false;
        }
        else if(!isSmithOn && !isShopOn)
        {
            UI_smithPanelPos.DOAnchorPos(new Vector2(0, 0), 0.5f);
            UI_isSmithPanel_On = true;
            isSmithOn = true;

        }
    }
}
