using UnityEngine;
using System.Collections;

public class tut : MonoBehaviour {

	public Transform way1;
	public Transform way2;
	public Transform way3;
	public Transform way4;

	public GameObject Red;
	public GameObject Blue;

	public GameObject Text;
	public GameObject Text_2;
	public GameObject Text_3;
	public GameObject Text_4;

	public GameObject Text_6;

	public GameObject Movement;

//	controllerTut Controller;

	movement Move;

	// Use this for initialization
	void Start () {
	//	Controller = GameObject.Find ("controller2").GetComponent<controllerTut> ();
		Move = Movement.GetComponent<movement> ();
		Red.transform.position = new Vector2 (way1.position.x, 5);
		StartCoroutine ("stopRed");

	}

	IEnumerator stopRed () {
		yield return new WaitForSeconds (3f);
		Red.GetComponent<ballControllerTut> ().speed = 0;
		Text.GetComponent<Animator> ().Play ("TextFade");
		Move.InvokeRepeating ("firstMoveLeft", 0, .01667f);
		StopCoroutine ("stopRed");
	}

	IEnumerator stopBlue () {
		Red.GetComponent<ballControllerTut> ().speed = 2;
		Text.GetComponent<Animator> ().Play ("GoodBye");
		Blue.SetActive (true);
		Blue.transform.position = new Vector2 (way4.position.x, 5);
		yield return new WaitForSeconds (3f);
		Blue.GetComponent<ballControllerTut> ().speed = 0;
		Text_2.GetComponent<Animator> ().Play ("TextFade");
		Move.InvokeRepeating ("moveRight", 0, .01667f);
		StopCoroutine ("stopBlue");
	}

	IEnumerator endTut () {
		Blue.GetComponent<ballControllerTut> ().speed = 2;
		Text_2.GetComponent<Animator> ().Play ("GoodBye");
		Text_6.GetComponent<Animator> ().Play ("fadeout");
		yield return new WaitForSeconds (1);
		Text_3.GetComponent<Animator> ().Play ("TextFade");
		Text_4.GetComponent<Animator> ().Play ("TextFade");
		yield return new WaitForSeconds (1);
		Move.InvokeRepeating ("end", 0, .01667f);
		StopCoroutine ("endTut");
	}
}
