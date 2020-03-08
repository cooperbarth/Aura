using UnityEngine;

public class AudioSequence : MonoBehaviour
{
    public AudioAction[] audioActions;
    public Action[] completionActions;

    private bool completed = false;
    private int currElement = 0;
    private readonly int[] code = new int[] { 1, 2, 0, 0, 2 };

    public void Cease()
    {
        currElement = 0;
        // Play bad sound
    }

    public void OnCompletion()
    {
        completed = true;
        foreach (Action completionAction in completionActions)
        {
            completionAction.Trigger();
        }
    }

    public void Trigger(int identifier)
    {
        if (completed) { return; }
        if (identifier == code[currElement])
        {
            currElement++;
            if (currElement >= code.Length)
            {
                OnCompletion();
            }
            else
            {
                AudioAction currAction = GetAudioAction();
                currAction.Trigger();
            }
        }
        else
        {
            Cease();
        }
    }

    public void ResetCurrElement()
    {
        currElement = 0;
    }

    public AudioAction GetAudioAction()
    {
        return audioActions[code[currElement]];
    }
}
