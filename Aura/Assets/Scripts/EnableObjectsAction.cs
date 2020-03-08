using UnityEngine;
using System.Collections;

public class EnableObjectsAction : Action
{
    public GameObject[] objects;
    public Action[] completionActions;

    public override void Cease() { }

    public override void onCompletion()
    {
        foreach (Action action in completionActions)
        {
            action.Trigger();
        }
    }

    public override void Trigger()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
