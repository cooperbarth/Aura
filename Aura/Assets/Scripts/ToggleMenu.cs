using UnityEngine;
using System.Collections;

public class ToggleMenu : MonoBehaviour
{

    public GameObject menu;

    private bool locked;

    public void Start ()
    {
        Screen.lockCursor = true;
        locked = true;
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        // Open or close menu
        if (Input.GetKeyDown("escape"))
        {
            locked = !locked;
            Screen.lockCursor = locked;
            menu.SetActive(!menu.activeSelf);
        }
    }

}