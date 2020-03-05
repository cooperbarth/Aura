using UnityEngine;

public class PlayMusicOnTrigger : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource main;
    public bool once = true;

    private bool introPlayed = false;
    private bool mainStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!(once && introPlayed))
        {
            print("hewwo");
            intro.Play(0);
            introPlayed = true;
        }
    }

    private void Update()
    {
        if (introPlayed && !mainStarted && !intro.isPlaying)
        {
            mainStarted = true;
            main.Play(0);
        }
    }
}
