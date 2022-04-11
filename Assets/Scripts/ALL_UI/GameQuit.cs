using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameQuit : MonoBehaviour
{
    public Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(GameQuitBtn);
    }

    public void GameQuitBtn()
    {
        Application.Quit();
        Debug.Log("어플을 종료합니다");
    }
}
