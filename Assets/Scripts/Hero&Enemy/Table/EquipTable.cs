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
        { 0, new Equip(0, "Sword", 1, 10, 0, 10) }, //Equip의 맴버변수는 ClassBundle확인
        { 1, new Equip(1, "Axe", 1, 15, 0, 10) },
        { 2, new Equip(2, "Bow", 1, 10, 0, 10) },
        { 3, new Equip(3, "Knife", 1, 10, 0, 10) },
        { 4, new Equip(4, "PoleAxe", 1, 20, 0, 10) },
        { 5, new Equip(5, "Saber", 1, 10, 0, 10) },
        { 6, new Equip(6, "Wand", 1, 10, 0, 10) },
        { 7, new Equip(7, "Amulet1", 1, 0, 10, 10) },
        { 8, new Equip(8, "Amulet2", 1, 0, 12, 10) },
        { 9, new Equip(9, "Amulet3", 1, 0, 15, 10) },
        { 10, new Equip(10, "Armor1", 1, 0, 20, 10) },
        { 11, new Equip(11, "Armor2", 1, 0, 20, 10) },
        { 12, new Equip(12, "Boot1", 1, 0, 10, 10) },
        { 13, new Equip(13, "Boot2", 1, 0, 12, 10) },
        { 14, new Equip(14, "Boot3", 1, 0, 15, 10) },
        { 15, new Equip(15, "Braser1", 1, 0, 10, 10) },
        { 16, new Equip(16, "Braser2", 1, 5, 10, 10) },
        { 17, new Equip(17, "Glove1", 1, 10, 5, 10) },
        { 18, new Equip(18, "Glove2", 1, 3, 6, 10) },
        { 19, new Equip(19, "Glove3", 1, 2, 10, 10) },
        { 20, new Equip(20, "Helmet1", 1, 0, 20, 10) },
        { 21, new Equip(21, "Helmet2", 1, 0, 15, 10) },
        { 22, new Equip(22, "Helmet3", 1, 0, 10, 10) },
        { 23, new Equip(23, "Ring1", 1, 5, 5, 10) },
        { 24, new Equip(24, "Ring2", 1, 6, 6, 10) },
        { 25, new Equip(25, "Shield", 1, 0, 10, 10) }
    };



}
