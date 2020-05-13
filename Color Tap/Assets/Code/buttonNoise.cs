using UnityEngine;
using System.Collections;

public class buttonNoise : MonoBehaviour {

	public GameObject sound;

	public void OnClick(){
		Instantiate (sound, transform.position, transform.rotation);
	}
}
