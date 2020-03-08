public class AudioSequenceTrigger : Action
{
    public AudioSequence sequence;
    public int identifier;

    public override void Cease() {}

    public override void onCompletion() {}

    public override void Trigger()
    {
        sequence.Trigger(identifier);
    }
}
