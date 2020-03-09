using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class IntroSequence : MonoBehaviour
{
    public GameObject[] tooltips;
    public FirstPersonController controller;
    public new Camera camera;
    public GameObject reticle;
    public AudioSource[] externals;

    public AudioSource intro;
    public float startTimeSeconds = 2f;
    public float visibleTimeSeconds = 3f;
    public float waitTimeSeconds = 5f;

    private bool introDone = false;

    void Start()
    {
        Toggle(false);
        intro.PlayDelayed(Convert.ToInt32(startTimeSeconds));
    }

    async void Update()
    {
        if (introDone || intro.isPlaying) { return; }
        introDone = true;
        Toggle(true);

        int startTime = Convert.ToInt32(startTimeSeconds * 1000);
        int visibleTime = Convert.ToInt32(visibleTimeSeconds * 1000);
        int waitTime = Convert.ToInt32(waitTimeSeconds * 1000);

        await Task.Delay(startTime);
        foreach (GameObject text in tooltips)
        {
            text.SetActive(true);
            await Task.Delay(visibleTime);
            text.SetActive(false);
            await Task.Delay(waitTime);
        }
    }

    private void Toggle(bool on)
    {
        controller.enabled = on;
        camera.enabled = on;
        reticle.SetActive(on);
        foreach (AudioSource a in externals)
        {
            a.enabled = on;
        }
    }
}
