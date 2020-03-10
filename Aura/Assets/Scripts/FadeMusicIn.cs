using System.Threading.Tasks;
using UnityEngine;

public class FadeMusicIn : MonoBehaviour
{
    public float volumeLevel = 1f;
    public new AudioSource[] audio;

    public async void OnTriggerEnter(Collider other)
    {
        foreach (AudioSource track in audio)
        {
            track.enabled = true;
            track.volume = 0;
        }
        while (true)
        {
            bool anyNotDone = false;
            foreach (AudioSource track in audio)
            {
                if (track.volume < volumeLevel)
                {
                    anyNotDone = true;
                    track.volume += 0.025f;
                }
            }
            if (!anyNotDone)
            {
                break;
            }
            await Task.Delay(100);
        }
        
    }
}
