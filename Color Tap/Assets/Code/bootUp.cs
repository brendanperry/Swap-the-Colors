using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.GameCenter;

public class bootUp : MonoBehaviour {

	public string scene;

	void Awake () {
		GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
		Social.localUser.Authenticate(success => {
            if (success)
                Debug.Log("authenticated");
            else
                Debug.Log("Failed to authenticate");
        });
	}

	void Start () {

		//string[] products = new string[] { "removeAds_1" };
		//StoreKitBinding.requestProductData (products);

		StartCoroutine (begin ());
	}

	IEnumerator begin (){
		yield return new WaitForSeconds (5);
		SceneManager.LoadSceneAsync (scene);
	}
}
