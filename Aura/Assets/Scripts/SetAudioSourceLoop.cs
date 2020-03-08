using UnityEngine;

public class SetAudioSourceLoop : MonoBehaviour
{
    public new AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        audio.loop = true;
    }
}
