using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GyulButton : MonoBehaviour {


    public void GyulBottonClick()
    {

        if(GameManager.Instance().IsNextGame())
        {
            // 다음 단계로의 전환을 준비한다. 
            // 여기서 바뀌는 소리를 낼까
            // 새로운 그림으로 바꾸기.
            GameManager.Instance().ChangeCurCombi();
            AudioManager.Instance().PlaySoundEffect(SOUND.COMBO);
            
        }
        else
        {
            // 아직 답이 남은 것이므로 뭐 틀렸다 소리를 내던지 뭐하던지 해야겠지?
            // 콤보 초기화
            AudioManager.Instance().PlaySoundEffect(SOUND.WRONG);
        }

        GameManager.Instance().ClearClickedCube();
    }
}
