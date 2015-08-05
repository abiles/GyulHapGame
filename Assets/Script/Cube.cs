using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

    public int index = 0;
    BackGround bg;
    Shape shape;

    void Start()
    {
        bg = GetComponentInChildren<BackGround>();
        shape = GetComponentInChildren<Shape>();
    }

    public void changeLevel()
    {
        bg.ChangeBackColor();
        shape.ChangeShapeAndColor();
    }


    public void Click()
    {
        gameObject.GetComponentInChildren<Click>().StateChange();
        AudioManager.Instance().PlaySoundEffect(SOUND.CUBECLICK);
    }
  
    public bool IsClicked()
    {
        return GetComponentInChildren<Click>().IsClicked();
    }

    public int GetCubeIdx()
    {
        return index;
    }

    public SHAPE GetShape()
    {
        return GetComponentInChildren<Shape>().GetShape();
    }
    
    public COLOR GetColor()
    {
        return GetComponentInChildren<Shape>().GetColor();

    }

    public BGCOLOR GetBGColor()
    {
        return GetComponentInChildren<BackGround>().GetBGColor();

    }
 
}
