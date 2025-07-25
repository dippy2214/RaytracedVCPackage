using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAudioListener : MonoBehaviour
{
    private void OnEnable()
    {
        RayAudioManager.RegisterListener(this);
    }

    private void OnDisable()
    {
        RayAudioManager.UnregisterListener(this);
    }

    public void ReceiveAudio(AudioClip clip)
    {

    }
}
