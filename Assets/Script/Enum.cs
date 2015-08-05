using UnityEngine;
using System.Collections;

public enum COLOR
{
    START = 0,
    RED = 0,
    YELLOW,
    BLUE,
    END,
}

public enum SHAPE
{
    START = 0,
    CIRCLE = 0,
    TRIANGLE,
    RECT,
    END,
}

public enum BGCOLOR
{
    START = 0,
    WHITE = 0,
    GRAY,
    BLACK,
    END,
}

public class Answer
{
    public int firstIdx;
    public int secondIdx;
    public int thirdIdx;
    public bool isUsed;
}

public enum SOUND
{
    START = 0,
    AHA = 0,
    COMBO,
    WRONG,
    CUBECLICK,
}

public enum BGM
{
    START = 0,
    TENBI = 0,

}
