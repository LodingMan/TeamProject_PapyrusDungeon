using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CombatCameraControll : MonoBehaviour
{
    public IntroSceneScript introSceneScript;
    public TownManager townMgr;
    public Camera CombatCamera;

    public Camera MinimapCamera;
    public Camera TentCamera;
    public Camera TownCamera;

    public Canvas TentCanvas;
    public Canvas TownCanvas;
    public Canvas CombatCanvas;

    public Image LoadingPanal;
    

    public RoomController roomController;
    public InGame_Player_Script inGame_Player_Script;


    public bool isMiniMapOn = false;

    public bool isFirst = true;

    private void Start()
    {
        townMgr = GameObject.Find("TownManager").GetComponent<TownManager>();
        //introSceneScript = GameObject.Find("BGM_Manager").GetComponent<IntroSceneScript>();
    }
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
    public void UI_Camera_All_On()
    {
        TownCamera.enabled = true;

        TentCamera.enabled = true;
        CombatCamera.enabled = false;

        MinimapCamera.enabled = false;

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
        if(!isFirst)
        {
            BlackFade_In();
        }
        isFirst = false;
        // MinimapCamera.transform = roomController.RoomList[inGame_Player_Script.currentPlayers]
    }

    public void MiniMapCameraMove() //미니맵 창이 부드럽게 가운데에 뜨게 만듬
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

    public IEnumerator MinimapDlay() //복도로 이동하고 1초뒤에 미니맵 닫히도록함
    {
        yield return new WaitForSeconds(1);
        MiniMapCameraMove();
    }


    public void BlackFade_Out() //전투시작 눌렀을때 로딩하는것처럼 보이게 하기
    {

        StartCoroutine(FadeOutDlay());
    }

    public void BlackFade_In()
    {
        StartCoroutine(FadeInDlay());
    }
    IEnumerator FadeOutDlay() //위를 하기 위한 코루틴
    {
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(0, 0);
        LoadingPanal.color = Color.black;
        yield return new WaitForSeconds(3);
        LoadingPanal.DOColor(new Color(0, 0, 0, 0), 4);

        townMgr.isTown = false; townMgr.isTent = false;
        townMgr.isCombat = true;
        if (TownCamera.transform.gameObject.activeSelf) { TownCamera.transform.gameObject.SetActive(false); }
        if (TentCamera.transform.gameObject.activeSelf) { TentCamera.transform.gameObject.SetActive(false); }
       // introSceneScript.audioSS.Stop();
        CombatCamera.transform.gameObject.SetActive(true);
        CombatCanvas.transform.gameObject.SetActive(true);
        CombatCanvas.enabled = true;

        yield return new WaitForSeconds(2f);
        //introSceneScript.audioSS.clip = introSceneScript.audioCombat;
      //  introSceneScript.audioSS.Play();
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(1470, -16);
        

    }
    IEnumerator FadeInDlay()
    {
        LoadingPanal.color = new Color(0, 0, 0, 0);
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(0, 0);
        LoadingPanal.DOColor(Color.black, 2);
        yield return new WaitForSeconds(3f);
       // Screen.fullScreen = true;
        LoadingPanal.DOColor(new Color(0, 0, 0, 0), 2);
        yield return new WaitForSeconds(2f);
        LoadingPanal.rectTransform.anchoredPosition = new Vector2(1470, -16);
        LoadingPanal.color = Color.black;


    }

}
