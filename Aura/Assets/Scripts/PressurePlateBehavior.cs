using UnityEngine;

public class PressurePlateBehavior : MonoBehaviour
{
    public Action action;
    public new Action audio;

    private int numObjectsTriggered = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (numObjectsTriggered == 0)
        {
            action.Trigger();
            if (audio)
            {
                audio.Trigger();
            }
        }
        numObjectsTriggered++;
    }

    private void OnTriggerExit(Collider collider)
    {
        numObjectsTriggered--;
        if (numObjectsTriggered == 0)
        {
            action.Cease();
        }
    }
}
