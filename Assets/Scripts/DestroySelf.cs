using UnityEngine;
using System.Collections;

// Dissapereance of the line
public class DestroySelf : MonoBehaviour {
	// How long is the line gonna last
	public float livetime = 3f;
	// When does the line start to disappear
	private readonly float DISSAPEAR_TIME = 1f;
	// Handle to own renderer
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		livetime -= Time.deltaTime;

		if (livetime < 1f) {
			renderer.color = new Color(1f,1f,1f, livetime / DISSAPEAR_TIME);
		} 
		if (livetime < 0f) {
			Destroy(this.gameObject);
		}
	}

	// Destroy if out of the camera
	void OnBecameInvisible() {
		Destroy(this.gameObject);
	}
}
