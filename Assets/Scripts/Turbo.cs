using UnityEngine;
using System.Collections;

public class Turbo : MonoBehaviour {
	// Handle to the line on the display
	private Transform TurboCounter;
	// Total amount of turbo is 1, should be kept on this
	private float turbo_amount = 1f;
	// How much turbo is used per second
	public float TURBO_PER_SECOND = 0.1f;
	// How much push is given per frame
	public Vector2 push = new Vector2(10f, 0f);
	// Maximal velocity of the sprite, if above, turbo is disabled
	public float max_velocity = 75f;

	// Use this for initialization
	void Start () {
		TurboCounter = GameObject.Find("turbo_in").transform;
	}


	// Update is called once per frame
	void FixedUpdate () {
		float velocity = Vector2.Distance(Vector2.zero, this.rigidbody2D.velocity);
		if (velocity < max_velocity && turbo_amount > 0f && Input.GetMouseButton(1)) {
			this.rigidbody2D.AddForce(push);
			turbo_amount -= TURBO_PER_SECOND * Time.deltaTime;
			this.audio.Play();
		} else {
			this.audio.Stop();
		}
		// Rescale the counter
		TurboCounter.localScale = new Vector3(turbo_amount, 1f, 1f);
	}
	
	void restart() {
		turbo_amount = 1f;
	}
	
	// The level was succesfully finished
	void finish() {
		turbo_amount = 1f;
	}
}
