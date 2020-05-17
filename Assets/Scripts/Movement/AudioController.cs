using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public CharacterInputHandler inputHandler;
    public BasicDamageController damageController;

    public AudioSource WalkingAudio;
    void Start()
    {
        inputHandler.OnMoving += PlayWalk;
        inputHandler.OnStop += StopWalk;
    }

    void PlayWalk()
    {
        if (!this.WalkingAudio.isPlaying)
            this.WalkingAudio.Play();
    }

    void StopWalk()
    {
        if (this.WalkingAudio.isPlaying)
            this.WalkingAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
