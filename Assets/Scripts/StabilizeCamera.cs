using UnityEngine;
using System.Collections;

public class StabilizeCamera : MonoBehaviour {
    // Position is kept constant by the value that is assigned in the editor
    public Vector3 offset = new Vector3(25, 0, -10);
    //
    private Transform character;

	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character").transform;
	}
	
	// Update is called once per frame
	void Update () {
		// Put the camera where it was + prohibit rotation
		transform.position = character.position + offset;
	}
}
