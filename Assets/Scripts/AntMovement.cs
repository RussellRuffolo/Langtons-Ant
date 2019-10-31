using System.Collections;
using System.Collections.Generic;
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

    private GameObject board;
    public Vector2 antDirection;
    private int x = 0, y = 0;
    public int boardSize;

    private float maxDistance;

    public bool finished;

    public float antDelay;
    public float stepsPerFrame;

    public GameObject tileTemplate;

    private string instructions;
    private int instLength;

    public int maxSpeed = 1000;

    private float sliderValue = 0;

    Dictionary<Vector2, TileData> tileDict = new Dictionary<Vector2, TileData>();
	// Use this for initialization
	void Start () {
        maxDistance = 0;
        GameObject newTile = GameObject.Instantiate(tileTemplate);
        newTile.transform.position = Vector3.zero;

        finished = false;
        instructions = GameData.Instructions;
        instLength = instructions.Length;

        StartCoroutine(startDelay());

  
	}

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(1);

        board = GameObject.Find("Board");

    
        transform.position = new Vector3(x, .5f, y);
        

        antDirection = Vector2.up;

    }
	
	// Update is called once per frame
	void Update () {
		
            MoveAnt();
        
	}

    void MoveAnt()
    {
        for (int i = 0; i < 1 + maxSpeed * Mathf.Pow(sliderValue, 3); i++)
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
        tileDict[new Vector2(x, y)].tileRenderer.material = GameData.Colors[tileDict[new Vector2(x, y)].colorValue];
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
            
            GameObject newTile = GameObject.Instantiate(tileTemplate);
            newTile.transform.position = new Vector3(x, 0, y);
            tileDict.Add(tileKey, new TileData(0, newTile.GetComponent<MeshRenderer>()));
        }
        if (instructions[tileDict[new Vector2(x, y)].colorValue] == 'R')
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
