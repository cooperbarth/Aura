using System;
using System.Threading.Tasks;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    public float volumeLevel = 0f;
    public new AudioSource[] audio;

    public async void OnTriggerEnter(Collider other)
    {
        while (true)
        {
            bool anyPlaying = false;
            foreach (AudioSource track in audio)
            {
                if (track.volume > 0)
                {
                    anyPlaying = true;
                    track.volume -= 0.1f;
                }
                else
                {
                    track.enabled = false;
                }
            }
            if (!anyPlaying)
            {
                break;
            }
            await Task.Delay(100);
        }
        
    }
}
