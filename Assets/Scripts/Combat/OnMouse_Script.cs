using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse_Script: MonoBehaviour {
    public SkillActiveManager skillActiveManager;

    public void On_MouseEnter() {
        switch (gameObject.name) {
            case "Skill1":
                skillActiveManager.Skill1_Info();
                break;
            case "Skill2":
                skillActiveManager.Skill2_Info();
                break;
            case "Skill3":
                skillActiveManager.Skill3_Info();
                break;
            default:
                break;
        }
    }
    public void On_MouseExit() {
         skillActiveManager.InfoOut();
    }

    // private void OnMouseEnter() {
    //     switch (gameObject.name) {
    //         case "Skill1":
    //             skillActiveManager.Skill1_Info();
    //             break;
    //         case "Skill2":
    //             skillActiveManager.Skill2_Info();
    //             break;
    //         case "Skill3":
    //             skillActiveManager.Skill3_Info();
    //             break;
    //         default:
    //             break;
    //     }

    // }
    private void OnMouseExit() {
        // skillActiveManager.InfoOut();

    }
}
