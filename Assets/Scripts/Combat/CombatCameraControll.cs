using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CombatCameraControll : MonoBehaviour
{
    public Camera CombatCamera;

    public Camera MinimapCamera;
    public Camera TentCamera;
    public Camera TownCamera;

    public Canvas TentCanvas;
    public Canvas TownCanvas;

    public Image LoadingPanal;
    

    public RoomController roomController;
    public InGame_Player_Script inGame_Player_Script;


    public bool isMiniMapOn = false;

    public bool isFirst = true;


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
         TownCamera.enabled = false;
       // TownCanvas.enabled = false;

        TentCamera.enabled = false;
        CombatCamera.enabled = true;

        MinimapCamera.enabled = true;


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
        if(!isFirst)
        {
            BlackFade_In();
        }
        isFirst = false;
        // MinimapCamera.transform = roomController.RoomList[inGame_Player_Script.currentPlayers]
    }

    public void MiniMapCameraMove() //�̴ϸ� â�� �ε巴�� ����� �߰� ����
    {
        if(!isMiniMapOn)
        {
            //MinimapCamera.enabled = true;

            MinimapCamera.DORect(new Rect(0.18f, 0.18f, 0.65f, 0.65f), 0.5f);
            isMiniMapOn = true;
        }
        else
        {
            MinimapCamera.DORect(new Rect(0f, 0f, 0f, 0f), 0.5f);
            isMiniMapOn = false;
          //  MinimapCamera.enabled = false;

        }
    }

    public IEnumerator MinimapDlay() //������ �̵��ϰ� 1�ʵڿ� �̴ϸ� ����������
    {
        yield return new WaitForSeconds(1);
        MiniMapCameraMove();
    }


    public void BlackFade_Out() //�������� �������� �ε��ϴ°�ó�� ���̰� �ϱ�
    {
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(0, 0);
        LoadingPanal.color = Color.black;
        StartCoroutine(FadeOutDlay());
    }

    public void BlackFade_In()
    {
        StartCoroutine(FadeInDlay());
    }
    IEnumerator FadeOutDlay() //���� �ϱ� ���� �ڷ�ƾ
    {
        yield return new WaitForSeconds(4);
        LoadingPanal.DOColor(new Color(0, 0, 0, 0), 7);
        yield return new WaitForSeconds(5);
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(1470, -16);
        LoadingPanal.color = Color.black;
    }
    IEnumerator FadeInDlay()
    {
        LoadingPanal.color = new Color(0, 0, 0, 0);
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(0, 0);
        LoadingPanal.DOColor(Color.black, 2);
        yield return new WaitForSeconds(5);
        LoadingPanal.DOColor(new Color(0, 0, 0, 0), 2);
        yield return new WaitForSeconds(3);
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(1470, -16);


    }

}
