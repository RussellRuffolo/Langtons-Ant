using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    bool instructionsDone;
    public Camera selectionCamera;
    public Camera antCamera;
    private string input;
    public GameObject ant;

	// Use this for initialization
	void Start () {

        instructionsDone = false;
        selectionCamera.enabled = true;
        antCamera.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!instructionsDone)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                input = input + 'R';
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                input = input + 'L';
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                instructionsDone = true;
                GameData.Instructions = input;
                selectionCamera.enabled = false;
                antCamera.enabled = true;
            }
        }
	}
}
