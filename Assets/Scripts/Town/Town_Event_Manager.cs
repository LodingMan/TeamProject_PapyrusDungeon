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
            TownEvent_Text.text = "������ ������ �� �� ���� ����� �����ɾҽ��ϴ�... \n" +
                "������ �ְ���� �����ڴ� �ƹ��� �𸣴� ������ �� �ʸӿ��� �¾缮���� ã�ƿ;� �Ѵٰ� ���մϴ�.\n" +
                " �� �ʸӿ��� ������ �� �� ���� ���� �Ƹ��Ÿ��ϴ�.\n" +
                "������ �����ֿ� �뺴���� �¿췯 �ձ����� ������ ������ ���ƿ��� ���Դϴ�.....";
        }
        else
        {

            RndInt = Random.Range(0, 5);

            switch(RndInt)
            {
                case 0:
                    TownEvent_Text.text = "EventText�Դϴ� 1";
                    break;
                case 2:
                    TownEvent_Text.text = "EventText�Դϴ� 2";

                    break;
                case 3:
                    TownEvent_Text.text = "EventText�Դϴ� 3";

                    break;
                case 4:
                    TownEvent_Text.text = "EventText�Դϴ� 4";

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
