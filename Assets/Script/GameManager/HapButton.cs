using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HapButton : MonoBehaviour {


    public void HapButtonClick()
    {
        Debug.Log("hap");
        if(GameManager.Instance().IsHap())
        {
            // 맞았다는 sound and 점수 갱신, 콤보 갱신
            AudioManager.Instance().PlaySoundEffect(SOUND.AHA);
        }
        else
        {
            // 틀렸다는 sound and 
            AudioManager.Instance().PlaySoundEffect(SOUND.WRONG);
        }

        GameManager.Instance().ClearClickedCube();
    }
}
