using System;
using System.Threading.Tasks;
using UnityEngine;

public class TextAction : Action
{
    public GameObject text;
    public float waitTimeSeconds = 3f;
    public bool once = true;
    public Action[] completionActions;

    private bool shown = false;

    public override void Cease()
    {
        text.SetActive(false);
        onCompletion();
    }

    public override void onCompletion()
    {
        foreach (Action action in completionActions)
        {
            action.Trigger();
        }
    }

    public async override void Trigger()
    {
        if (!(once && shown))
        {
            shown = true;
            text.SetActive(true);
            await Task.Delay(Convert.ToInt32(waitTimeSeconds * 1000));
            Cease();
        }
    }
}
