using UnityEngine;

public class MoveFinalPlatform : MoveAction
{
    public GameObject obj;
    public GameObject[] objectsToActivate;
    public AudioSource finalVoiceover;
    public GameObject[] objectsToDisable;
    public GameObject door;

    public AuraDetach ret;
    public GameObject keybinds;

    private bool activated = false;

    private void FixedUpdate()
    {
        if (!moving) { return; }
        float step = moveSpeed * Time.fixedDeltaTime;
        
        obj.transform.position = Vector3.MoveTowards(obj.transform.position,
                                                    target,
                                                    step);

        if (!finalVoiceover.isPlaying)
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
        finalVoiceover.PlayDelayed(5);
    }

    public override void Cease()
    {
        moving = false;
    }

    public override void onCompletion()
    {
        Application.Quit();
    }

    private void ActivateObjects()
    {
        door.transform.position = new Vector3(
            door.transform.position.x,
            door.transform.position.y + 9,
            door.transform.position.z
        );
        foreach (GameObject o in objectsToActivate)
        {
            MeshRenderer mesh = o.GetComponent<MeshRenderer>();
            mesh.enabled = false;
            o.SetActive(true);
        }
    }
}
