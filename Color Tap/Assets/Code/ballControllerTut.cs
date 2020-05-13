using UnityEngine;
using System.Collections;

public class ballControllerTut : MonoBehaviour {

	public float speed = 2f;

	void Update () {
		transform.Translate (Vector2.down * speed * Time.deltaTime);
	}
}
