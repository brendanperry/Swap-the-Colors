using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newSpawner : MonoBehaviour {

	public GameObject[] balls;

	List<GameObject> redBalls; 
	List<GameObject> blueBalls; 
	List<GameObject> greenBalls; 
	List<GameObject> yellowBalls; 

	public int startAmount = 10;
	public float fireTime = 5f;
	public float initialFireTime = 3;
	int lastNum = -1;
	int lastNumber = -1;
	int rnd;
	public Transform way1;
	public Transform way2;
	public Transform way3;
	public Transform way4;

	void Start () {

		redBalls = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj = (GameObject)Instantiate (balls[0]);
			obj.SetActive (false);
			redBalls.Add (obj);
		}

		blueBalls = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj2 = (GameObject)Instantiate (balls[3]);
			obj2.SetActive (false);
			blueBalls.Add (obj2);
		}

		greenBalls = new List<GameObject> ();
		for (int i = 0; i < startAmount; i++) {
			GameObject obj3 = (GameObject)Instantiate (balls [1]);
			obj3.SetActive (false);
			greenBalls.Add (obj3);
		}

		yellowBalls = new List<GameObject> ();
		for(int i = 0; i < startAmount; i++){
			GameObject obj4 = (GameObject)Instantiate (balls[2]);
			obj4.SetActive (false);
			yellowBalls.Add (obj4);
		}
		InvokeRepeating ("spawn", initialFireTime, fireTime);
	}

	void Update () {
	
	}

	void spawn () {

		int random = Random.Range (0, 4);
		if(random == lastNum){
			if(random > 2){
				random -= 1;
			} else {
				random += 1;
			}
		}
		lastNum = random;
	

		switch (random) {
		case 0:
			for (int i = 0; i < redBalls.Count; i++) {
				if (!redBalls [i].activeInHierarchy) {
					redBalls [i].transform.position = transform.position;
					redBalls [i].SetActive (true); 

					rnd = Random.Range (0, 4);


					int firstLane = rnd;

					if(rnd == lastNumber || rnd == PlayerPrefs.GetInt("redCube", 1)){
						if(rnd >= 2){
							rnd -= 1;
						} else {
							rnd += 1;
						}
					}

					int secondLane = rnd;

					if (rnd == lastNumber || rnd == PlayerPrefs.GetInt ("redCube", 1)) {
						if(firstLane != 0 && secondLane != 0){
							rnd = 0;
						} else if (firstLane != 1 && secondLane != 1){
							rnd = 1;
						} else if (firstLane != 2 && secondLane != 2){
							rnd = 2;
						} else if (firstLane != 3 && secondLane != 3){
							rnd = 3;
						}
					}

					lastNumber = rnd;

					switch (rnd) {
					case 0:
						redBalls [i].transform.position = way1.position;
						transform.position = way1.position;
						break;
					case 1:
						redBalls [i].transform.position = way2.position;
						transform.position = way2.position;
						break;
					case 2:
						redBalls [i].transform.position = way3.position;
						transform.position = way3.position;
						break;
					case 3: 
						redBalls [i].transform.position = way4.position;
						transform.position = way4.position;
						break;
					}

					break;
				}
			}
			break;
		case 1:
			for (int i = 0; i < blueBalls.Count; i++) {
				if (!blueBalls [i].activeInHierarchy) {
					blueBalls [i].transform.position = transform.position;
					blueBalls [i].SetActive (true); 

					rnd = Random.Range (0, 4);

					int firstLane_1 = rnd;

					if(rnd == lastNumber || rnd == PlayerPrefs.GetInt("blueCube", 3)){
						if(rnd >= 2){
							rnd -= 1;
						} else {
							rnd += 1;
						}
					}

					int secondLane_1 = rnd;

					if (rnd == lastNumber || rnd == PlayerPrefs.GetInt ("blueCube", 3)) {
						if(firstLane_1 != 0 && secondLane_1 != 0){
							rnd = 0;
						} else if (firstLane_1 != 1 && secondLane_1 != 1){
							rnd = 1;
						} else if (firstLane_1 != 2 && secondLane_1 != 2){
							rnd = 2;
						} else if (firstLane_1 != 3 && secondLane_1 != 3){
							rnd = 3;
						}
					}

					lastNumber = rnd;

					switch (rnd) {
					case 0:
						blueBalls [i].transform.position = way1.position;
						transform.position = way1.position;
						break;
					case 1:
						blueBalls [i].transform.position = way2.position;
						transform.position = way2.position;
						break;
					case 2:
						blueBalls [i].transform.position = way3.position;
						transform.position = way3.position;
						break;
					case 3: 
						blueBalls [i].transform.position = way4.position;
						transform.position = way4.position;
						break;
					}

					break;
				}
			}
			break;
		case 2:
			for (int i = 0; i < greenBalls.Count; i++) {
				if (!greenBalls [i].activeInHierarchy) {
					greenBalls [i].transform.position = transform.position;
					greenBalls [i].SetActive (true);

					rnd = Random.Range (0, 4);

					int firstLane_2 = rnd;

					if(rnd == lastNumber  || rnd == PlayerPrefs.GetInt("greenCube", 0)){
						if(rnd >= 2){
							rnd -= 1;
						} else {
							rnd += 1;
						}
					}

					int secondLane_2 = rnd;

					if (rnd == lastNumber || rnd == PlayerPrefs.GetInt ("greenCube", 0)) {
						if(firstLane_2 != 0 && secondLane_2 != 0){
							rnd = 0;
						} else if (firstLane_2 != 1 && secondLane_2 != 1){
							rnd = 1;
						} else if (firstLane_2 != 2 && secondLane_2 != 2){
							rnd = 2;
						} else if (firstLane_2 != 3 && secondLane_2 != 3){
							rnd = 3;
						}
					}

					lastNumber = rnd;

					switch (rnd) {
					case 0:
						greenBalls [i].transform.position = way1.position;
						transform.position = way1.position;
						break;
					case 1:
						greenBalls [i].transform.position = way2.position;
						transform.position = way2.position;
						break;
					case 2:
						greenBalls [i].transform.position = way3.position;
						transform.position = way3.position;
						break;
					case 3: 
						greenBalls [i].transform.position = way4.position;
						transform.position = way4.position;
						break;
					}

					break;
				}
			}
			break;
		case 3: 
			for (int i = 0; i < yellowBalls.Count; i++) {
				if (!yellowBalls [i].activeInHierarchy) {
					yellowBalls [i].transform.position = transform.position;
					yellowBalls [i].SetActive (true); 

					rnd = Random.Range (0, 4);

					int firstLane_3 = rnd;

					if(rnd == lastNumber || rnd == PlayerPrefs.GetInt("yellowCube", 2)){
						if(rnd >= 2){
							rnd -= 1;
						} else {
							rnd += 1;
						}
					}

					int secondLane_3 = rnd;

					if (rnd == lastNumber || rnd == PlayerPrefs.GetInt ("yellowCube", 2)) {
						if(firstLane_3 != 0 && secondLane_3 != 0){
							rnd = 0;
						} else if (firstLane_3 != 1 && secondLane_3 != 1){
							rnd = 1;
						} else if (firstLane_3 != 2 && secondLane_3 != 2){
							rnd = 2;
						} else if (firstLane_3 != 3 && secondLane_3 != 3){
							rnd = 3;
						}
					}

					lastNumber = rnd;

					switch (rnd) {
					case 0:
						yellowBalls [i].transform.position = way1.position;
						transform.position = way1.position;
						break;
					case 1:
						yellowBalls [i].transform.position = way2.position;
						transform.position = way2.position;
						break;
					case 2:
						yellowBalls [i].transform.position = way3.position;
						transform.position = way3.position;
						break;
					case 3: 
						yellowBalls [i].transform.position = way4.position;
						transform.position = way4.position;
						break;
					}

					break;
				}
			}
			break; 
		}
	}
}
