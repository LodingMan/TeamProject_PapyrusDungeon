using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DungeonSelect_Manager : MonoBehaviour
{
    public List<GameObject> buttons;  //���� �ִ���ư �ϴ� ��Ȱ��ȭ �����ֱ�
    public UI_Tweening_Manager uI_Tweening_Manager;
    public bool isDungeonSelect = false;

    private void Start()
    {
        uI_Tweening_Manager = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();

    }

    private void Update()
    {
        if(isDungeonSelect)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DungeonSelect_Off();
            }
        }

    }
    public void DungeonSelect_On()
    {
        //ī�޶� �̵�
        for( int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);//���� ��ư ��Ȱ��
        }
        uI_Tweening_Manager.UI_DungeonSelectPanel_On(); // ����� �г� ������
        isDungeonSelect = true;
    }
    public void DungeonSelect_Off()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(true);
        }
        isDungeonSelect = false;
    }

    public void DungeonSelect1()
    {
        
    }
    public void DungeonSelect2()
    {

    }
    public void DungeonSelect3()
    {

    }
}
