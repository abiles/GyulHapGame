using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

    bool isClicked = false;

	void Start () {
	
	}
	
	void Update () {
        
	
	}

    int firstY = 2;

    public void StateChange()
    {
        if(isClicked)
        {
            Debug.Log("ClickNum --");
            //Debug.LogException("ClickNum--");
            isClicked = false;
            Vector3 invisiblePosition = new Vector3(transform.position.x, -10, transform.position.z);
            transform.position = invisiblePosition;
        }
        else
        {
            Debug.Log("ClickNum ++");
            isClicked = true;
            Vector3 visiblePosition = new Vector3(transform.position.x, firstY, transform.position.z);
            transform.position = visiblePosition;
            
        }
    }

    public bool IsClicked()
    {
        return isClicked;
    }
}
