using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float delta_x;
    public float delta_y;
    public float delta_z;
    public float moveSpeed = 1.0f;
    public GameObject player;
    public GameObject moveObject;
    public float interactDistance = -1.0f;
    public bool once = false;

    private bool moving = false;
    private bool moved = false;
    private Vector3 target;

    private void Update()
    {
        if (!moving) { return; }
        float step = moveSpeed * Time.deltaTime;
        moveObject.transform.position = Vector3.MoveTowards(
                                                 moveObject.transform.position,
                                                 target,
                                                 step);

        if (Vector3.Distance(moveObject.transform.position, target) < 0.001f)
        {
            moving = false;
            moved = true;
        }
    }

    private void OnMouseDown()
    {
        if (moving || (once && moved)) { return; }
        Vector3 a = player.transform.position;
        Vector3 b = transform.position;
        Vector3 d = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

        if (interactDistance > 0 && d.magnitude > interactDistance) { return; }
        moving = true;

        // Calculate ending position
        target = moveObject.transform.position;
        target.x += delta_x;
        target.y += delta_y;
        target.z += delta_z;
    }

}
