using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Shin {

    public class DownBtnManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool isBtn = false;
        public Button Btn;
        public RectTransform content;
        public float spd = 500f;
        private void Update()
        {
            if (isBtn)
            {
                content.GetComponent<RectTransform>().transform.Translate(0, spd * Time.deltaTime, 0);

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



