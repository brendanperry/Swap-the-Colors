using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

	public GameObject home;
	public GameObject panel;

	public void OnClick () {
		if(Time.timeScale != 0){
			Time.timeScale = 0;
			home.SetActive (true);
			panel.SetActive (true);
		} else {
			Time.timeScale = 1;
			home.SetActive (false);
			panel.SetActive (false);
		}
	}
}
