 using UnityEngine;
using System.Collections;

public class collisionManager : MonoBehaviour {

	public string tagg;
	GameObject scorer;
	score Score;
	public ParticleSystem particles;
	private Vector2 particlePos;
	private float particlePosX;
	public AudioSource point;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("canScore", 0);
		scorer = GameObject.Find ("Text");
		Score = scorer.GetComponent<score> ();
		particlePos = new Vector2 (0, -3.75f);
		particlePosX = particlePos.x;

		if(particles == null){
			if (tagg == "blue") {
				particles = GameObject.Find ("Particle System - Blue").GetComponent<ParticleSystem> ();
			} else if (tagg == "red") {
				particles = GameObject.Find ("Particle System - Red").GetComponent<ParticleSystem> ();
			} else if (tagg == "green") {
				particles = GameObject.Find ("Particle System - Green").GetComponent<ParticleSystem> ();
			} else if (tagg == "yellow") {
				particles = GameObject.Find ("Particle System - Yellow").GetComponent<ParticleSystem> ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == tagg && PlayerPrefs.GetInt("canScore") == 0){
			point.Play ();
			Score.up ();
			col.gameObject.SetActive (false);
			particlePosX = col.transform.position.x;
			particles.transform.position = new Vector2 (particlePosX, - 3.75f);
			particles.Clear ();
			particles.Play ();
		} else {
			PlayerPrefs.SetInt ("canScore", 1);
			Score.End ();
			col.gameObject.SetActive (false);
		}
	}
}
