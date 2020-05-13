using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class playButton : MonoBehaviour {

	int tut;

	void Start () {
		tut = PlayerPrefs.GetInt ("tutorial", 1);
	}

	public void OnClick (string LevelToLoad){
		if (tut == 1) {
			SceneManager.LoadSceneAsync ("Tutorial");
			PlayerPrefs.SetInt ("tutorial", 2);
		} else {
			SceneManager.LoadSceneAsync (LevelToLoad);
		}
	}
}
