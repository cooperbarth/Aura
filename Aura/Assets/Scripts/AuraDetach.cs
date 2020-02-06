using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AuraDetach : MonoBehaviour
{

    public GameObject aura;
    public GameObject character;

    private bool attached = true;
    private FirstPersonController auraController;
    private FirstPersonController playerController;
    private FollowPlayer follow;

    private void Start()
    {
        auraController = aura.GetComponent<FirstPersonController>();
        follow = aura.GetComponent<FollowPlayer>();
        playerController = character.GetComponent<FirstPersonController>();
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!attached)
            {
                aura.transform.position = character.transform.position;
                aura.transform.rotation = character.transform.rotation;
            }
            attached = !attached;
            auraController.enabled = !auraController.enabled;
            follow.enabled = !follow.enabled;
            playerController.enabled = !playerController.enabled;
        }
    }

}
