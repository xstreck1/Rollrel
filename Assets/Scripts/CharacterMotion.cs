using UnityEngine;
using System.Collections;

// Main character control
public class CharacterMotion : MonoBehaviour {
	// How much momentum is given after start
	public Vector2 INITIAL_VELOCITY = new Vector2(5f, 0); 
	// How much momentum is added every fixed frame
	public Vector2 STANDARD_PUSH = new Vector2(1f, 0);

	// Use this for initialization
	void Start () {
		restart();
	}

	void FixedUpdate () {
		rigidbody2D.AddForce(STANDARD_PUSH);
	}

	void restart() {
		transform.position = Vector3.zero;
		rigidbody2D.velocity = INITIAL_VELOCITY;
	}

	// The level was succesfully finished
	void finish() {
	}
}
