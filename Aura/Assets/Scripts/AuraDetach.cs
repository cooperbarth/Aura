using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AuraDetach : MonoBehaviour
{

    public GameObject aura;
    public GameObject character;

    private bool attached = true;
    private FirstPersonController playerController;
    private FollowPlayer follow;
    private MeshRenderer render;

    private void Start()
    {
        follow = aura.GetComponent<FollowPlayer>();
        playerController = character.GetComponent<FirstPersonController>();
        render = aura.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (attached)
            {
                playerController.m_JumpSpeed = 0;
                playerController.m_RunSpeed = 0;
                playerController.m_WalkSpeed = 0;
            }
            else
            {
                playerController.m_JumpSpeed = 10;
                playerController.m_RunSpeed = 8;
                playerController.m_WalkSpeed = 5;
            }
            aura.transform.position = character.transform.position;
            aura.transform.rotation = character.transform.rotation;
            attached = !attached;
            follow.enabled = !follow.enabled;
            render.enabled = !render.enabled;
        }
    }

}
