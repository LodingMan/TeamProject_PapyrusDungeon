using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Intro_UI_Disable_Script : MonoBehaviour
{
    public bool isLoaded = false;
    public float timer1 = 0f;
    public BannerAds banner;

    private void Update()
    {
        if (timer1 < 2)
        {
            timer1 += Time.deltaTime;
        }
        if (timer1 > 2)
        {
            isLoaded = true;
        }
        if (isLoaded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                banner.HideBannerAd();
                SceneManager.LoadScene(1);
            }
        }

    }

}
