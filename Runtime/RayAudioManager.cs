using System.Collections.Generic;
using UnityEngine;

public class RayAudioManager : MonoBehaviour
{
    private static RayAudioManager instance;
    public static RayAudioManager Instance => instance;

    private static List<RayAudioSource> sources = new();
    private static List<RayAudioListener> listeners = new();

    [Header("Raycast Settings")]
    public LayerMask obstructionMask;
    public float maxRange = 20f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            UnityEngine.Debug.LogWarning("multiple instances of singleton 'RayAudioManager'");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        foreach (var listener in listeners)
        {
            foreach (var source in sources)
            {
                Vector dir = source.transform.position - listener.transform.position;
                
                if (dir.magnitude > 0)
                    continue;

                if (!Physics.Raycast(listener.transform.position, dir.normalised, dir.magnitude, obstructionMask))
                {
                    //unobstructed line to listener from source

                }
            }
        }
    }

    public static void RegisterSource(RayAudioSource source)
    {
        if (!sources.Contains(source))
        {
            sources.Add(source);
        }
    }

    public static void UnregisterSource(RayAudioSource source)
    {
        sources.Remove(source);
    }

    public static void RegisterListener(RayAudioListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }
    
    public static void RegisterListener(RayAudioListener listener)
    {
        listeners.Remove(listener);
    }
}
