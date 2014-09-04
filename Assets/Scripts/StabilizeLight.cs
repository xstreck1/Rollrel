using UnityEngine;
using System.Collections;

public class StabilizeLight : MonoBehaviour {
	// Position is kept constant by the value that is assigned in the editor
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
        offset = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		// Put the camera where it was + prohibit rotation
		transform.rotation = Quaternion.identity;
		transform.position = transform.parent.position + offset;
	}
}
