using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//=========================================================//
//�巡��&��� �������̽��� ��ӹ޾� ����ϸ�, �ش� ��ũ��Ʈ��  //
//��� Current_Hero_UI��������Ʈ ���·� �����Ǿ��ֽ��ϴ�.    //
//=======================================================//

namespace Song
{


    public class Current_Hero_UI_Script : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler//, IDropHandler
    {
        private CanvasGroup canvasGroup;
        Transform root;
        bool isPointerDown = false; // UI�� �������� True�� ������ �巡���ϸ� ��ٷ� false�� ����ȴ�. 
        bool isDrag = false;
        float PointerDonwTime; // �ش� UI�� �巡�������ʰ� ������ ������ 2.5�ʵڿ� �������ͽ� â ���.
        public GameObject This_Prefab_Object; //�ش� UI�ϳ��� � ������Ʈ�� ����Ű�� �ִ��� ������.
        public UI_Central uI_Central;
        public Song.Hero_Status_UI_Script hero_Status_UI_Script;
        public Text HP;
        public Text MP;
        public Text curStateText;
        

        private void Start()
        {
            hero_Status_UI_Script = GameObject.Find("Status_UI").GetComponent<Song.Hero_Status_UI_Script>();
            uI_Central = GameObject.Find("Canvas").GetComponent<UI_Central>();
            root = transform.root;
            canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Update()
        {
            if (!This_Prefab_Object.GetComponent<HeroScript_Current_State>().isDead)
            {
                curStateText.text = "isWait";
            }
            if(This_Prefab_Object.GetComponent<HeroScript_Current_State>().isParty) {
                curStateText.text = "isParty";
            }
            if (This_Prefab_Object.GetComponent<HeroScript_Current_State>().isTraining)
            {
                curStateText.text = "isTraining";
            }
            if (This_Prefab_Object.GetComponent<HeroScript_Current_State>().isHealing)
            {
                curStateText.text = "isHealing";
            }
            HP.text = "HP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.HP + " / " + This_Prefab_Object.GetComponent<StatScript>().myStat.MAXHP;
            MP.text = "MP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.MP + " / " + This_Prefab_Object.GetComponent<StatScript>().myStat.MAXMP;

            if (PointerDonwTime > 0.5f)
            {
                isDrag = true;
                uI_Central.Catch_Hero_Object = This_Prefab_Object;

            }


            if (isPointerDown)
            {
                PointerDonwTime += Time.deltaTime;
            }
            else
            {
                PointerDonwTime = 0;
            }

            if (PointerDonwTime > 1.5f)
            {
                Debug.Log("�������ͽ�â ���");
                //root.BroadcastMessage("Open_Status_UI", SendMessageOptions.DontRequireReceiver); // ���� transform ������ UI_Central(Hierarchy�� �����ϴ� Canvers)�� "Drag"��� �̸��� �Լ��� ������. 
                hero_Status_UI_Script.Open_Status_UI(This_Prefab_Object);
                PointerDonwTime = 0;
                isPointerDown = false;
            }
        }

        public void Pointer_Down()
        {
            Debug.Log("PointerDown");
            isPointerDown = true;
        }

        public void Pointer_UP()
        {
            isPointerDown = false;
            isDrag = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isDrag)
            {
                gameObject.transform.position = eventData.position; //�巡���ϸ� �����
                root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver); // ���� transform ������ UI_Central(Hierarchy�� �����ϴ� Canvers)�� "Drag"��� �̸��� �Լ��� ������. 
            }
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
            isPointerDown = false;
            canvasGroup.blocksRaycasts = false;


        }

        public void OnEndDrag(PointerEventData eventData)
        {
            root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
            canvasGroup.blocksRaycasts = true;
            uI_Central.Catch_Hero_Object = null;

        }

    }
}
