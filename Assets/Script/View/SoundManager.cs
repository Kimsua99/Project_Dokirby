using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource sfxAudioSource;
    AudioSource typeAudioSource;

    public AudioClip click;
    public AudioClip start;
    public AudioClip OK;
    public AudioClip back;
    public AudioClip brush1;
    public AudioClip brush2;
    public AudioClip GType;
    public AudioClip KType;
    public AudioClip Change;
    public AudioClip Spring1;
    public AudioClip Spring2;
    public AudioClip Spring3;

    public AudioClip Title;
    public AudioClip Main;

    // Start is called before the first frame update
    void Start()
    {
        sfxAudioSource = this.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        typeAudioSource = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
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
                int n = Random.Range(1, 3);
                if (n == 1)
                {
                    sfxAudioSource.clip = brush1;
                    sfxAudioSource.loop = false;
                }

                if (n == 2)
                {
                    sfxAudioSource.clip = brush2;
                    sfxAudioSource.loop = false;
                }
                break;

            case "Change":
                sfxAudioSource.clip = Change;
                sfxAudioSource.loop = true;
                break;

            case "Spring":
                int m = Random.Range(1, 4);
                if (m == 1)
                {
                    sfxAudioSource.clip = Spring1;
                    sfxAudioSource.loop = false;
                }

                if (m == 2)
                {
                    sfxAudioSource.clip = Spring2;
                    sfxAudioSource.loop = false;
                }
                if (m == 3)
                {
                    sfxAudioSource.clip = Spring2;
                    sfxAudioSource.loop = false;
                }
                break;

        }
        sfxAudioSource.Play();
    }

    public void playTyping(string action)
    {
        switch (action)
        {
            case "KType":
                sfxAudioSource.clip = KType;
                sfxAudioSource.loop = true;
                break;

            case "GType":
                sfxAudioSource.clip = GType;
                sfxAudioSource.loop = true;
                break;
        }
        typeAudioSource.Play();
    }

    public void SFXStop()
    {
        sfxAudioSource.Stop();
    }

    public void typeStop()
    {
        typeAudioSource.Stop();
    }
}
