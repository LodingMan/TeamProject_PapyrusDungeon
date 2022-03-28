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
    bool UI_isGuildPanel_On = false;




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
}
