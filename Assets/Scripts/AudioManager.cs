using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    [SerializeField]
    private AudioSource mainSound, soundEffectDead, soundEffectLeave, soundEffectShotBall;
    void Start()
    {
        if (AudioManager.audioManager == null)
        {
            DontDestroyOnLoad(gameObject);
            AudioManager.audioManager = this;
            mainSound.Play();
            soundEffectShotBall.volume = 0.1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffectDead()
    {
        soundEffectDead.Play();
    }

    public void PlaySoundEffectLeave()
    {
        soundEffectLeave.Play();
    }

    public void PlaySoundEffectShotBall()
    {
        soundEffectShotBall.Play();
    }
}
