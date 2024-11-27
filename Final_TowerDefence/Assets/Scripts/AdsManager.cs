using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class BannerAdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{
    private float timer;
    bool visivel;

    private void Start()
    {
        timer = 10f;

        Advertisement.Initialize("5738214", true, this);

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);


    }
    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }

    void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    void IUnityAdsShowListener.OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new System.NotImplementedException();
    }

    void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }
}
