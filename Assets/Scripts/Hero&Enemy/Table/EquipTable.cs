using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 03/26�� �߰��� ��ũ��Ʈ
// ��� ����� ���� �����ϴ� ���̺�
// ���⿡ �ִ� ���� �ٸ� ��ũ��Ʈ���� ����Ϸ��� EquipTable equipTable = new EquipTable(); ����ϸ� �� Ŭ������ �ִ� ���� ������ �� �ִ�.  
public class EquipTable
{
    public Dictionary<int, Equip> initEquip = new Dictionary<int, Equip>()
    {
        // �ε���, �̸�, ����, ����, hp, mp, atk, def, cri, acc, cost ������ �߰� ��Ŵ 04/05 ������
        // ��� ���� ���� ���� �߰� 04/24 ������
        { 1, new Equip(1, "Sword", "Knight", 1, 0, 0, 10, 0, 0, 0, 20,0) }, //Equip�� �ɹ������� ClassBundleȮ��
        { 2, new Equip(2, "Axe", "Barristan", 1, 0, 0, 10, 0, 0, 0, 20,0) },
        { 3, new Equip(3, "Bow", "Archer", 1, 0, 0, 10, 0, 0, 0, 20,0) },
        { 4, new Equip(4, "Knife", "Porter" ,1 ,0 ,0, 10, 0, 0, 0, 20,0) },
        { 5, new Equip(5, "DoubleAxe","Babarian", 1, 0, 0, 20, 0, 0, 0, 20,0) },
        { 6, new Equip(6, "Saber", "Knight", 1, 0, 0, 10, 0, 0, 0, 20,0) },
        { 7, new Equip(7, "Wand", "Mage", 1, 0, 0, 10, 0, 0, 0, 20,0) },
        { 8, new Equip(8, "Amulet1", "Any", 1, 10, 0, 0, 10, 0, 0, 500,0) },
        { 9, new Equip(9, "Amulet2", "Any", 1, 10, 0, 0, 12, 0, 0, 500,0) },
        { 10, new Equip(10, "Amulet3", "Any", 1, 10, 0, 0, 15, 0, 0, 500,0) },
        { 11, new Equip(11, "Armor1", "Any", 1, 10, 0, 0, 20, 0, 0, 500,0) },
        { 12, new Equip(12, "Armor2", "Any", 1, 10, 0, 0, 20, 0, 0, 500,0) },
        { 13, new Equip(13, "Boot1", "Any", 1, 5, 0, 0, 10, 0, 0, 500,0) },
        { 14, new Equip(14, "Boot2", "Any", 1, 5, 0, 0, 12, 0, 0, 500,0) },
        { 15, new Equip(15, "Boot3", "Any", 1, 5, 0, 0, 15, 0, 0, 500,0) },
        { 16, new Equip(16, "Armor3", "Any", 1, 15, 0, 0, 15, 0, 0, 500,0) },
        { 17, new Equip(17, "Armor4", "Any", 1, 10, 0, 5, 15, 0, 0, 500,0) },
        { 18, new Equip(18, "Glove1", "Any", 1, 5, 0, 10, 5, 0, 0, 500,0) },
        { 19, new Equip(19, "Glove2", "Any", 1, 5, 0, 3, 6, 0, 0, 500,0) },
        { 20, new Equip(20, "Armor5", "Any", 1, 20, 0, 0, 15, 0, 0, 500,0) },
        { 21, new Equip(21, "Helmet1", "Any", 1, 20, 0, 0, 20, 0, 0, 500,0) },
        { 22, new Equip(22, "Helmet2", "Any", 1, 20, 0, 0, 15, 0, 0, 500,0) },
        { 23, new Equip(23, "Helmet3", "Any", 1, 20, 0, 0, 10, 0, 0, 500,0) },
        { 24, new Equip(24, "Ring1", "Any", 1, 0, 10, 5, 5, 0, 0, 500,0) },
        { 25, new Equip(25, "Ring2", "Any", 1, 0, 10, 6, 6, 0, 0, 500,0) },
        { 26, new Equip(26, "Shield", "Any", 1, 20, 0, 0, 10, 0, 0, 500,0) }
    };


}
