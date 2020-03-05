using UnityEngine;

public class MoveFinalPlatform : Action
{
    public float delta_x;
    public float delta_y;
    public float delta_z;
    public float moveSpeed = 1.0f;
    public GameObject obj;
    public GameObject[] objectsToActivate;

    private bool activated = false;
    private bool moving = false;
    private Vector3 target;

    private void FixedUpdate()
    {
        if (!moving) { return; }
        float step = moveSpeed * Time.deltaTime;
        
        obj.transform.position = Vector3.MoveTowards(obj.transform.position,
                                                 target,
                                                 step);

        if (Vector3.Distance(obj.transform.position, target) < 0.001f)
        {
            moving = false;
            Cease();
        }
    }

    public override void Trigger()
    {
        if (activated) { return; }
        ActivateObjects();
        activated = true;
        moving = true;

        // Calculate ending position
        target = obj.transform.position;
        target.x += delta_x;
        target.y += delta_y;
        target.z += delta_z;
    }

    public override void Cease()
    {
        Application.Quit();
    }

    public void ActivateObjects()
    {
        foreach (GameObject o in objectsToActivate)
        {
            MeshRenderer mesh = o.GetComponent<MeshRenderer>();
            mesh.enabled = false;
            o.SetActive(true);
        }
    }
}
