using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_CombatManager : MonoBehaviour
{
    public GameObject[] myParty = new GameObject[3];
    public GameObject[] enemys = new GameObject[3];
    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;

    public void Init_Dungeon_Party()
    {
        //�ϴ� �����Դٰ� �����Ѵ�. 
    }

    //������ ���۵Ǹ� �� ��ġ ���̺��� �������� �� �����;ߵ�. 
    //Dictionary�� �����Ѵٰ� �����Ѵٸ�, 1�������� �ϸ� ������, ���̷���, �������, 2�������� �ϸ� �ں�Ʈ , ��, ��� �̷��� 3���� �����λ�������ߵ�
    private void Start()
    {
        for(int i = 0; i< enemys.Length; i++)//�ϴ� �׳� �迭 �������°ɷ� �ϴµ� ���߿��� �� �迭�� ���� ��ġ ���̺� �ִ� ���� �����ͼ� ä������ �ȴٴ°�. 
        {
            Instantiate(enemys[i], new Vector3((i+1) * 2, 0, 0), transform.rotation); //��ġ�� �ӽô�. 
        }

    }

    


}
