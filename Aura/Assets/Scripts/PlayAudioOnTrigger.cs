using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public new AudioSource audio;
    public bool once = true;

    private bool audioPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!(once && audioPlayed))
        {
            audio.Play(0);
            audioPlayed = true;
        }
    }

}
