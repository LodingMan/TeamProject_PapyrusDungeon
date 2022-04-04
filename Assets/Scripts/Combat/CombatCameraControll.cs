using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                        }
                    }
                   
                }
            }
        }
    }

    public void UI_Camera_All_Off()
    {
        //���⼭ �ڷ�ƾ ����ؼ� �гδݰ� ���ų� ���̵��� / �ƿ�ó���ؼ� �ڿ������� �����̵�.
        // �Ʒ� setActive���� �ڷ�ƾ �ȿ� �־ ����. 

        TownCanvas.gameObject.SetActive(false);
        TownCamera.gameObject.SetActive(false);

        TentCamera.gameObject.SetActive(false);
        TentCanvas.gameObject.SetActive(false);

        CombatCamera.enabled = true;

        MinimapCamera.enabled = true;

        OffControll = GameObject.Find("TentManager");
        OffControll.GetComponent<ItemUseManager>().enabled = false;

    }

    public void CameraCurrentPosSet() //����ϸ� ���� �� ��ġ�� ī�޶� ������. (��� ����.)
    {

        for(int i = 0; i < roomController.RoomList.Count; i++)
        {
            if (roomController.RoomList[i].GetComponent<RoomScript>().roomNumber == inGame_Player_Script.currentPlayers)
            {
                Debug.Log("ã�Ҵ�");
                MinimapCamera.transform.position = roomController.RoomList[i].transform.position - new Vector3(0, 0, 15);
            }

        }
        // MinimapCamera.transform = roomController.RoomList[inGame_Player_Script.currentPlayers]

    }







}
