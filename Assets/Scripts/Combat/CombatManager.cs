using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject[] myParty = new GameObject[3];
    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;

    public void Init_Dungeon_Party()
    {
        myParty = guildManager.Party_Hero_Member;
        //DungeonSelectManager���� DungeonType������
        //myParty�� �ִ� Hero������Ʈ�� �׺� ����
        //myParty�� �ִ� Hero������Ʈ ���� ������ġ�� �ű�.
        //���� Start���� �����ϴ� �� ������ �� �Լ� ȣ�� �ñ�� �ٲ�. 
        //�̴ϸ� ī�޶� Ȱ��ȭ
        //Enemy��ġ (�����س���)
        //
        //
    }

    

    
}
