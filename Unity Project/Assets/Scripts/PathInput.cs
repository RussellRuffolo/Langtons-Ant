using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PathInput : MonoBehaviour {


    public Text instrucText;
    public string antInstructions;

	void Start () {
		
	}
	
	void Update () {
        GetInput();
	}

    void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            antInstructions = antInstructions + "L";
            instrucText.text += "L";
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            antInstructions = antInstructions + "R";
            instrucText.text += "R";
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            GameData.Instructions = antInstructions;
            SceneManager.LoadScene("colorSelection");
        }
    }
   
}
