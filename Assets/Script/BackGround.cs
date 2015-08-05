using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

    BGCOLOR bgColor;

	// Use this for initialization
	void Start () {
        ChangeBackColor();
	}
    
    public void ChangeBackColor()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        bgColor = (BGCOLOR)Random.Range((int)BGCOLOR.START, (int)BGCOLOR.END);

        if(bgColor == BGCOLOR.WHITE)
        {
            renderer.material.mainTexture = Resources.Load("WhiteBG") as Texture;
        }
        else if(bgColor == BGCOLOR.GRAY)
        {
            renderer.material.mainTexture = Resources.Load("GrayBG") as Texture;
        }
        else if(bgColor == BGCOLOR.BLACK)
        {
            renderer.material.mainTexture = Resources.Load("BlackBG") as Texture;
        }
        else
        {

        }
    }

    public BGCOLOR GetBGColor()
    {
        return bgColor;
    }
}
