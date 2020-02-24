using UnityEngine;

public class SoundOnClick : MonoBehaviour
{
    public new AudioSource audio;
    public GameObject player;
    public float interactDistance = -1.0f;
    public bool once = true;

    private bool played = false;

    private void OnMouseDown()
    {
        if (once && played) { return; }

        Vector3 a = player.transform.position;
        Vector3 b = transform.position;
        Vector3 d = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

        if (interactDistance > 0 && d.magnitude > interactDistance) { return; }
        played = true;
        audio.Play(0);
    }
}
