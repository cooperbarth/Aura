using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public abstract void Cease();
    public abstract void onCompletion();
    public abstract void Trigger();
}
