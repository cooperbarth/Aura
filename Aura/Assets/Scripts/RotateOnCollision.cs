using System;
using System.Threading.Tasks;
using UnityEngine;

public class RotateOnCollision : MonoBehaviour
{
    public float waitTimeSeconds = 3.0f;
    public GameObject obj;

    private bool rotated;

    private void Start()
    {
        rotated = false;
    }

    private async void OnTriggerEnter(Collider collider)
    {
        print("hi");
        if (rotated) { return; }
        print("hi again");
        obj.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        rotated = true;
        await Task.Delay(Convert.ToInt32(waitTimeSeconds * 1000));
        obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        rotated = false;
    }
}
