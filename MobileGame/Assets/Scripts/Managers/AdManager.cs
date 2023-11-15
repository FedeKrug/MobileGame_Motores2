using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
	public string adType = "Rewarded_Android";


	void Start()
	{
		Advertisement.Initialize("5449385", false);
		Advertisement.AddListener(this);
	}

	public void ShowAd()
	{
		if (!Advertisement.IsReady())
			return;


		Advertisement.Show(adType);
	}

	public void OnUnityAdsReady(string placementId)
	{
		ShowAd();
		Debug.Log("Terminó de inicializar");
	}

	public void OnUnityAdsDidError(string message)
	{
	}

	public void OnUnityAdsDidStart(string placementId)
	{
	}

	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		Debug.Log(showResult.ToString());
	}
}
