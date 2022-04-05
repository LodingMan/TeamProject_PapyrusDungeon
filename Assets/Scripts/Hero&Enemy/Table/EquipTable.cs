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
        // 인덱스, 이름, 직업, 레벨, hp, mp, atk, def, cri, acc, cost 순으로 추가 시킴 04/05 윤성근
        { 0, new Equip(0, "Sword", "Knight", 1, 0, 0, 10, 0, 0, 0, 10) }, //Equip의 맴버변수는 ClassBundle확인
        { 1, new Equip(1, "Axe", "Barristan", 1, 0, 0, 10, 0, 0, 0, 10) },
        { 2, new Equip(2, "Bow", "Archer", 1, 0, 0, 10, 0, 0, 0, 10) },
        { 3, new Equip(3, "Knife", "Porter" ,1 ,0 ,0, 10, 0, 0, 0, 10) },
        { 4, new Equip(4, "DoubleAxe","Babarian", 1, 0, 0, 20, 0, 0, 0, 10) },
        { 5, new Equip(5, "Saber", "Knight", 1, 0, 0, 10, 0, 0, 0, 10) },
        { 6, new Equip(6, "Wand", "Mage", 1, 0, 0, 10, 0, 0, 0, 10) },
        { 7, new Equip(7, "Amulet1", "Any", 1, 10, 0, 0, 10, 0, 0, 10) },
        { 8, new Equip(8, "Amulet2", "Any", 1, 10, 0, 0, 12, 0, 0, 10) },
        { 9, new Equip(9, "Amulet3", "Any", 1, 10, 0, 0, 15, 0, 0, 10) },
        { 10, new Equip(10, "Armor1", "Any", 1, 10, 0, 0, 20, 0, 0, 10) },
        { 11, new Equip(11, "Armor2", "Any", 1, 10, 0, 0, 20, 0, 0, 10) },
        { 12, new Equip(12, "Boot1", "Any", 1, 5, 0, 0, 10, 0, 0, 10) },
        { 13, new Equip(13, "Boot2", "Any", 1, 5, 0, 0, 12, 0, 0, 10) },
        { 14, new Equip(14, "Boot3", "Any", 1, 5, 0, 0, 15, 0, 0, 10) },
        { 15, new Equip(15, "Braser1", "Any", 1, 5, 0, 0, 10, 0, 0, 10) },
        { 16, new Equip(16, "Braser2", "Any", 1, 5, 0, 5, 10, 0, 0, 10) },
        { 17, new Equip(17, "Glove1", "Any", 1, 5, 0, 10, 5, 0, 0, 10) },
        { 18, new Equip(18, "Glove2", "Any", 1, 5, 0, 3, 6, 0, 0, 10) },
        { 19, new Equip(19, "Glove3", "Any", 1, 5, 0, 2, 10, 0, 0, 10) },
        { 20, new Equip(20, "Helmet1", "Any", 1, 20, 0, 0, 20, 0, 0, 10) },
        { 21, new Equip(21, "Helmet2", "Any", 1, 20, 0, 0, 15, 0, 0, 10) },
        { 22, new Equip(22, "Helmet3", "Any", 1, 20, 0, 0, 10, 0, 0, 10) },
        { 23, new Equip(23, "Ring1", "Any", 1, 0, 10, 5, 5, 0, 0, 10) },
        { 24, new Equip(24, "Ring2", "Any", 1, 0, 10, 6, 6, 0, 0, 10) },
        { 25, new Equip(25, "Shield", "Any", 1, 20, 0, 0, 10, 0, 0, 10) }
    };



}
