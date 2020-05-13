using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public Transform way0;
	public Transform way1;
	public Transform way2;
	public Transform way3;

	public float speed = 1;
	public float waitTime = .5f;

	public Transform cube_1;
	public Transform cube_2;
	public Transform cube_3;

	public Transform parent;
	public Transform rot_1;

	bool go = true;

	void Start () {
		StartCoroutine ("moveIt");
	}

	IEnumerator moveIt () {
		go = true;
		InvokeRepeating ("Move_1", 0, .01667f);

		yield return new WaitForSeconds (waitTime);
		CancelInvoke ("Move_1");
		InvokeRepeating ("Move_2", 0, .01667f);

		yield return new WaitForSeconds (waitTime);
		CancelInvoke ("Move_2");
		InvokeRepeating ("Move_3", 0, .01667f);

		yield return new WaitForSeconds (waitTime);
		CancelInvoke ("Move_3");
		InvokeRepeating ("Move_4", 0, .01667f);

		yield return new WaitForSeconds (waitTime);
		CancelInvoke ("Move_4");
		InvokeRepeating ("Move_5", 0, .01667f);
		InvokeRepeating ("Move_6", 0, .01667f);

		yield return new WaitForSeconds (waitTime);
		CancelInvoke ("Move_5");
		CancelInvoke ("Move_6");
		go = false;
		StopCoroutine ("moveIt");
	}

	void Move_1 () {
		transform.position = Vector3.MoveTowards (transform.position, way1.position, speed * Time.deltaTime);
	}

	void Move_2 () {
		transform.position = Vector3.MoveTowards (transform.position, way2.position, speed * Time.deltaTime);
	}

	void Move_3 () {
		transform.position = Vector3.MoveTowards (transform.position, way3.position, speed * Time.deltaTime);
	}

	void Move_4 () {
		cube_1.parent = parent;
		cube_2.parent = parent;
		cube_3.parent = parent;

		if (parent.eulerAngles.z < 89.5f) {
			parent.Rotate (Vector3.forward * 90 * Time.deltaTime);
		} else {
			parent.rotation = Quaternion.Euler(0, 0, 90);
		}
	}

	void Move_5 () {
		transform.position = Vector3.MoveTowards (transform.position, way0.position, speed * Time.deltaTime);
	}

	void Move_6 () {
		cube_1.parent = null;
		cube_2.parent = null;
		cube_3.parent = null;

		parent.rotation = Quaternion.Euler(0, 0, 0);

	}

	void Update () {
		if(go == false){
			StartCoroutine ("moveIt");
		}
	}
}
