using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource sfxAudioSource;
    AudioSource TypeAudioSource;
    AudioSource SfxPlusAudioSource;


    public AudioClip click;
    public AudioClip start;
    public AudioClip OK;
    public AudioClip back;
    public AudioClip brush1;
    public AudioClip brush2;
    public AudioClip GType;
    public AudioClip KType;
    public AudioClip Change;
    public AudioClip ChangeX;
    public AudioClip Spring1;
    public AudioClip Spring2;
    public AudioClip Spring3;
    public AudioClip Drop;
    public AudioClip Rain;
    public AudioClip GG;
    public AudioClip Walk;

    public bool isBrush1 = false;
    public bool isBrush2 = false;

    public int n;
    public int m;

    //public AudioClip Title;
    //public AudioClip Main;

    // Start is called before the first frame update
    void Awake()
    {
        sfxAudioSource = this.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        TypeAudioSource = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        SfxPlusAudioSource = this.transform.GetChild(3).gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySFX(string action)
    {
        switch (action)
        {
            case "Click":
                sfxAudioSource.clip = click;
                sfxAudioSource.loop = false;
                break;

            case "Start":
                sfxAudioSource.clip = start;
                sfxAudioSource.loop = false;
                break;

            case "OK":
                sfxAudioSource.clip = OK;
                sfxAudioSource.loop = false;
                break;

            case "Back":
                sfxAudioSource.clip = back;
                sfxAudioSource.loop = false;
                break;

            case "Brush":
                n = Random.Range(1, 3);
                if (n == 1)
                {
                    isBrush1 = true;
                    isBrush2 = false;

                }

                if (n == 2)
                {
                    isBrush1 = false;
                    isBrush2 = true;
                }
                break;

            case "Change":
                sfxAudioSource.clip = Change;
                sfxAudioSource.loop = false;
                break;

            case "ChangeX":
                sfxAudioSource.clip = ChangeX;
                sfxAudioSource.loop = false;
                break;

            case "Drop":
                sfxAudioSource.clip = Drop;
                sfxAudioSource.loop = false;
                break;

            case "Rain":
                sfxAudioSource.clip = Rain;
                sfxAudioSource.loop = false;
                break;

            case "GG":
                sfxAudioSource.clip = GG;
                sfxAudioSource.loop = false;
                break;

            case "Brush1":
                sfxAudioSource.clip = brush1;
                sfxAudioSource.loop = false;
                break;

            case "Brush2":
                sfxAudioSource.clip = brush2;
                sfxAudioSource.loop = false;
                break;

        }
        sfxAudioSource.Play();
    }

    public void playTyping(string action)
    {
        switch (action)
        {
            case "KType":
                TypeAudioSource.clip = KType;
                TypeAudioSource.loop = true;
                break;

            case "GType":
                TypeAudioSource.clip = GType;
                TypeAudioSource.loop = true;
                break;

            case "Walk":
                TypeAudioSource.clip = Walk;
                TypeAudioSource.loop = false;
                break;
        }
        TypeAudioSource.Play();
    }

    public void PlayPlus(string action)
    { 
        switch(action)
        {
            case "Spring":
                m = Random.Range(1, 4);
                if (m == 1)
                {
                    SfxPlusAudioSource.clip = Spring1;
                    SfxPlusAudioSource.loop = false;
                }

                if (m == 2)
                {
                    SfxPlusAudioSource.clip = Spring2;
                    SfxPlusAudioSource.loop = false;
                }
                if (m == 3)
                {
                    SfxPlusAudioSource.clip = Spring2;
                    SfxPlusAudioSource.loop = false;
                }
                break;
        }
        SfxPlusAudioSource.Play();
    }

    public void SFXStop()
    {
        sfxAudioSource.Stop();
    }

    public void typeStop()
    {
        TypeAudioSource.Stop();
    }
}
