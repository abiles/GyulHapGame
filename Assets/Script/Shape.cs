using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour {

    SHAPE shape;
    COLOR color;
    
	void Start () {
        ChangeShapeAndColor();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void ChangeShapeAndColor()
    {
        shape = (SHAPE)Random.Range((int)SHAPE.START, (int)SHAPE.END);
        color = (COLOR)Random.Range((int)COLOR.START, (int)COLOR.END);

        Renderer renderer = gameObject.GetComponent<Renderer>();

        if (shape == SHAPE.CIRCLE)
        {
            switch (color)
            {
                case COLOR.RED:
                    renderer.material.mainTexture = Resources.Load("RedCircle") as Texture;
                    break;

                case COLOR.BLUE:
                    renderer.material.mainTexture = Resources.Load("BlueCircle") as Texture;
                    break;
                case COLOR.YELLOW:
                    renderer.material.mainTexture = Resources.Load("YellowCircle") as Texture;
                    break;
                default:
                    break;
            }
        }
        else if (shape == SHAPE.TRIANGLE)
        {
            switch (color)
            {
                case COLOR.RED:
                    renderer.material.mainTexture = Resources.Load("RedTri") as Texture;
                    break;

                case COLOR.BLUE:
                    renderer.material.mainTexture = Resources.Load("BlueTri") as Texture;
                    break;
                case COLOR.YELLOW:
                    renderer.material.mainTexture = Resources.Load("YellowTri") as Texture;
                    break;
                default:
                    break;
            }
        }
        else if (shape == SHAPE.RECT)
        {
            switch (color)
            {
                case COLOR.RED:
                    renderer.material.mainTexture = Resources.Load("RedRect") as Texture;
                    break;

                case COLOR.BLUE:
                    renderer.material.mainTexture = Resources.Load("BlueRect") as Texture;
                    break;
                case COLOR.YELLOW:
                    renderer.material.mainTexture = Resources.Load("YellowRect") as Texture;
                    break;
                default:
                    break;
            }
        }
        else
        {

        }
    }

    public SHAPE GetShape()
    {
        return shape;
    }

    public COLOR GetColor()
    {
        return color;
    }
}
