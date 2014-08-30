﻿using UnityEngine;
using System.Collections;

public class StabilizeCamera : MonoBehaviour {
	Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
		transform.position = transform.parent.position + position;
	}
}
