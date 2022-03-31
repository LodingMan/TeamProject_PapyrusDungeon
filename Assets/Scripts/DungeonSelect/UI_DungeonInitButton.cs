using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Shin
{
    public class UI_DungeonInitButton : MonoBehaviour
    {
        Button btn;
        public GameObject canvas_Town;
        public GameObject camera_Town;
        public GameObject canvas_Tent;        
        public GameObject camera_Tent;
        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(OnClickBtn);
        }

        public void OnClickBtn()
        {
            if (camera_Town.activeSelf == true)
            {
                camera_Town.SetActive(false);
                camera_Tent.SetActive(true);
            }
            if (canvas_Town.activeSelf == true)
            {
                canvas_Town.SetActive(false);
                canvas_Tent.SetActive(true);
            }
            
        }
    }
}

