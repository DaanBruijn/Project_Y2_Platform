using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource goodSound;
    public AudioSource jumpSound;

    // play the coin sound
    public void PlayGoodSound()
    {
        goodSound.Play();
    }

    public void PlayJumpSound()
    {
        jumpSound.Play();
    }
}
