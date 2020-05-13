using UnityEngine;
using System.Collections;

public class placement : MonoBehaviour {

	Vector3 pos = new Vector3 (0, 0, 20);

	public GameObject cube_1;
	public GameObject cube_2;
	public GameObject cube_3;
	public GameObject cube_4;

	public GameObject bar_1;
	public GameObject bar_2;

	public Transform way1;
	public Transform way2;
	public Transform way3;
	public Transform way4;

	SpriteRenderer sprite;
	SpriteRenderer sprite2;
	SpriteRenderer sprite3;
	SpriteRenderer sprite4;

	public Transform spawner;

	void Start () {
		sprite = cube_1.GetComponent<SpriteRenderer> ();
		sprite2 = cube_2.GetComponent<SpriteRenderer> ();
		sprite3 = cube_3.GetComponent<SpriteRenderer> ();
		sprite4 = cube_4.GetComponent<SpriteRenderer> ();
		UpdateSize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateSize () { // makes x value 1/4 of the screen width
		cube_1.transform.localScale = new Vector3(1,1,1);
		float width = sprite.bounds.size.x;

		float screenHeight = Camera.main.orthographicSize * 2;
		float screenWidth = screenHeight / Screen.height * Screen.width;

		Vector3 scale = cube_1.transform.localScale;
		scale.x = ((screenWidth / width) / 4) + .01f;;

		cube_1.transform.localScale = scale;
		cube_2.transform.localScale = scale;
		cube_3.transform.localScale = scale;
		cube_4.transform.localScale = scale;

//		float bar_1x = bar_1.transform.localScale.x;
//		float bar_2x = bar_2.transform.localScale.x;
//		bar_1x = scale.x;
//		bar_2x = scale.x;
		bar_1.transform.localScale = new Vector2 (scale.x, 10);
		bar_2.transform.localScale = new Vector2 (scale.x, 10);



		cube_1.AddComponent <BoxCollider2D>();
		cube_1.GetComponent<BoxCollider2D> ().isTrigger = true;

		cube_2.AddComponent <BoxCollider2D>();
		cube_2.GetComponent<BoxCollider2D> ().isTrigger = true;

		cube_3.AddComponent <BoxCollider2D>();
		cube_3.GetComponent<BoxCollider2D> ().isTrigger = true;

		cube_4.AddComponent <BoxCollider2D>();
		cube_4.GetComponent<BoxCollider2D> ().isTrigger = true;

		UpdatePosition ();
	}

	void UpdatePosition () {

		SpriteRenderer sprite = cube_1.GetComponent<SpriteRenderer> ();
		float width = sprite.bounds.extents.x;
		float height = sprite.bounds.extents.y;

		Vector3 centerPos = Camera.main.ScreenToWorldPoint (pos);
		Vector3 newPos = new Vector3 (centerPos.x + width, centerPos.y + height, 0);

		// Should be called after updating the size, sets pos to bottom left

		cube_1.transform.position = newPos;

		// Update all cube positions

		cube_2.transform.position = new Vector2 (newPos.x + sprite.bounds.size.x -.01f, newPos.y);
		cube_3.transform.position = new Vector2 (newPos.x + (sprite.bounds.size.x * 2) - .04f, newPos.y);
		cube_4.transform.position = new Vector2 (newPos.x + (sprite.bounds.size.x * 3) - .05f, newPos.y);

		bar_1.transform.position = new Vector3(cube_1.transform.position.x - .05f, 0, 5);
		bar_2.transform.position = new Vector3(cube_3.transform.position.x -.05f, 0, 5);

		// Update spawn waypoint positions

		way1.position = centerPos;
		way2.position = centerPos;
		way3.position = centerPos;
		way4.position = centerPos;

		way1.position = new Vector2 (way1.position.x + sprite.bounds.extents.x -.09f, 5);
		way2.position = new Vector2 (way2.position.x + sprite.bounds.size.x + sprite2.bounds.extents.x - .05f, 5);
		way3.position = new Vector2 (way3.position.x + sprite.bounds.size.x + sprite2.bounds.size.x + sprite3.bounds.extents.x -.09f, 5);
		way4.position = new Vector2 (way4.position.x + sprite.bounds.size.x + sprite2.bounds.size.x + sprite3.bounds.size.x + sprite4.bounds.extents.x -.1f, 5);

	}
}
