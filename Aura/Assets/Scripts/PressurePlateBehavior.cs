using UnityEngine;

public class PressurePlateBehavior : MonoBehaviour
{
    public Action action;

    private void OnCollisionEnter(Collision collision)
    {
        action.Trigger();
    }

    private void OnCollisionExit(Collision collision)
    {
        action.Cease();
    }
}
