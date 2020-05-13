using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class spawner : MonoBehaviour {

	public GameObject redballs;
	public int startAmount = 10;
	public float fireTime = 5f;
	public float initialFireTime = 3;
	List<GameObject> objects; 
	public bool canSpawn = true;

	public Transform way1;
	public Transform way2;
	public Transform way3;
	public Transform way4;

	int random;


	public GameObject[] balls;


	void Start (){

		objects = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj = (GameObject)Instantiate (redballs);
			obj.SetActive (false);
			objects.Add (obj);
		}
		InvokeRepeating ("spawn", initialFireTime, fireTime);
		//InvokeRepeating
	}

	void spawn (){
		if(canSpawn == true){
		for (int i = 0; i < objects.Count; i++){
				if (!objects [i].activeInHierarchy) {
					objects [i].transform.position = transform.position;
					objects [i].SetActive (true); 

					random = Random.Range (0, 4);

					switch (random) {
					case 0:
						transform.position = way1.position;
						break;
					case 1:
						transform.position = way2.position;
						break;
					case 2:
						transform.position = way3.position;
						break;
					case 3: 
						transform.position = way4.position;
						break;
					}

					break;
				}
			}
		}
	}
}
