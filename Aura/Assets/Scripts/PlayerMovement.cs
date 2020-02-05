using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5.0f;
    public bool enabled = true;
    public bool invertYAxis;

    private int invert;

    void Update()
    {
        if (Input.GetKeyDown("escape")) {
			enabled = !enabled;
		}
        if (enabled) {
            ProcessInput(invertYAxis, invert);
        }
    }

    void ProcessInput(bool _invertYAxis, int _invert)
    {
        //Process Y Axis Inversion
        _invert = _invertYAxis ? -1 : 1;

        //Strafe Right
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += player.transform.right * speed * Time.deltaTime;
        }
        //Strafe Left
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += -player.transform.right * speed * Time.deltaTime;
        }
        //Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
        }
        //Move Back
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += -player.transform.forward * speed * Time.deltaTime;
        }
    }

    void EnableMovement() {
        enabled = true;
    }

    void DisableMovement() {
        enabled = false;
    }
}