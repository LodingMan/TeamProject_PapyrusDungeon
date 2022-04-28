using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Town_Event_Manager : MonoBehaviour
{
    public TownManager townManager;
    public GameObject TownEvent_Panel;
    public Text TownEvent_Text;

    public void Event_Panel_Down()
    {
        TownEvent_Panel.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 1f);
        int RndInt;
        if (townManager.Week == 1)
        {
            TownEvent_Text.text = "마을에 원인을 알 수 없는 어둠이 내려앉았습니다... \n" +
                "마을의 최고령인 예언자는 아무도 모르는 서쪽의 숲 너머에서 태양석판을 찾아와야 한다고 말합니다.\n" +
                " 숲 너머에서 원인을 알 수 없는 빛이 아른거립니다.\n" +
                "오늘은 저번주에 용병들을 태우러 왕국으로 떠났던 마차가 돌아오는 날입니다.....";
        }
        else
        {

            RndInt = Random.Range(0, 5);

            switch(RndInt)
            {
                case 0:
                    TownEvent_Text.text = "EventText입니다 1";
                    break;
                case 2:
                    TownEvent_Text.text = "EventText입니다 2";

                    break;
                case 3:
                    TownEvent_Text.text = "EventText입니다 3";

                    break;
                case 4:
                    TownEvent_Text.text = "EventText입니다 4";

                    break;
                default:
                    break;
            }


        }


        
    }
    public void Event_Panel_Up()
    {
        TownEvent_Panel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -720), 1f);
        TownEvent_Panel.gameObject.SetActive(false);

    }
}
