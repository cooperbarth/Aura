using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public new AudioSource audio;
    public bool once = true;
    public float delay = 0f;

    private bool audioPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!(once && audioPlayed))
        {
            audio.PlayDelayed(delay);
            audioPlayed = true;
        }
    }

}
