using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject white;
    public GameObject black;
    bool inDelay;

	// Use this for initialization
	void Start () {
        inDelay = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!inDelay)
        {
            DetectTile();
        }
	}
    void DetectTile()
    {
        RaycastHit tileHit;
        if(Physics.Raycast(transform.position, Vector3.down, out tileHit, 0.5f))
        {
            
            if(tileHit.collider.gameObject.name == "White")
            {
                Destroy(tileHit.collider.gameObject);
                GameObject temp;
                temp = Instantiate(white);
                temp.transform.position = transform.position - Vector3.down * .1f;
                transform.RotateAround(transform.up, 90);
                transform.Translate(Vector3.forward);
            }
            else if(tileHit.collider.gameObject.name == "Black")
            {
                Destroy(tileHit.collider.gameObject);
                GameObject temp;
                temp = Instantiate(black);
                temp.transform.position = transform.position + Vector3.down;
                transform.RotateAround(transform.up, -90);
                transform.Translate(Vector3.forward * 10);
            }
        }
        else
        {
            GameObject temp;
            temp = Instantiate(black);
            temp.transform.position = transform.position + Vector3.down;
            transform.RotateAround(transform.up, -90);
            transform.Translate(Vector3.forward * 10);
        }

        inDelay = true;
        StartCoroutine(TileDelay());
        
    }

    IEnumerator TileDelay()
    {
        yield return new WaitForSeconds(.5f);
        inDelay = false;
    }
}
