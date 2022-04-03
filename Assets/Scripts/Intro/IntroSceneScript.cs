using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneScript : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

}
