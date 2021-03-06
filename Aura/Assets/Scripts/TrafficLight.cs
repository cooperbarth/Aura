﻿using System;
using System.Threading.Tasks;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] platforms;

    private new Renderer renderer;

    public void Start()
    {
        while (!renderer)
        {
            renderer = GetComponent<Renderer>();
        }
        SwitchColor();
    }

    private async void SwitchColor()
    {
        while (true)
        {
            if (renderer) { renderer.material = materials[0]; }
            await Task.Delay(Convert.ToInt32(4000));
            if (renderer) { renderer.material = materials[1]; }
            await Task.Delay(Convert.ToInt32(1500));
            if (renderer)
            {
                renderer.material = materials[2];
                RotatePlatforms(true);
                await Task.Delay(Convert.ToInt32(500));
                RotatePlatforms(false);
            }
        }
    }

    private void RotatePlatforms(bool on)
    {
        if (on)
        {
            foreach(GameObject obj in platforms)
            {
                if (obj)
                {
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                }
            }
        }
        else
        {
            foreach(GameObject obj in platforms)
            {
                if (obj)
                {
                    obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
            }
        }
    }
}
