using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float delta_x;
    public float delta_y;
    public float delta_z;
    public float moveSpeed = 1.0f;

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
        moving = true;

        // Calculate ending position
        target = transform.position;
        target.x += delta_x;
        target.y += delta_y;
        target.z += delta_z;
    }

}
