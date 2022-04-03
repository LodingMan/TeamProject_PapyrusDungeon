using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCameraControll : MonoBehaviour
{
    public Camera CombatCamera;

    public Camera MinimapCamera;
    public Camera TentCamera;

    public Canvas TentCanvas;
    public Canvas TownCanvas;



    public void UI_Camera_All_Off()
    {
        TownCanvas.enabled = false;
        MinimapCamera.enabled = true;
        TentCamera.enabled = false;
        TentCanvas.enabled = false;
    }



}
