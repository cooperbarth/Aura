using System;
using UnityEngine;

public class AudioAction : Action
{
    public AudioSource onTrigger;
    public float onTriggerDelaySeconds = 0.0f;
    public AudioSource afterTrigger;
    public float afterTriggerDelaySeconds = 0.0f;
    public bool onTriggerEnabled = true;
    public bool onceOnTrigger = true;
    public bool afterTriggerEnabled = true;
    public bool onceAfterTrigger = true;
    public Action[] completionActions;

    private bool playedOnTrigger = false;
    private bool playedAfterTrigger = false;

    override public void Trigger()
    {
        if (onTriggerEnabled && !(onceOnTrigger && playedOnTrigger))
        {
            ulong delay = Convert.ToUInt64(onTriggerDelaySeconds * 1000);
            onTrigger.Play(delay);
            playedOnTrigger = true;
        }
    }

    override public void Cease()
    {
        if (afterTriggerEnabled && !(onceAfterTrigger && playedAfterTrigger))
        {
            ulong delay = Convert.ToUInt64(afterTriggerDelaySeconds * 1000);
            afterTrigger.Play(delay);
            playedAfterTrigger = true;
            onCompletion();
        }
    }

    public override void onCompletion()
    {
        foreach (Action action in completionActions)
        {
            action.Trigger();
        }
    }
}
