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
        { 0, new Equip(0, "EquipName1", 10, 0) }, //Equip�� �ɹ������� ClassBundleȮ��
        { 1, new Equip(1, "EquipName2", 5, 5) },
        { 2, new Equip(2, "EquipName3", 0, 10) }
    };



}
