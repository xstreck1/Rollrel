using UnityEngine;
using System.Collections;

public class StabilizeLight : MonoBehaviour {
	// Position is kept constant by the value that is assigned in the editor
	private Vector3 position;
	
	// Use this for initialization
	void Start () {
		position = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		// Put the camera where it was + prohibit rotation
		transform.rotation = Quaternion.identity;
		transform.localPosition = position;
	}
}
