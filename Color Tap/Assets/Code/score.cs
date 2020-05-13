using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Prime31;

public class score : MonoBehaviour {

	public int Score = 0;
	Text text;
	int highScore;
	bool canScore = true;

	public GameObject restart;
	public GameObject home;
	public GameObject highScoreText;
	public GameObject pause;
	controller Controller;

	public AudioSource gameOver;

	bool canPlayNoise;

	int AdCheck;

	// Use this for initialization
	void Start () {
		canPlayNoise = true;
		text = GetComponent<Text> ();
		highScore = PlayerPrefs.GetInt ("highScore", 0);
		try {
			Controller = GameObject.Find ("TapController").GetComponent<controller> ();
		}
		catch{}
	}

	public void up(){
		if(canScore == true){
			Score++;
			text.text = "" + Score;
		}
	}

	public void End () {
		if(canPlayNoise == true){
			gameOver.Play ();
			canPlayNoise = false;
		}


		if (Score > highScore) {
			highScore = Score;
			PlayerPrefs.SetInt ("highScore", highScore);
			GameCenterBinding.reportScore (highScore, "topScore");
		}

		highScoreText.GetComponent<Text> ().text = "BEST: " + highScore;
			
		canScore = false;
		Controller.enabled = false;
		restart.SetActive (true);
		home.SetActive (true);
		highScoreText.SetActive (true);
		pause.SetActive (false);

		PlayerPrefs.DeleteKey ("greenCube");
		PlayerPrefs.DeleteKey ("redCube");
		PlayerPrefs.DeleteKey ("yellowCube");
		PlayerPrefs.DeleteKey ("blueCube");
	}
}
