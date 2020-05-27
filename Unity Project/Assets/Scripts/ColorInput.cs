using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorInput : MonoBehaviour {

    int numColors;
    int index;
    public Material[] colors;

    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        index = 0;
        numColors = GameData.Instructions.Length;
        colors = new Material[numColors];

        startPosition = new Vector3(-(numColors * .125f), 0, -1.875f);
	}
	
	// Update is called once per frame
	void Update () {
	

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                colors[index] = Resources.Load<GameObject>(hit.transform.gameObject.name).GetComponent<MeshRenderer>().sharedMaterial;

                GameObject newBlock = GameObject.Instantiate(Resources.Load<GameObject>(hit.transform.gameObject.name));
                newBlock.transform.localScale = new Vector3(.25f, .25f, .25f);
                newBlock.transform.position = startPosition + Vector3.right * index * .25f;

                index++;
                if (index == numColors)
                {
                    GameData.Colors = colors;
                    SceneManager.LoadScene("2DBuild");
                }
            }
        }
    }
}
