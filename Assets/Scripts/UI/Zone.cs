using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Zone : MonoBehaviour
{
    public GameObject Effect;
    public AudioSource targetAudioSource;
    public AudioClip zoneClip;

    public bool isSafe = true;

    private AudioClip previousClip;

    private void Start()
    {
        previousClip = targetAudioSource.clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isSafe)
            {
                ActiveFalse(other);
                if (targetAudioSource)
                {
                    targetAudioSource.Stop();
                    targetAudioSource.clip = previousClip;
                    if (previousClip != null)
                        targetAudioSource.Play();
                }
            }
            else
            {
                ActiveTrue(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isSafe)
            {
                ActiveTrue(other);
            }
            else
            {
                ActiveFalse(other);
            }
        }
    }

    private void ActiveTrue(Collider other)
    {
        if (Effect) Effect.SetActive(true);

        if (targetAudioSource)
        {
            previousClip = targetAudioSource.clip;
            targetAudioSource.clip = zoneClip;
            targetAudioSource.Play();
        }
    }

    private void ActiveFalse(Collider other)
    {
        if (Effect) Effect.SetActive(false);

        if (targetAudioSource)
        {
            targetAudioSource.Stop();
            targetAudioSource.clip = previousClip;
            if (previousClip != null)
                targetAudioSource.Play();
        }
    }
}
