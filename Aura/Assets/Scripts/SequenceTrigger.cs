using UnityEngine;

public class SequenceTrigger : MonoBehaviour
{
    public OnClickSequenceSend[] triggers;
    public Action action;
    public bool once = true;
    public AudioSource failureSound;


    private readonly int[] correct = new int[] { 0, 1, 0, 2, 0, 2, 0, 1, 2, 1, 0 };
    private int[] sequence;
    private int currentIndex = 0;
    private bool completed = false;

    private void Start()
    {
        sequence = new int[correct.Length];
    }

    public void Send(int senderId)
    {
        if (once && completed) { return; }
        foreach (OnClickSequenceSend trigger in triggers)
        {
            int _id = trigger._id;
            if (_id == senderId)
            {
                if (correct[currentIndex] == _id)  // Correct guess
                {
                    sequence[currentIndex] = _id;
                    currentIndex++;
                    if (currentIndex == correct.Length)
                    {
                        completed = true;
                        PerformAction();
                    }
                }
                else  // Incorrect guess
                {
                    sequence = new int[correct.Length];
                    if (currentIndex > 0)
                    {
                        currentIndex = 0;
                        PlaySound();
                    }
                }
                break;
            }
        }
    }

    private void PlaySound()
    {
        failureSound.Play();
    }

    private void PerformAction()
    {
        action.Trigger();
    }
}
