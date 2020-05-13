using UnityEngine;
using System.Collections;

public class soundfx : MonoBehaviour {

	void OnEnable() {
		DontDestroyOnLoad (this.gameObject);
		StartCoroutine (countDown ());
	}

	IEnumerator countDown() {
		yield return new WaitForSeconds (1f);
		Destroy (this.gameObject);
	}
}
