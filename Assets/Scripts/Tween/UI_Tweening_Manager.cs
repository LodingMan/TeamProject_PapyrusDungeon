using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

//==================================================================================================//
//UI�� �������� Tween���� ��Ʈ�� �Ҷ� TweenManager������Ʈ�� �� ������Ʈ�� �ְ� ���� (Stage �������� ���)//
//==================================================================================================//
public class UI_Tweening_Manager : MonoBehaviour
{
    public RectTransform UI_guildPanelPos;
    public RectTransform UI_churchPanelPos;
    public RectTransform UI_trainingPanelPos;
    bool UI_isGuildPanel_On = false;
    bool UI_isChurchPanel_On = false;
    bool UI_isTrainingPanel_On = false;




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
}
