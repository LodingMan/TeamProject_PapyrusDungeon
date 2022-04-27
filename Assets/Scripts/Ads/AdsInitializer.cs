using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{

    string gameId;


    void Start()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameId = "4723128";
        Advertisement.Initialize(gameId, false);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }





}