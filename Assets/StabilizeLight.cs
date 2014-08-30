using UnityEngine;
using System.Collections;

public class StabilizeLight : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.parent.position + new Vector3(-3, 3, -5);
	}
}
