using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RayAudioSource : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        RayAudioManager.RegisterSource(this);
    }

    private void OnDestroy()
    {
        RayAudioManager.UnregisterSource(this);
    }
}
