using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DungeonSelect_Manager : MonoBehaviour
{
    public List<GameObject> buttons;  //원래 있던버튼 싹다 비활성화 시켜주기
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
        //카메라 이동
        for( int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);//기존 버튼 비활성
        }
        uI_Tweening_Manager.UI_DungeonSelectPanel_On(); // 사용할 패널 내려옴
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
