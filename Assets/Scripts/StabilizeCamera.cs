using UnityEngine;
using System.Collections;

public class StabilizeCamera : MonoBehaviour {
    // Position is kept constant by the value that is assigned in the editor
    private Vector3 position;
    //
    private Transform character;

	// Use this for initialization
	void Start () {
        position = this.transform.position;
        character = GameObject.Find("Character").transform;
	}
	
	// Update is called once per frame
	void Update () {
		// Put the camera where it was + prohibit rotation
		transform.position = character.position + position;
	}
}
