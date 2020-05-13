using UnityEngine;
using System.Collections;

public class barPlace : MonoBehaviour {

	Vector3 pos = new Vector3 (0, 0, 20);

	public GameObject bar_1;
	public GameObject bar_2;

	SpriteRenderer sprite;

	void Start () {
		sprite = bar_1.GetComponent<SpriteRenderer> ();
		UpdateSize ();
	}

	// Update is called once per frame
	void Update () {

	}

	void UpdateSize () { // makes x value 1/4 of the screen width
		bar_1.transform.localScale = new Vector3(1,1,1);
		float width = sprite.bounds.size.x;

		float screenHeight = Camera.main.orthographicSize * 2;
		float screenWidth = screenHeight / Screen.height * Screen.width;

		Vector3 scale = bar_1.transform.localScale;
		scale.x = ((screenWidth / width) / 4) + .01f;;

		bar_1.transform.localScale = new Vector2 (scale.x, 10);
		bar_2.transform.localScale = new Vector2 (scale.x, 10);

		UpdatePosition ();
	}

	void UpdatePosition () {

		SpriteRenderer sprite = bar_1.GetComponent<SpriteRenderer> ();
		float width = sprite.bounds.extents.x;
		float height = sprite.bounds.extents.y;

		Vector3 centerPos = Camera.main.ScreenToWorldPoint (pos);
		Vector3 newPos = new Vector3 (centerPos.x + width, centerPos.y + height, 0);

		// Should be called after updating the size, sets pos to bottom left

		bar_1.transform.position = new Vector3(newPos.x, newPos.y, 95);
		bar_2.transform.position = new Vector3(width, newPos.y, 95);

	
	}
}
