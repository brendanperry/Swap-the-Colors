using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Prime31;

public class bootUp : MonoBehaviour {

	public string scene;

	void Awake () {
		GameCenterBinding.authenticateLocalPlayer ();
	}

	void Start () {

		string[] products = new string[] { "removeAds_1" };
		StoreKitBinding.requestProductData (products);

		StartCoroutine (begin ());
	}

	IEnumerator begin (){
		yield return new WaitForSeconds (5);
		SceneManager.LoadSceneAsync (scene);
	}
}
