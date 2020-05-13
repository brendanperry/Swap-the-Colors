using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneChange : MonoBehaviour {

	public void OnClick (string LevelToLoad){
		SceneManager.LoadSceneAsync (LevelToLoad);
		Time.timeScale = 1;
	}
}
