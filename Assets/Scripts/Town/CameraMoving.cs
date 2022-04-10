using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//==================================================================================================//
// UI 클릭 시 카메라 이동하는 스크립트입니다. 03-30 윤성근
//==================================================================================================//

public class CameraMoving : MonoBehaviour
{
    public GameObject cam;
    public Animator camAnim;
    public CamState camState;
    public int camStateChecker = 0;


    
    public enum CamState
    {
        toChurch = 1,
        toShop,
        toSmith,
        toTraining,
        toGuild,
        churchToOrigin,
        shopToOrigin,
        smithToOrigin,
        trainingToOrigin,
        guildToOrigin
    }

    private void Start()
    {
        camAnim = cam.GetComponent<Animator>();
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity: 800, sequencesCapacity: 200);
    }

    private void Update()
    {
       CameraMove();
    }

    public void CameraMove() // 카메라 이동 애니메이션
    {
        switch (camState)
        {
            case CamState.toChurch:
                camAnim.SetInteger("camState", 1);
                break;
            case CamState.toShop:
                camAnim.SetInteger("camState", 2);
                break;
            case CamState.toSmith:
                camAnim.SetInteger("camState", 3);
                break;
            case CamState.toTraining:
                camAnim.SetInteger("camState", 4);
                break;
            case CamState.toGuild:
                camAnim.SetInteger("camState", 5);
                break;
            case CamState.churchToOrigin:
                camAnim.SetInteger("camState", 6);
                camStateChecker = 0;
                break;
            case CamState.shopToOrigin:
                camAnim.SetInteger("camState", 7);
                camStateChecker = 0;
                break;
            case CamState.smithToOrigin:
                camAnim.SetInteger("camState", 8);
                camStateChecker = 0;
                break;
            case CamState.trainingToOrigin:
                camAnim.SetInteger("camState", 9);
                camStateChecker = 0;
                break;
            case CamState.guildToOrigin:
                camAnim.SetInteger("camState", 10);
                camStateChecker = 0;
                break;
            default:
                break;
        }
    }

    public void toChurch()
    {
        if (camStateChecker == 1 || camStateChecker == 0)
        {
            camStateChecker = 1;
            camState = CamState.toChurch;
        }
    }
    public void toShop()
    {
        if (camStateChecker == 2 || camStateChecker == 0)
        {
            camStateChecker = 2;
            camState = CamState.toShop;
        }
    }
    public void toSmith()
    {
        if (camStateChecker == 3 || camStateChecker == 0)
        {
            camStateChecker = 3;
            camState = CamState.toSmith;
        }
    }
    public void toTraining()
    {
        if (camStateChecker == 4 || camStateChecker == 0)
        {
            camStateChecker = 4;
            camState = CamState.toTraining;
        }
    }
    public void toGuild()
    {
        if (camStateChecker == 5 || camStateChecker == 0)
        {
            camStateChecker = 5;
            camState = CamState.toGuild;
        }
    }


    public void ReturnToOrigin() // 현재 위치에서 원래 자리로 돌아올때 필요한 함수입니다.
    {
        switch (camStateChecker)
        {
            case 1:
                camState = CamState.churchToOrigin;
                break;
            case 2:
                camState = CamState.shopToOrigin;
                break;
            case 3:
                camState = CamState.smithToOrigin;
                break;
            case 4:
                camState = CamState.trainingToOrigin;
                break;
            case 5:
                camState = CamState.guildToOrigin;
                break;
            default:
                break;
        }

    }


}
