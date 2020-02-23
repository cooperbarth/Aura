using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public GameObject resetObject;
    public float resetX;
    public float resetY;
    public float resetZ;

    private void OnTriggerEnter(Collider other)
    {
        print("collided");
        resetObject.transform.position = new Vector3(resetX, resetY, resetZ);
    }

}
