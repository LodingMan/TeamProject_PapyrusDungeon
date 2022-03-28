using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==========================================================//
//Hero오브젝트의 상태를 구현하게위해 bool값을 모아놓은 스크립트 //
//      기본적으로 Hero오브젝트 안에 컴포넌트로 존재한다.      //
//=========================================================//

public class HeroScript_Current_State : MonoBehaviour
{
    public bool isHealing = false;

    public bool isDead = false;

    public bool isParty = false;

    public bool isTraining = false;
}
