using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {

	controllerTut Controller;
	tut Tut;
	float screenWidthHalf;

	public AudioSource audi;

	void Start () {
		Controller = GameObject.Find ("controller2").GetComponent<controllerTut> ();
		screenWidthHalf = Screen.width / 2;
		Tut = GameObject.Find ("tut").GetComponent<tut> ();
	}

	bool leftF = true;

	void firstMoveLeft() {
		if (Input.GetMouseButtonDown (0) && leftF == true) {
			if (Input.mousePosition.x < screenWidthHalf) {
				Controller.CancelInvoke ();
				Controller.InvokeRepeating ("Move_Left1", 0, .01667f);
				leftF = false;
				Tut.StartCoroutine ("stopBlue");
				audi.Play ();
			}
		}
	}

	bool rightF = true;

	void moveRight() {
		if (Input.GetMouseButtonDown (0) && rightF == true) {
			if (Input.mousePosition.x >= screenWidthHalf) {
				Controller.InvokeRepeating ("Move_Right4", 0, .01667f);
				rightF = false;
				Tut.StartCoroutine ("endTut");
				audi.Play ();
			}
		}
	}

	void end () {
		if(Input.GetMouseButtonDown(0)){
			SceneManager.LoadSceneAsync ("Game");
		}
	}
}
