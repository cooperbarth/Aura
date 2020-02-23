using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float delta_x;
    public float delta_y;
    public float delta_z;
    public float moveSpeed = 1.0f;
    public GameObject player;
    public float interactDistance = -1.0f;

    private bool moving = false;
    private bool open = false;
    private Vector3 target;

    private void Update()
    {
        if (!moving) { return; }
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,
                                                 target,
                                                 step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            moving = false;
            open = true;
        }
    }

    private void OnMouseDown()
    {
        if (open || moving) { return; }
        Vector3 a = player.transform.position;
        Vector3 b = transform.position;
        Vector3 d = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

        if (interactDistance > 0 && d.magnitude > interactDistance) { return; }
        moving = true;

        // Calculate ending position
        target = transform.position;
        target.x += delta_x;
        target.y += delta_y;
        target.z += delta_z;
    }

}
