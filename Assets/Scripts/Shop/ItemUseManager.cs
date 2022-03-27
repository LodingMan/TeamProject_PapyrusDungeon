using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseManager : MonoBehaviour //������ �����ؼ� ������ ������ ������ �ٲٴ� ��ũ��Ʈ�Դϴ�. 03-27������
{
    public Stat stats;
    public string heroName; //���� ���õ� ������Ʈ�� �̸�
    public bool isActive = false; // �ߺ� Ŭ�� ������ ���� bool�� �Դϴ�.


    void Update()
    {
            if (Input.GetMouseButtonDown(0)) // ������Ʈ Ŭ�� �� ���� �������� ��ũ��Ʈ�Դϴ�. ���Ŀ� ��ġ�� �ٲ� �����Դϴ�.
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Player") // ���̸� ���� �±װ� Player�̸� �� ������Ʈ�� ������ �����ɴϴ�.
                    {                                             // �� �Ŀ� ItemScripts�� �ִ� �Լ��� ���� ������ �����մϴ�.
                        isActive = true;
                        stats = hit.transform.gameObject.GetComponent<StatScript>().myStat;
                        heroName = hit.transform.gameObject.name;
                        Debug.Log("{" + heroName + "} �� ���� �ϼ̽��ϴ�.");
                    }

                }
            }

    }


}
