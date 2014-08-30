using UnityEngine;
using System.Collections;

public class CreateLine : MonoBehaviour
{
		private Vector3 last_point = Vector3.zero;
		private Object line;
		private Camera camera;

		// Use this for initialization
		void Start ()
		{
				line = Resources.Load ("line");
				camera = GameObject.Find ("Camera").GetComponent<Camera> ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (Input.GetMouseButtonDown (0)) {
						last_point = camera.ScreenToWorldPoint (Input.mousePosition);
				} else if (Input.GetMouseButtonUp (0)) {
						last_point = Vector3.zero;
				} else if (Input.GetMouseButton (0) && last_point != Vector3.zero) {
						Vector3 new_point = camera.ScreenToWorldPoint (Input.mousePosition);
						new_point.z = 0f;


						float distance = Vector3.Distance (new_point, last_point);
						GameObject new_line = (GameObject)Instantiate (line, last_point, Quaternion.identity);
						Vector3 new_scale = new_line.transform.localScale * distance;
						new_scale.y = 1f;
						new_line.transform.localScale = new_scale;

						// new_line.transform.LookAt(new_point, Vector3.left);
						Debug.Log ("x: " + new_point.x + ", y: " + new_point.y);
						last_point = new_point;
				}
		}

		void OnMouseDown ()
		{

		}

		void OnMouseUp ()
		{

		}
}
