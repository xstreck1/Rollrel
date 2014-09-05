using UnityEngine;
using System.Collections;

public class StabilizePlane : MonoBehaviour {
    Quaternion rotation;

	// Use this for initialization
	void Start () {
        rotation = Quaternion.Euler(270, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = rotation;
    }
}
