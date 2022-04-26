using UnityEngine;

public class Combat_Guide_Script: MonoBehaviour {
    public GameObject MinimapButtonGuide;
    public GameObject MinimapTouchGuide;
    public GameObject PassageEventGuide;
    public GameObject Go_Back_Guide;
    public GameObject Combat_Skill_Guide;

    public bool isMinimapButtonGuide = false;
    public bool isMinimapTouchGuide = false;
    public bool isPassageEventGuide = false;
    public bool isGo_Back_Guide = false;
    public bool isCombat_Skill_Guide = false;

    public TownManager townManager;

    public void MinimapButtonGuide_Off() {
        if (townManager.Week == 1) {
            MinimapButtonGuide.SetActive(false);
            MinimapTouchGuide_On();
        }
    }
    public void MinimapTouchGuide_On() {
        if (!isMinimapTouchGuide) {
            if (townManager.Week == 1) {
                MinimapTouchGuide.SetActive(true);
                isMinimapTouchGuide = true;
            }
        }
    }
    public void MinimapTouchGuide_Off() {
        if (townManager.Week == 1) {
            MinimapTouchGuide.SetActive(false);

        }

    }

    public void PassageEventGuide_On() {
        if (townManager.Week == 1) {
            PassageEventGuide.SetActive(true);
        }

    }

    public void PassageEventGuide_Off() {
        if (townManager.Week == 1) {
            PassageEventGuide.SetActive(false);
            Go_Back_Guide_On();

        }

    }
    public void Go_Back_Guide_On() {
        if (!isGo_Back_Guide) {
            if (townManager.Week == 1) {
                Go_Back_Guide.SetActive(true);
                isGo_Back_Guide = true;
            }
        }

    }
    public void Go_Back_Guide_Off() {
        if (townManager.Week == 1) 
            Go_Back_Guide.SetActive(false);
        }
    
    public void Combat_Skill_Guide_On() {
        if (townManager.Week == 1) {
            Combat_Skill_Guide.SetActive(true);
        }
    }
    public void Combat_Skill_Guide_Off() {
        if (townManager.Week == 1) {
            Combat_Skill_Guide.SetActive(false);
        }

    }
}
