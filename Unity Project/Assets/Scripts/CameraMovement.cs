using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    int boardSize;
    public GameObject ant;

    private float cameraScale = 1;
    Vector3 targetPosition;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
         targetPosition = new Vector3(ant.transform.position.x * (1 - cameraScale), 5, ant.transform.position.y * (1 - cameraScale));
        //GetComponent<Camera>().orthographicSize =  4 + cameraScale * GameData.boardSize;
	}

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, .2f);
    }

    public void SizeScaler(float scale)
    {
        cameraScale = scale;
    }
}
