using UnityEngine;
using System.Collections;

// Drawing the collision line
public class CreateLine : MonoBehaviour
{
    // Handle to the line on the display
    private Transform SourceCounter;
    // Total amount of source is 1, should be kept on this
    private float source_amount = 1f;
    // How much turbo is used per second
    public float SOURCE_CONSUME_PER_SECOND = 0.5f;
    // How much turbo is used per second
    public float SOURCE_REPLENISH_PER_SECOND = 0.1f;

    // The mouse position in the last frame
    private Vector3 last_point = Vector3.zero;
    // Handle of the line resource
    private Object line;
    // Handle to the parent in hiearchy for lines
    private Transform Lines;
    // Main scene camera reference
    private Camera camera;
    // What is the thicness of the line being drawn (ratio w.r.t. the original sprite)
    public float line_height = 1f;
    // What is the radius of the collision sphere around the avatar
    public float sphere_radius = 3.5f;

    // Use this for initialization
    void Start()
    {
        line = Resources.Load("line");
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        Lines = GameObject.Find("Lines").transform;
        SourceCounter = GameObject.Find("source_in").transform;
    }

    // Test if new point being drawn is colliding with the Avatar
    bool doesOverlap(Vector3 new_point)
    {
        float distance = Vector3.Distance(transform.position, new_point);
        return (sphere_radius > distance);
    }

    void Update()
    {
        // SourceCounter.localScale = new Vector3(source_amount, 1f, 1f);
    }

    // get a new point from the current mouse clikc position 
    Vector3 getNewPoint()
    {
        if (!Input.GetMouseButton(0))
            return Vector3.zero;

        // Obtain the new point
        Vector3 new_point = camera.ScreenToWorldPoint(Input.mousePosition);
        new_point.z = 0f;

        if (doesOverlap(new_point))
            return Vector3.zero;

        return new_point;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 new_point = getNewPoint();

        // Draw a line if there are two points
        if (source_amount > 0f && last_point != Vector3.zero && new_point != Vector3.zero)
        {
            float distance = Vector3.Distance(new_point, last_point);

            // Put the new line in the middle between the two points
            Vector3 instantiation = last_point + ((new_point - last_point) / 2f);
            GameObject new_line = (GameObject)Instantiate(line, instantiation, Quaternion.FromToRotation(Vector3.right, last_point - new_point));
            new_line.transform.parent = Lines;

            // Scale to fit exactly between the two points
            Vector3 new_scale = new_line.transform.localScale * distance;
            new_scale.y = line_height;
            new_line.transform.localScale = new_scale;

            source_amount -= SOURCE_CONSUME_PER_SECOND * Time.deltaTime;
        } else {
            source_amount += SOURCE_REPLENISH_PER_SECOND * Time.deltaTime;
        }

        source_amount = Mathf.Clamp01(source_amount);
        SourceCounter.localScale = new Vector3(source_amount, 1, 1);
        last_point = new_point;
    }

    void restart()
    {
        last_point = Vector3.zero;
    }

    // The level was succesfully finished
    void finish()
    {
        last_point = Vector3.zero;
    }
}
