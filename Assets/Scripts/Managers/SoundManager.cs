using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource goodSound;
    public AudioSource jumpSound;
    public AudioSource thud;
    public AudioSource groundPound;
    public AudioSource badSound;

    // play the coin sound
    public void PlayGoodSound()
    {
        goodSound.Play();
    }

    public void PlayJumpSound()
    {
        jumpSound.Play();
    }

    public void PlayThud()
    {
        thud.Play();
    }

    public void PlayGroundPound()
    {
        groundPound.Play();
    }

     public void PlayBadSound()
    {
        badSound.Play();
    }
}
