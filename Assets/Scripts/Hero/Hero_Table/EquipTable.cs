using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 03/26에 추가된 스크립트
// 모든 장비의 값을 저장하는 테이블
// 여기에 있는 값을 다른 스크립트에서 사용하려면 EquipTable equipTable = new EquipTable(); 사용하면 이 클래스에 있는 값을 가져갈 수 있다.  
public class EquipTable
{
    public Dictionary<int, Equip> initEquip = new Dictionary<int, Equip>()
    {
        { 0, new Equip(0, "Sword", 1, 10, 0) }, //Equip의 맴버변수는 ClassBundle확인
        { 1, new Equip(1, "Shield", 1, 0, 10) },
        { 2, new Equip(2, "EquipName3", 1, 0, 10) }
    };



}
