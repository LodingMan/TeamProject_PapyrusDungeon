using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    //public BannerAds ads;

    void Start()
    {
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(2);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            timer += Time.deltaTime;
            if (timer > 10)
            {
                //ads.HideBanner();
                op.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
