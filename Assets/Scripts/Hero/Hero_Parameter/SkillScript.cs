using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillScript : MonoBehaviour
{
    public skill[] skills = new skill[5];// 해당 플레이어가 가지고 있는 스킬 리스트.
                                         // 해당 오브젝트가 마법사라면 해당 배열에는 마법사 스킬의 정보가 들어가게 된다. 
                                         // 해당 히어로의 스킬의 레벨을 올린다면 여기에 접근해서 스텟을 올려주면 된다.
                                         // 사용가능한 스킬 / 사용 불가능한 스킬도 여기서 나누기를 희망. ex) int[] onSkillIndex  = new int{2, 3 ,5}

}
