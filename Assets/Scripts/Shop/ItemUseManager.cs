using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseManager : MonoBehaviour //영웅을 선택해서 선택한 영웅의 스텟을 바꾸는 스크립트입니다. 03-27윤성근
{
    public Stat stats;
    public string heroName; //현재 선택된 오브젝트의 이름
    public bool isActive = false; // 중복 클릭 방지를 위한 bool값 입니다.


    void Update()
    {
            if (Input.GetMouseButtonDown(0)) // 오브젝트 클릭 시 정보 가져오는 스크립트입니다. 추후에 터치로 바꿀 예정입니다.
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Player") // 레이를 쏴서 태그가 Player이면 그 오브젝트의 정보를 가져옵니다.
                    {                                             // 그 후에 ItemScripts에 있는 함수에 따라서 정보를 변경합니다.
                        isActive = true;
                        stats = hit.transform.gameObject.GetComponent<StatScript>().myStat;
                        heroName = hit.transform.gameObject.name;
                        Debug.Log("{" + heroName + "} 를 선택 하셨습니다.");
                    }

                }
            }

    }


}
