using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AuraDetach : MonoBehaviour
{

    public GameObject aura;
    public GameObject character;
    public new bool enabled = true;

    private bool attached = true;
    private FirstPersonController playerController;
    private FollowPlayer follow;
    private MeshRenderer render;

    private float prevJumpSpeed;
    private float prevRunSpeed;
    private float prevWalkSpeed;

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
        if (enabled && Input.GetKeyDown(KeyCode.E))
        {
            if (attached)
            {
                prevJumpSpeed = playerController.m_JumpSpeed;
                prevRunSpeed = playerController.m_RunSpeed;
                prevWalkSpeed = playerController.m_WalkSpeed;

                playerController.m_JumpSpeed = 0;
                playerController.m_RunSpeed = 0;
                playerController.m_WalkSpeed = 0;
            }
            else
            {
                playerController.m_JumpSpeed = prevJumpSpeed;
                playerController.m_RunSpeed = prevRunSpeed;
                playerController.m_WalkSpeed = prevWalkSpeed;
            }
            aura.transform.position = character.transform.position;
            aura.transform.rotation = character.transform.rotation;
            attached = !attached;
            follow.enabled = !follow.enabled;
            render.enabled = !render.enabled;
        }
    }

}
