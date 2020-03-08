﻿using UnityEngine;

public class DisableSoundOnClick : MonoBehaviour
{
    public new AudioSource audio;
    public GameObject player;
    public float interactDistance = -1.0f;

    private void OnMouseDown()
    {
        Vector3 a = player.transform.position;
        Vector3 b = transform.position;
        Vector3 d = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        if (interactDistance > 0 && d.magnitude > interactDistance) { return; }

        audio.enabled = false;
    }
}
