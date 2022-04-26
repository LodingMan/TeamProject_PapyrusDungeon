using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _androidAdUnitId = "banner";
    string _adUnitId = null;

    void Start()
    {
        _adUnitId = _androidAdUnitId;
        Advertisement.Initialize("4723128", true);
        Advertisement.Banner.SetPosition(_bannerPosition);
        LoadBanner();
        ShowBannerAd();

    }


    public void LoadBanner()
    {
        Advertisement.Banner.Load(_adUnitId);
    }


    void ShowBannerAd()
    {
        Advertisement.Banner.Show(_adUnitId);
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

}