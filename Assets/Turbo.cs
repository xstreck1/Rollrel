using UnityEngine;
using System.Collections;

public class Turbo : MonoBehaviour {
	private Transform TurboCounter;
	private float turbo_amount = 1f;
	private readonly float TURBO_PER_SECOND = 0.5f;
	private readonly Vector2 push = new Vector2(3000f, 0f);
	private readonly float max_velocity = 100f;

	// Use this for initialization
	void Start () {
		TurboCounter = GameObject.Find("turbo_in").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float velocity = Vector2.Distance(Vector2.zero, this.rigidbody2D.velocity);
		if (velocity < max_velocity && turbo_amount > 0f && Input.GetMouseButton(1)) {
			this.rigidbody2D.AddForce(push * Time.deltaTime);
			turbo_amount -= TURBO_PER_SECOND * Time.deltaTime;
		}
		TurboCounter.localScale = new Vector3(turbo_amount, 1f, 1f);
	}
}
