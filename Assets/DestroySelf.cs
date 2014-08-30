using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {
	private float time = 3f;
	private readonly float DISSAPEAR_TIME = 1f;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if (time < 1f) {
			renderer.color = new Color(1f,1f,1f,time);
		} 
		if (time < 0f) {
			Destroy(this.gameObject);
		}
	}

	void OnBecameInvisible() {
	}
}
