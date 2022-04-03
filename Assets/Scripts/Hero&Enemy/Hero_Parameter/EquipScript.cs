using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 03/26에 추가된 스크립트
public class EquipScript : MonoBehaviour
{
    public Equip[] myEquip = new Equip[2]; // 현재 플레이어가 장착하고 있는 장비 
                                           // HeroManager에서 별도로 초기화 하지 않아 초기값은 비어있음
                                           // 추후 상점, 몬스터 드랍등으로 얻은 장비를 장착할때 이 값의 변화가 있으면 된다.
}
