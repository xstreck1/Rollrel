//C# Example
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameControl : EditorWindow
{
    GameObject character;
    GameObject camera;
    List<Vector2> positions = new List<Vector2>();
    int current_position = 0;

    void addPositions()
    {
        positions.Clear();
        positions.Add(new Vector2(0, 0));
        positions.Add(new Vector2(150, -20));
        positions.Add(new Vector2(260, -30));
        positions.Add(new Vector2(330, -50));
        positions.Add(new Vector2(400, -43));
        positions.Add(new Vector2(750, -190));
    }

    void OnEnable()
    {
        character = GameObject.Find("Character");
        camera = GameObject.Find("Camera");
        addPositions();
    }

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Game Control")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(GameControl));
    }

    void moveAvatar()
    {
        character.transform.position = (Vector3)positions[current_position];
        camera.transform.position = (Vector3)positions[current_position] + camera.GetComponent<StabilizeCamera>().offset;
    }

    void OnGUI()
    {
        EditorGUILayout.TextField("Positions available: " + positions.Count);
        EditorGUILayout.TextField("Current position: " + (current_position + 1));

        if (GUILayout.Button("Next position"))
        {
            current_position = (current_position + 1) % positions.Count;
            moveAvatar();
        }

        if (GUILayout.Button("Previous position"))
        {
            current_position = (current_position + positions.Count - 1) % positions.Count;
            moveAvatar();
        }
    }
}
