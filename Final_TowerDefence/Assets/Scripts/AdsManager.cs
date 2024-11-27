using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{
    private float timer;
    bool visivel;
    public bool visivelGeral = false;
    public static AdsManager instance;
    public bool exibindoIntersticial = false;
    
    void Awake()
    { 
     instance = this;
    }
    private void Start()
    {
        timer = 10f;

        Advertisement.Initialize("5738214", true, this);

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        Advertisement.Banner.Show("Banner_Android");

        visivel = true;
    
    }

    void Update()
    { 
        timer -= Time.deltaTime;

        if (timer <= 5 && visivel)
        {
            Advertisement.Banner.Hide();
            visivel = false;
        }
        else if (timer <= 0 && !visivel && !visivelGeral)
        {
            Advertisement.Banner.Show("Banner_Android");
            visivel = true;

        }
        
    }

    public void Interticial(bool podePular)
    {
        Advertisement.Banner.Hide();
        visivel = false;

        if (podePular)
        {
            Advertisement.Show("Interstitial_Android");
            visivelGeral = true;
        }
        else
        {
            Advertisement.Show("Pulavel_Intersticial");
        }
        exibindoIntersticial = true;

    }
    // Callbacks da exibição de anúncios
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == "Rewarded_Android" && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Player earned reward!");
        }
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
