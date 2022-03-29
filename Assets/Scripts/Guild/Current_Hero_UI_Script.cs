using UnityEngine;
using UnityEngine.EventSystems;


//=========================================================//
//드래그&드롭 인터페이스를 상속받아 사용하며, 해당 스크립트는  //
//모든 Current_Hero_UI에컴포넌트 형태로 부착되어있습니다.    //
//=======================================================//

namespace Song
{


    public class Current_Hero_UI_Script : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler//, IDropHandler
    {
        private CanvasGroup canvasGroup;
        Transform root;
        bool isPointerDown = false; // UI를 눌렀을때 True가 되지만 드래그하면 곧바로 false로 변경된다. 
        bool isDrag = false;
        float PointerDonwTime; // 해당 UI를 드래그하지않고 누르고 있으면 2.5초뒤에 스테이터스 창 출력.
        public GameObject This_Prefab_Object; //해당 UI하나가 어떤 오브젝트를 가리키고 있는지 보여줌.
        public UI_Central uI_Central;
        public Song.Hero_Status_UI_Script hero_Status_UI_Script;

        private void Start()
        {
            hero_Status_UI_Script = GameObject.Find("Status_UI").GetComponent<Song.Hero_Status_UI_Script>();
            uI_Central = GameObject.Find("Canvas").GetComponent<UI_Central>();
            root = transform.root;
            canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Update()
        {
            if (PointerDonwTime > 1f)
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

            if (PointerDonwTime > 2.5f)
            {
                Debug.Log("스테이터스창 출력");
                //root.BroadcastMessage("Open_Status_UI", SendMessageOptions.DontRequireReceiver); // 현재 transform 정보를 UI_Central(Hierarchy에 존재하는 Canvers)의 "Drag"라는 이름의 함수에 전해줌. 
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
                gameObject.transform.position = eventData.position; //드래그하면 따라옴
                root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver); // 현재 transform 정보를 UI_Central(Hierarchy에 존재하는 Canvers)의 "Drag"라는 이름의 함수에 전해줌. 
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
