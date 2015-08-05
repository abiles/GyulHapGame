using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    //// Effect
    public AudioClip aha;
    public AudioClip wrong;
    public AudioClip combo;
    public AudioClip cubeClick;

    /////BGM
    public AudioClip tenbi;

    private AudioSource audioSource;
    private AudioClip chosenAudio = new AudioClip();
    private AudioClip chosenBGM = new AudioClip();
    private static  AudioManager instance = null;

    public static AudioManager Instance()
    {
        return instance;
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();

        if(instance == null)
        {
            instance = this;
        }
	}
	

    public void PlaySoundEffect(SOUND sound)
    {
        bool isPlay = true;

        switch(sound)
        {
            case SOUND.AHA:
                chosenAudio = aha;
                break;
            case SOUND.COMBO:
                chosenAudio = combo;
                break;
            case SOUND.WRONG:
                chosenAudio = wrong;
                break;
            case SOUND.CUBECLICK:
                chosenAudio = cubeClick;
                break;
            default:
                isPlay = false;
                break;

        }

        if(isPlay)
        {
            audioSource.PlayOneShot(chosenAudio, 1);
        }
    }

    //public void PlayBGM(BGM bgm)
    //{
    //    bool isPlay = true;

    //    switch(bgm)
    //    {
    //        case BGM.TENBI:
    //            chosenBGM = tenbi;
    //            break;
    //        default:
    //            isPlay = false;
    //            break;
    //    }

    //    if(isPlay)
    //    {
    //        audioSource.Play();
    //    }
    //}
}
