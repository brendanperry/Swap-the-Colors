using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class controller : MonoBehaviour {

	Vector3 mousePos;
	Vector3 touchPos;
	float screenWidthHalf;

	public Transform cube1;
	public Transform cube2;
	public Transform cube3;
	public Transform cube4;

	Vector3 pos1;
	Vector3 pos2;
	Vector3 pos3;
	Vector3 pos4;

	public float speed = 1f;

	SpriteRenderer sprite;

	public int startAmount = 6;
	public float fireTime = 0;
	public float initialFireTime = 0;

	public GameObject redCubes;
	List<GameObject> redObjects; 

	public GameObject greenCubes;
	List<GameObject> greenObjects; 

	public GameObject blueCubes;
	List<GameObject> blueObjects; 

	public GameObject yellowCubes;
	List<GameObject> yellowObjects; 

	private Vector2 leftMove;
	private Vector2 rightMove;

	public float checkWaitTime = 2f;

	public AudioSource audi;

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}

	void Start () {
		screenWidthHalf = Screen.width / 2;

		pos1 = cube1.position;
		pos2 = cube2.position;
		pos3 = cube3.position;
		pos4 = cube4.position;

		sprite = cube1.GetComponent<SpriteRenderer> ();

		leftMove =  new Vector2 (pos1.x - sprite.bounds.size.x, pos1.y);
		rightMove = new Vector2 (pos4.x + sprite.bounds.size.x, pos1.y);	

		int redAmount = 0;

		redObjects = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj = (GameObject)Instantiate (redCubes);
			obj.SetActive (false);
			if (redAmount < 1) {
				obj.transform.position = new Vector2 (pos1.x - sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			} else {
				obj.transform.position = new Vector2 (pos4.x + sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			}
			redAmount++;
			redObjects.Add (obj);
		}

		int greenAmount = 0;

		greenObjects = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj = (GameObject)Instantiate (greenCubes);
			obj.SetActive (false);
			if (greenAmount < 1) {
				obj.transform.position = new Vector2 (pos1.x - sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			} else {
				obj.transform.position = new Vector2 (pos4.x + sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			}
			greenAmount++;
			greenObjects.Add (obj);
		}

		int blueAmount = 0;

		blueObjects = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj = (GameObject)Instantiate (blueCubes);
			obj.SetActive (false);
			if (blueAmount < 1) {
				obj.transform.position = new Vector2 (pos1.x - sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			} else {
				obj.transform.position = new Vector2 (pos4.x + sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			}
			blueAmount++;
			blueObjects.Add (obj);
		}

		int yellowAmount = 0;

		yellowObjects = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj = (GameObject)Instantiate (yellowCubes);
			obj.SetActive (false);
			if (yellowAmount < 1) {
				obj.transform.position = new Vector2 (pos1.x - sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			} else {
				obj.transform.position = new Vector2 (pos4.x + sprite.bounds.size.x, pos1.y);
				obj.transform.localScale = cube1.localScale;
				obj.AddComponent <BoxCollider2D>();
				obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			}
			yellowAmount++;
			yellowObjects.Add (obj);
		}
	}

	void Update () {

		// Mouse click on right side of screen
		if (Input.GetMouseButtonDown (0)) {
			if (!IsPointerOverUIObject ()) {
				if (Input.mousePosition.x >= screenWidthHalf) {
					if (cube1.position == pos1 && cube4.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Right1", 0, .01667f);
						audi.Play ();
					} else if (cube2.position == pos1 && cube1.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Right4", 0, .01667f);
						audi.Play ();
					} else if (cube3.position == pos1 && cube2.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Right3", 0, .01667f);
						audi.Play ();
					} else if (cube4.position == pos1 && cube3.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Right2", 0, .01667f);
						audi.Play ();
					}
				}
			

		// Mouse click on left side of screen

		 else if (Input.mousePosition.x < screenWidthHalf) {
					if (cube1.position == pos1 && cube4.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Left1", 0, .01667f);
						audi.Play ();
					} else if (cube2.position == pos1 && cube1.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Left2", 0, .01667f);
						audi.Play ();
					} else if (cube3.position == pos1 && cube2.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Left3", 0, .01667f);
						audi.Play ();
					} else if (cube4.position == pos1 && cube3.position == pos4) {
						CancelInvoke ();
						InvokeRepeating ("Move_Left4", 0, .01667f);
						audi.Play ();
					}
				}
			}
		}
	}

	// Tap on right and green is at left-most position

	void Move_Right1 () {
		cube1.position = Vector2.MoveTowards (cube1.position, pos2, speed * Time.deltaTime);
		cube2.position = Vector2.MoveTowards (cube2.position, pos3, speed * Time.deltaTime);
		cube3.position = Vector2.MoveTowards (cube3.position, pos4, speed * Time.deltaTime);
		blueObjects [0].SetActive (true);
		blueObjects [0].transform.position = Vector2.MoveTowards (blueObjects [0].transform.position, pos1, speed * Time.deltaTime);
		cube4.position = Vector2.MoveTowards (cube4.position, rightMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 1);
		PlayerPrefs.SetInt ("redCube", 2);
		PlayerPrefs.SetInt ("yellowCube", 3);
		PlayerPrefs.SetInt ("blueCube", 0);
		StartCoroutine ("Move_Right1Check");
	}

	IEnumerator Move_Right1Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Right1");
		cube4.position = pos1;
		blueObjects [0].SetActive (false);
		blueObjects [0].transform.position = leftMove;
		StopCoroutine ("Move_Right1Check");
	}

	// Tap on right and blue is at left-most position

	void Move_Right2 () {
		cube1.position = Vector2.MoveTowards (cube1.position, pos3, speed * Time.deltaTime);
		cube2.position = Vector2.MoveTowards (cube2.position, pos4, speed * Time.deltaTime);
		cube4.position = Vector2.MoveTowards (cube4.position, pos2, speed * Time.deltaTime);
		yellowObjects [0].SetActive (true);
		yellowObjects [0].transform.position = Vector2.MoveTowards (yellowObjects [0].transform.position, pos1, speed * Time.deltaTime);
		cube3.position = Vector2.MoveTowards (cube3.position, rightMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 2);
		PlayerPrefs.SetInt ("redCube", 3);
		PlayerPrefs.SetInt ("yellowCube", 0);
		PlayerPrefs.SetInt ("blueCube", 1);
		StartCoroutine ("Move_Right2Check");
	}

	IEnumerator Move_Right2Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Right2");
		cube3.position = pos1;
		yellowObjects [0].SetActive (false);
		yellowObjects [0].transform.position = leftMove;
		StopCoroutine ("Move_Right2Check");
	}

	// Tap on Right and yellow is at left-most position

	void Move_Right3 () {
		cube1.position = Vector2.MoveTowards (cube1.position, pos4, speed * Time.deltaTime);
		cube3.position = Vector2.MoveTowards (cube3.position, pos2, speed * Time.deltaTime);
		cube4.position = Vector2.MoveTowards (cube4.position, pos3, speed * Time.deltaTime);
		redObjects [0].SetActive (true);
		redObjects [0].transform.position = Vector2.MoveTowards (redObjects [0].transform.position, pos1, speed * Time.deltaTime);
		cube2.position = Vector2.MoveTowards (cube2.position, rightMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 3);
		PlayerPrefs.SetInt ("redCube", 0);
		PlayerPrefs.SetInt ("yellowCube", 1);
		PlayerPrefs.SetInt ("blueCube", 2);
		StartCoroutine ("Move_Right3Check");
	}

	IEnumerator Move_Right3Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Right3");
		cube2.position = pos1;
		redObjects [0].SetActive (false);
		redObjects [0].transform.position = leftMove;
		StopCoroutine ("Move_Right3Check");
	}

	// Tap on right and red is at left-most position

	void Move_Right4 () {
		cube2.position = Vector2.MoveTowards (cube2.position, pos2, speed * Time.deltaTime);
		cube3.position = Vector2.MoveTowards (cube3.position, pos3, speed * Time.deltaTime);
		cube4.position = Vector2.MoveTowards (cube4.position, pos4, speed * Time.deltaTime);
		greenObjects [0].SetActive (true);
		greenObjects [0].transform.position = Vector2.MoveTowards (greenObjects [0].transform.position, pos1, speed * Time.deltaTime);
		cube1.position = Vector2.MoveTowards (cube1.position, rightMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 0);
		PlayerPrefs.SetInt ("redCube", 1);
		PlayerPrefs.SetInt ("yellowCube", 2);
		PlayerPrefs.SetInt ("blueCube", 3);
		StartCoroutine ("Move_Right4Check");
	}

	IEnumerator Move_Right4Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Right4");
		cube1.position = pos1;
		greenObjects [0].SetActive (false);
		greenObjects [0].transform.position = leftMove;
		StopCoroutine ("Move_Right4Check");
	}

	// Tap on left and green is at left-most position

	void Move_Left1 () {
		cube4.position = Vector2.MoveTowards (cube4.position, pos3, speed * Time.deltaTime);
		cube2.position = Vector2.MoveTowards (cube2.position, pos1, speed * Time.deltaTime);
		cube3.position = Vector2.MoveTowards (cube3.position, pos2, speed * Time.deltaTime);
		greenObjects [1].SetActive (true);
		greenObjects [1].transform.position = Vector2.MoveTowards (greenObjects [1].transform.position, pos4, speed * Time.deltaTime);
		cube1.position = Vector2.MoveTowards (cube1.position, leftMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 3);
		PlayerPrefs.SetInt ("redCube", 0);
		PlayerPrefs.SetInt ("yellowCube", 1);
		PlayerPrefs.SetInt ("blueCube", 2);
		StartCoroutine ("Move_Left1Check");
	}

	IEnumerator Move_Left1Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Left1");
		cube1.position = pos4;
		greenObjects [1].SetActive (false);
		greenObjects [1].transform.position = rightMove;
		StopCoroutine ("Move_Left1Check");
	}

	// Tap on left and red is at left-most position

	void Move_Left2 () {
		cube4.position = Vector2.MoveTowards (cube4.position, pos2, speed * Time.deltaTime);
		cube1.position = Vector2.MoveTowards (cube1.position, pos3, speed * Time.deltaTime);
		cube3.position = Vector2.MoveTowards (cube3.position, pos1, speed * Time.deltaTime);
		redObjects [1].SetActive (true);
		redObjects [1].transform.position = Vector2.MoveTowards (redObjects [1].transform.position, pos4, speed * Time.deltaTime);
		cube2.position = Vector2.MoveTowards (cube2.position, leftMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 2);
		PlayerPrefs.SetInt ("redCube", 3);
		PlayerPrefs.SetInt ("yellowCube", 0);
		PlayerPrefs.SetInt ("blueCube", 1);
		StartCoroutine ("Move_Left2Check");
	}

	IEnumerator Move_Left2Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Left2");
		cube2.position = pos4;
		redObjects [1].SetActive (false);
		redObjects [1].transform.position = rightMove;
		StopCoroutine ("Move_Left2Check");
	}

	// Tap on left and yellow is at left-most position

	void Move_Left3 () {
		cube4.position = Vector2.MoveTowards (cube4.position, pos1, speed * Time.deltaTime);
		cube1.position = Vector2.MoveTowards (cube1.position, pos2, speed * Time.deltaTime);
		cube2.position = Vector2.MoveTowards (cube2.position, pos3, speed * Time.deltaTime);
		yellowObjects [1].SetActive (true);
		yellowObjects [1].transform.position = Vector2.MoveTowards (yellowObjects [1].transform.position, pos4, speed * Time.deltaTime);
		cube3.position = Vector2.MoveTowards (cube3.position, leftMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 1);
		PlayerPrefs.SetInt ("redCube", 2);
		PlayerPrefs.SetInt ("yellowCube", 3);
		PlayerPrefs.SetInt ("blueCube", 0);
		StartCoroutine ("Move_Left3Check");
	}

	IEnumerator Move_Left3Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Left3");
		cube3.position = pos4;
		yellowObjects [1].SetActive (false);
		yellowObjects [1].transform.position = rightMove;
		StopCoroutine ("Move_Left3Check");
	}

	// Tap on left and blue is at left-most position

	void Move_Left4 () {
		cube3.position = Vector2.MoveTowards (cube3.position, pos3, speed * Time.deltaTime);
		cube1.position = Vector2.MoveTowards (cube1.position, pos1, speed * Time.deltaTime);
		cube2.position = Vector2.MoveTowards (cube2.position, pos2, speed * Time.deltaTime);
		blueObjects [1].SetActive (true);
		blueObjects [1].transform.position = Vector2.MoveTowards (blueObjects [1].transform.position, pos4, speed * Time.deltaTime);
		cube4.position = Vector2.MoveTowards (cube4.position, leftMove, speed * Time.deltaTime);
		PlayerPrefs.SetInt ("greenCube", 0);
		PlayerPrefs.SetInt ("redCube", 1);
		PlayerPrefs.SetInt ("yellowCube", 2);
		PlayerPrefs.SetInt ("blueCube", 3);
		StartCoroutine ("Move_Left4Check");
	}

	IEnumerator Move_Left4Check(){
		yield return new WaitForSeconds (checkWaitTime);
		CancelInvoke ("Move_Left4");
		cube4.position = pos4;
		blueObjects [1].SetActive (false);
		blueObjects [1].transform.position = rightMove;
		StopCoroutine ("Move_Left4Check");
	}
}
