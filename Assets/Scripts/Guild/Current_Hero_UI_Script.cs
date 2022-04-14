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


        //shin
        public ManagerTable MgrTable;
        Shin.HeroImageTable heroImageTable;
        UI_SoundMgr soundMgr;
        public Text HP;
        public Text MP;
        public Text curStateText;
        public Image heroIcon;
        public Image state;
        public Sprite[] stateSprite;
        

        private void Start()
        {
            uI_Central = GameObject.Find("Canvas").GetComponent<UI_Central>();
            Debug.Log(uI_Central);
            MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
            hero_Status_UI_Script = GameObject.Find("Status_UI").GetComponent<Song.Hero_Status_UI_Script>();
            heroImageTable = MgrTable.heroImageTable;
            soundMgr = MgrTable.soundMgr;
            root = transform.root;
            canvasGroup = GetComponent<CanvasGroup>();
            switch (This_Prefab_Object.GetComponent<StatScript>().myStat.Job)
            {
                case "Babarian":
                    heroIcon.sprite = heroImageTable.sprite[0];
                    break;
                case "Archer":
                    heroIcon.sprite = heroImageTable.sprite[1];
                    break;
                case "Knight":
                    heroIcon.sprite = heroImageTable.sprite[2];
                    break;
                case "Barristan":
                    heroIcon.sprite = heroImageTable.sprite[3];
                    break;
                case "Mage":
                    heroIcon.sprite = heroImageTable.sprite[4];
                    break;
                case "Porter":
                    heroIcon.sprite = heroImageTable.sprite[5];
                    break;
                default:
                    break;
            }
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

            switch (curStateText.text)
            {
                case "isHealing":
                    state.sprite = stateSprite[1];
                    break;
                case "isTraining":
                    state.sprite = stateSprite[2];
                    break;
                case "isParty":
                    state.sprite = stateSprite[3];
                    break;
                default:
                    state.sprite = stateSprite[0];
                    break;
            }
            HP.text = "HP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.HP + " / " + This_Prefab_Object.GetComponent<StatScript>().myStat.MAXHP;
            MP.text = "MP : " + This_Prefab_Object.GetComponent<StatScript>().myStat.MP + " / " + This_Prefab_Object.GetComponent<StatScript>().myStat.MAXMP;

            //if (PointerDonwTime > 0.5f)
            //{


            //}


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
                //Debug.Log("�������ͽ�â ���");
               // root.BroadcastMessage("Open_Status_UI", SendMessageOptions.DontRequireReceiver); // ���� transform ������ UI_Central(Hierarchy�� �����ϴ� Canvers)�� "Drag"��� �̸��� �Լ��� ������. 
                hero_Status_UI_Script.Open_Status_UI(This_Prefab_Object);
                soundMgr.PlayClipBtn();
                PointerDonwTime = 0;
                isPointerDown = false;
            }
        }

        public void Pointer_Down()
        {
            //Debug.Log("PointerDown");
            isPointerDown = true;
            isDrag = true;
            uI_Central.Catch_Hero_Object = This_Prefab_Object;
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
            soundMgr.PlayClipContent();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
            canvasGroup.blocksRaycasts = true;
            uI_Central.Catch_Hero_Object = null;
            soundMgr.PlayClipContent();
            MgrTable.TutorialMgr.GuildTuto02Off();
        }

    }
}
