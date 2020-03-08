using UnityEngine;

public class AudioSequenceStart : MonoBehaviour
{
    public AudioSequence sequence;

    public void OnMouseDown()
    {
        sequence.ResetCurrElement();
        if (sequence.audioActions.Length > 0)
        {
            AudioAction action = sequence.GetAudioAction();
            action.Trigger();
        }
    }
}
