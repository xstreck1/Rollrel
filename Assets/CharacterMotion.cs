using UnityEngine;
using System.Collections;

public class CharacterMotion : MonoBehaviour {
	private readonly Vector2 INITIAL_VELOCITY = new Vector2(10f, 0);
	private readonly Vector2 STANDARD_PUSH = new Vector2(10f, 0);

	// Use this for initialization
	void Start () {
		this.rigidbody2D.velocity = INITIAL_VELOCITY;
	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody2D.AddForce(STANDARD_PUSH * Time.deltaTime);
	}
}
