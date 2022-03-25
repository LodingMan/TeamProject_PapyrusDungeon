using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guild_ExampleUI : MonoBehaviour
{
    //예시클래스이므로 실제로 사용하지 않음.
    public Text ClassJob;

    public Song.HeroManager heroManager;
    public void TestFunc()
    {
        // 함수 사용시 UI상의 텍스트가 현재 생성되어있는 히어로 오브젝트의 직업으로 변경
        // CurrentHeroList에 오브젝트가 이미 생성되어있어야 한다. 
        ClassJob.text = heroManager.CurrentHeroList[0].GetComponent<StatScript>().Job; //heroManager의 현재 영웅리스트의
                                                                                       //맴버 오브젝트의 스텟에서 직업 문자열을 가져옴

    }

}
