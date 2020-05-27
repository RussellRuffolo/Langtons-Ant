using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData {

    private static string instructions;

    private static Material[] colors;

    private static int size = 1;

    public static string Instructions
    {
        get
        {
            return instructions;
        }
        set
        {
            instructions = value;
        }
    }

    public static Material[] Colors
    {
        get
        {
            return colors;
        }
        set
        {
            colors = value;
        }
    }

    public static int boardSize
    {
        get
        {
            return size;
        }
        set
        {
            size = value;
        }
    }
}
