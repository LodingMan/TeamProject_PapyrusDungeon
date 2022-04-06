using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Shin {

    public class UpBtnManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool isBtn = false;
        public Button Btn;
        public RectTransform content;
        public float spd = 500f;
        private void Update()
        {
            if (isBtn)
            {
                if (content.GetComponent<RectTransform>().anchoredPosition.y > 0)
                {
                    //content.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 100f);
                    content.GetComponent<RectTransform>().transform.Translate(0, -spd * Time.deltaTime,0);
                    if (content.GetComponent<RectTransform>().anchoredPosition.y < 0)
                        content.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f);

                }
                else
                {
                    content.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f);
                }
                
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isBtn = true;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            isBtn = false;
        }
    }
}



