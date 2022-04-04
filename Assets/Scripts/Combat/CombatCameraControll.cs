using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatCameraControll : MonoBehaviour
{
    public Camera CombatCamera;

    public Camera MinimapCamera;
    public Camera TentCamera;
    public Camera TownCamera;

    public Canvas TentCanvas;
    public Canvas TownCanvas;


    public RoomController roomController;
    public InGame_Player_Script inGame_Player_Script;

    public GameObject OffControll;

    public bool isMiniMapOn = false;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = MinimapCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Room")
                {
                    if (inGame_Player_Script.isRoom)
                    {
                        if(inGame_Player_Script.isMove)
                        {
                            inGame_Player_Script.PlayerWarp(hit.collider.gameObject.GetComponent<RoomScript>().roomNumber - inGame_Player_Script.currentPlayers);
                            Debug.Log(hit.collider.gameObject.GetComponent<RoomScript>().roomNumber - inGame_Player_Script.currentPlayers);
                            
                        }
                    }
                   
                }
            }
        }
    }

    public void UI_Camera_All_Off()
    {
        //여기서 코루틴 사용해서 패널닫고 열거나 페이드인 / 아웃처리해서 자연스러운 던전이동.
        // 아래 setActive들을 코루틴 안에 넣어도 좋다. 

        //TownCanvas.gameObject.SetActive(false);
        //TownCamera.gameObject.SetActive(false);
        TownCamera.enabled = false;
        TownCanvas.enabled = false;

        TentCamera.enabled = false;
        TentCanvas.enabled = false;

        //TentCamera.gameObject.SetActive(false);
        //TentCanvas.gameObject.SetActive(false);

        CombatCamera.enabled = true;

        MinimapCamera.enabled = true;

        OffControll = GameObject.Find("TentManager");
        OffControll.GetComponent<ItemUseManager>().enabled = false;

    }

    public void CameraCurrentPosSet() //사용하면 현재 방 위치로 카메라 돌려줌. (통로 포함.)
    {

        for(int i = 0; i < roomController.RoomList.Count; i++)
        {
            if (roomController.RoomList[i].GetComponent<RoomScript>().roomNumber == inGame_Player_Script.currentPlayers)
            {
                Debug.Log("찾았다");
                MinimapCamera.transform.position = roomController.RoomList[i].transform.position - new Vector3(0, 0, 15);
            }

        }
        // MinimapCamera.transform = roomController.RoomList[inGame_Player_Script.currentPlayers]
        StartCoroutine(MinimapDlay());


    }

    public void MiniMapCameraMove()
    {
        if(!isMiniMapOn)
        {
            //MinimapCamera.enabled = true;

            MinimapCamera.DORect(new Rect(0.25f, 0.25f, 0.5f, 0.5f), 0.5f);
            isMiniMapOn = true;

        }
        else
        {

            MinimapCamera.DORect(new Rect(0f, 0f, 0f, 0f), 0.5f);
            isMiniMapOn = false;
          //  MinimapCamera.enabled = false;

        }
    }

    IEnumerator MinimapDlay()
    {
        yield return new WaitForSeconds(1);
        MiniMapCameraMove();
    }




}
