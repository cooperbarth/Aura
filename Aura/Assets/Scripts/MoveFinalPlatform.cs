using UnityEngine;

public class MoveFinalPlatform : MoveAction
{
    public GameObject obj;
    public GameObject[] objectsToActivate;
    public AudioSource finalVoiceover;

    private bool activated = false;

    private void FixedUpdate()
    {
        if (!moving) { return; }
        float step = moveSpeed * Time.fixedDeltaTime;
        
        obj.transform.position = Vector3.MoveTowards(obj.transform.position,
                                                    target,
                                                    step);

        if (Vector3.Distance(obj.transform.position, target) < 0.001f)
        {
            Cease();
            onCompletion();
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

        // Play final Voiceover
        finalVoiceover.Play(2000);
    }

    public override void Cease()
    {
        moving = false;
    }

    public override void onCompletion()
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
