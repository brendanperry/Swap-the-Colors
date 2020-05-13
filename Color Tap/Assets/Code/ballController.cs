using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour {

	public float speed = 2f;
	public float killTime;

	void OnEnable () {
		StartCoroutine ("Deactivate");
		speed = PlayerPrefs.GetFloat ("speed", 2);
	}

	void Start () {
		
	}

	void Update () {
			transform.Translate (Vector2.down * speed * Time.deltaTime);
	}

	IEnumerator Deactivate () {
		yield return new WaitForSeconds (killTime);
		gameObject.SetActive (false);
	}
}
