using UnityEngine;
using System.Collections;

public class CharacterMotion : MonoBehaviour {
	private readonly Vector2 INITIAL_VELOCITY = new Vector2(5f, 0);
	private readonly Vector2 STANDARD_PUSH = new Vector2(150f, 0);

	// Use this for initialization
	void Start () {
		restart();
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce(STANDARD_PUSH * Time.deltaTime);
		if (Input.GetKey(KeyCode.R)) 
		    restart();
	}

	void restart() {
		transform.position = Vector3.zero;
		rigidbody2D.velocity = INITIAL_VELOCITY;
	}

	void finish() {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "death")
			restart();
		if (other.tag == "death")
			finish();
	}
}
