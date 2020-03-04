using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AuraDetach : MonoBehaviour
{

    public GameObject aura;
    public GameObject character;
    public new bool enabled = true;

    private FirstPersonController auraController;
    private FirstPersonController playerController;

    private bool playerHasControl;
    private bool attached;
    private FollowPlayer follow;
    private MeshRenderer render;

    private float prevJumpSpeedPlayer;
    private float prevRunSpeedPlayer;
    private float prevWalkSpeedPlayer;

    private void Start()
    {
        follow = aura.GetComponent<FollowPlayer>();
        auraController = aura.GetComponent<FirstPersonController>();
        playerController = character.GetComponent<FirstPersonController>();
        render = aura.GetComponent<MeshRenderer>();

        playerHasControl = true;
        attached = true;
        follow.enabled = true;
        render.enabled = false;
    }

    void Update()
    {
        if (enabled)
        {
            ProcessInput();
        }
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.R) && !attached)
        {
            aura.transform.position = character.transform.position;
            aura.transform.rotation = character.transform.rotation;
            ToggleAttached();
            TogglePlayer(true);
            ToggleAura(false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (attached)
            {
                ToggleAttached();
            }
            TogglePlayer(!playerHasControl);
            ToggleAura(playerHasControl);
            playerHasControl = !playerHasControl;
        }  
    }

    private void ToggleAttached()
    {
        attached = !attached;
        follow.enabled = !follow.enabled;
        render.enabled = !render.enabled;
    }

    private void ToggleAura(bool on)
    {
        if (on)
        {
            auraController.m_JumpSpeed = prevJumpSpeedPlayer;
            auraController.m_RunSpeed = prevWalkSpeedPlayer;
            auraController.m_WalkSpeed = prevWalkSpeedPlayer;
        }
        else
        {
            auraController.m_JumpSpeed = 0;
            auraController.m_RunSpeed = 0;
            auraController.m_WalkSpeed = 0;
        }
    }

    private void TogglePlayer(bool on)
    {
        if (on)
        {
            playerController.m_JumpSpeed = prevJumpSpeedPlayer;
            playerController.m_RunSpeed = prevRunSpeedPlayer;
            playerController.m_WalkSpeed = prevWalkSpeedPlayer;
        }
        else
        {
            prevJumpSpeedPlayer = playerController.m_JumpSpeed;
            prevRunSpeedPlayer = playerController.m_RunSpeed;
            prevWalkSpeedPlayer = playerController.m_WalkSpeed;

            playerController.m_JumpSpeed = 0;
            playerController.m_RunSpeed = 0;
            playerController.m_WalkSpeed = 0; 
        }
        
    }

    

}
