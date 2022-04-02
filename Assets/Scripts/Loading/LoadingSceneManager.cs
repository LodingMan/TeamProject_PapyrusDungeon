using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(1);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            timer += Time.deltaTime;
            if (timer > 10)
            {
                op.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
