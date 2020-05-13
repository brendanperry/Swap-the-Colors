using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {


	float speed;
	public GameObject spawner;
	newSpawner spawn;

	void Start () {

		spawn = spawner.GetComponent<newSpawner> ();

		StartCoroutine ("speedUp");
		PlayerPrefs.SetFloat ("speed", 2);
		speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator speedUp () {
		yield return new WaitForSeconds (10f);
		speed += .5f;
		PlayerPrefs.SetFloat ("speed", speed);
		yield return new WaitForSeconds (10f);
		speed += .5f;
		PlayerPrefs.SetFloat ("speed", speed);
		yield return new WaitForSeconds (10f);
		speed += .5f;
		PlayerPrefs.SetFloat ("speed", speed);
		yield return new WaitForSeconds (10f);
		speed += .5f;
		PlayerPrefs.SetFloat ("speed", speed);
		yield return new WaitForSeconds (10f);
		spawn.CancelInvoke ();
		spawn.InvokeRepeating ("spawn", 0, 1.25f);
		yield return new WaitForSeconds (10f);
		speed += .5f;
		PlayerPrefs.SetFloat ("speed", speed);
		yield return new WaitForSeconds (10f);
		speed += .5f;
		PlayerPrefs.SetFloat ("speed", speed);
		yield return new WaitForSeconds (11f);
		spawn.CancelInvoke ();
		spawn.InvokeRepeating ("spawn", 0, 1f);
	}
}
