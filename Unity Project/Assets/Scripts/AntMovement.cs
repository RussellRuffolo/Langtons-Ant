using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TileData
{
    public TileData(int cValue, MeshRenderer tRenderer)
    {
        colorValue = cValue;
        tileRenderer = tRenderer;
    }

    public int colorValue;
    public MeshRenderer tileRenderer;
}

public class AntMovement : MonoBehaviour {


    public Vector2 antDirection;
    private int x = 0, y = 0;


    private float maxDistance;

    public bool finished;

    public float antDelay;
    public float stepsPerFrame;

    public GameObject tileTemplate;

    public Text inputText;

    private string instructions;
    private int instLength;

    public int maxSpeed = 1000;

    private float sliderValue = 0;

    public Material[] Colors;

    Dictionary<Vector2, TileData> tileDict = new Dictionary<Vector2, TileData>();

    private bool started = false;

	// Use this for initialization
	void Start () {
        maxDistance = 0;
       // GameObject newTile = GameObject.Instantiate(tileTemplate);
       // newTile.transform.position = Vector3.zero;
        //tileDict.Add(Vector2.zero, new TileData(0, newTile.GetComponent<MeshRenderer>()));

        finished = false;

      

        transform.position = new Vector3(x, .5f, y);


        antDirection = Vector2.up;


    }

    public void StartWalk()
    {
        string inputInstruct = inputText.text;
        string parsedInstructions = string.Empty;

        for(int i = 0; i < inputInstruct.Length; i++)
        {
            switch(inputInstruct[i])
            {
                case 'L':
                    parsedInstructions += "L";
                    break;
                case 'l':
                    parsedInstructions += "L";
                    break;
                case 'R':
                    parsedInstructions += "R";
                    break;
                case 'r':
                    parsedInstructions += "R";
                    break;
                default:
                    break;
                
            }
        }

        instructions = parsedInstructions;
        Debug.Log(instructions);
        Debug.Log(instructions[0]);
        inputText.text = parsedInstructions;
        instLength = parsedInstructions.Length;

        started = true;

    }


    
	
	// Update is called once per frame
	void Update () {
		if(started && !finished)
        {
            MoveAnt();
        }        
	}

    void MoveAnt()
    {
        for (int i = 0; i < 1 + maxSpeed * sliderValue; i++)
        {
            //check tile returns true if the the current tile is in the "too-right" state
            //if the current tile is not yet in the dictionary, checkTile adds it
            if (CheckTile())
            {
                RotateRight();
            }
            else
            {
                RotateLeft();
            }

            flipTile();

            x += (int)antDirection.x;
            y += (int)antDirection.y;

            transform.position = new Vector3(x, .5f, y);

            float distance = Vector3.Distance(transform.position, new Vector3(0, .5f, 0));

            if (distance > maxDistance)
            {
                maxDistance = distance;
                GameData.boardSize = (int)maxDistance;
            }

            
        }
    
    }

    void flipTile()
    {
        tileDict[new Vector2(x, y)].colorValue = (tileDict[new Vector2(x, y)].colorValue + 1) % instLength;
        tileDict[new Vector2(x, y)].tileRenderer.material = Colors[tileDict[new Vector2(x, y)].colorValue % Colors.Length];
    }

    void RotateRight()
    {
        float tempX, tempY;
        tempX = antDirection.x;
        tempY = antDirection.y;
        antDirection.x = -tempY;
        antDirection.y = tempX;
    }

    void RotateLeft()
    {
        float tempX, tempY;
        tempX = antDirection.x;
        tempY = antDirection.y;
        antDirection.x = tempY;
        antDirection.y = -tempX;
    }


    bool CheckTile()
    {
        Vector2 tileKey = new Vector2(x, y);

        if(!tileDict.ContainsKey(tileKey))
        {            
            GameObject newTile = new GameObject("Tile: " + tileKey.x + "," + tileKey.y);
            newTile.transform.position = new Vector3(x, 0, y);
            newTile.AddComponent<MeshRenderer>();
            newTile.AddComponent<TileCreator>();
            tileDict.Add(tileKey, new TileData(0, newTile.GetComponent<MeshRenderer>()));
        }
        
        int index = tileDict[tileKey].colorValue;
 
        if (instructions[index] == 'R')
        {
            return true;
        }

        return false;
    }

    public void UpdateSpeed(float value)
    {
        sliderValue = value;
    }

    private void OnApplicationQuit()
    {
        tileDict.Clear();
    }
}
