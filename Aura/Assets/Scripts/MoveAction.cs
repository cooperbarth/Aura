using UnityEngine;

public class MoveAction : Action
{
    public float delta_x;
    public float delta_y;
    public float delta_z;
    public float moveSpeed = 1.0f;
    public bool once = true;
    public Action[] completionActions;

    internal bool moving = false;
    private bool moved = false;
    private Vector3 originalPosition;
    internal Vector3 target;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!moving) { return; }
        float step = moveSpeed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position,
                                                 target,
                                                 step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            print(transform.position);
            moving = false;
            moved = true;
        }
    }

    override public void Trigger()
    {
        if (moving || (once && moved)) { return; }

        // Calculate ending position
        target = transform.position;
        target.x += delta_x;
        target.y += delta_y;
        target.z += delta_z;
        moving = true;
    }

    override public void Cease()
    {
        // Calculate ending position
        target = originalPosition;
        moving = true;
    }

    public override void onCompletion()
    {
        foreach(Action action in completionActions)
        {
            action.Trigger();
        }
    }
}
