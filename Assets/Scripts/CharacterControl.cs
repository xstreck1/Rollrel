using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R) || Input.touchCount > 1)
            SendMessage("restart");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "death")
            this.SendMessage("restart");
        if (other.tag == "finish")
            this.SendMessage("finish");
    }
}
