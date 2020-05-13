using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mute : MonoBehaviour {

	public bool mute;
	public Toggle togl;
	int berd;

	void Awake () {
		berd = PlayerPrefs.GetInt ("Berdlllk2", 1);

		if (berd == 1) {
			PlayerPrefs.SetInt ("mute", 1);
			mute = false;
			togl.isOn = true;
			PlayerPrefs.SetInt ("Berdlllk2", 2);
		}
		if (PlayerPrefs.GetInt ("mute") == 1) {

			togl.isOn = true;
			mute = false;
		} else {

			togl.isOn = false;
			mute = true;
		}
	}


	public void OnToggleChanged () {

		mute = !mute;


	}

	void Update () {

		if (mute == true) {
			AudioListener.pause = true;
			PlayerPrefs.SetInt ("mute", 2);
		}

		if (mute == false) {
			AudioListener.pause = false;
			PlayerPrefs.SetInt ("mute", 1);
		}
	}
}
