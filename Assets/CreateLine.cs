using UnityEngine;
using System.Collections;

public class CreateLine : MonoBehaviour
{
	private Vector3 last_point = Vector3.zero;
	private Object line;
	private Camera camera;
	private float line_height = 1f;

	// Use this for initialization
	void Start () {
		line = Resources.Load ("line");
		camera = GameObject.Find ("Camera").GetComponent<Camera> ();
	}
	
		// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton (0)) {
			Vector3 new_point = camera.ScreenToWorldPoint (Input.mousePosition);
			if (last_point != Vector3.zero) {
				new_point.z = 0f;

				float distance = Vector3.Distance (new_point, last_point);
				Vector3 instantiation = last_point + ((new_point - last_point) / 2f);
				GameObject new_line = (GameObject)Instantiate (line, instantiation, Quaternion.FromToRotation(Vector3.right, last_point - new_point));
				Vector3 new_scale = new_line.transform.localScale * distance;
				new_scale.y = line_height;
				new_line.transform.localScale = new_scale;
				Debug.Log ("x: " + new_point.x + ", y: " + new_point.y);		
			}
			last_point = new_point;
			last_point.z = 0f;
		}
		else
			last_point = Vector3.zero;
	}
}
