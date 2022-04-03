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
    public bool isTentOn = false; // shin

    public ShopManager shopMgr;

    public RectTransform[] UIStack = new RectTransform[4];
    public int StackCount = 0;
    public Canvas canvas_Town;
    public Canvas canvas_Tent;
    public Camera camera_Town;
    public Camera camera_Tent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isTentOn == true && StackCount == 0)
            {
                if (canvas_Tent.enabled)
                {
                    canvas_Tent.enabled = false;
                }
                UI_loadingPanel_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
                StartCoroutine(TweenLoadingPanel());
                // 텐트에서 아무 Stack도 없는 상태에서 esc누르면 마을 캔버스로 돌아감.
            }
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
    
    IEnumerator TweenLoadingPanel()
    {
        yield return new WaitForSeconds(2f);
        if (camera_Tent.enabled)
        {
            camera_Tent.enabled = false;
        }
        if (!camera_Tent.enabled) camera_Town.enabled = true;
        if (!canvas_Tent.enabled) canvas_Town.enabled = true;

        UI_loadingPanel_Pos.DOAnchorPos(new Vector2(1500, 0), 0.5f);
        isTentOn = false;
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
        UI_DunGeonEntrance_Pos.DOAnchorPos(new Vector2(0, 0), 0.5f);
        UIStack[StackCount] = UI_DunGeonEntrance_Pos;
        StackCount++;
    }

    public void UI_BackGroundPanel_On_Off()
    {
        if (UI_isBackground_On)
        {
            panelOpenBtn.text = "O\nP\nE\nN";
            UI_BackGround_Pos.DOAnchorPos(new Vector2(-130, 0), 0.5f);
            UI_isBackground_On = false;
        }
        else
        {
            panelOpenBtn.text = "C\nL\nO\nS\nE";
            UI_BackGround_Pos.DOAnchorPos(new Vector2(130, 0), 0.5f);
            UI_isBackground_On = true;
        }
    }

    
}
