using UnityEngine;

public class DisableMusicOnTrigger : MonoBehaviour
{
    public AudioSource music;
    public bool once = true;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!(once && triggered))
        {
            triggered = true;
            music.Stop();
        }
    }

}
