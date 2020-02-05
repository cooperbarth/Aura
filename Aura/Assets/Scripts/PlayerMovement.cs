using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    // public float rotationSpeed = 90.0f;
    public bool enabled = true;
    public bool invertYAxis;

    private Vector3[] transformRotations = new Vector3[5];
    private Vector3[] transformPositions = new Vector3[5];
    private int invert;
    private Vector3 resetPosition = new Vector3(0, 0, 0);
    private Vector3 resetRotation = new Vector3(0, 0, 0);
    private bool compare;

    void Update()
    {
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
            transform.position += transform.right * speed * Time.deltaTime;
        }
        //Strafe Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        //Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        //Move Back
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }

        /*
        //Rotate Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
        //Rotate Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }
        //Reset Camera Position
        if (Input.GetKey(KeyCode.T))
        {
            transform.position = new Vector3(0, 0, 0);
        }
        */

        //Cache and Recall Camera Positions
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //Cache positions/rotations with Shift-NumberKey
            if (Input.GetKeyDown(KeyCode.Alpha1)) { CacheTransform(transform, 0); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { CacheTransform(transform, 1); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { CacheTransform(transform, 2); }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { CacheTransform(transform, 3); }
            if (Input.GetKeyDown(KeyCode.Alpha5)) { CacheTransform(transform, 4); }
        }
        //Recall positions with NumberKey
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { MoveTransform(0); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { MoveTransform(1); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { MoveTransform(2); }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { MoveTransform(3); }
            if (Input.GetKeyDown(KeyCode.Alpha5)) { MoveTransform(4); }
        }
    }

    void CacheTransform(Transform _transform, int _index)
    {
        transformPositions[_index] = _transform.position;
        transformRotations[_index] = _transform.eulerAngles;
        Debug.Log("Cached Preset " + (_index+1).ToString());
    }

    void MoveTransform(int _index)
    {
        if (transformPositions[_index] != null && transformRotations[_index] != null)
        {
            transform.position = transformPositions[_index];
            transform.eulerAngles = transformRotations[_index];
            Debug.Log("Preset " + (_index+1).ToString() + " Restored");
        }
        else
        {
            Debug.Log("No preset cached");
        }
    }

    void EnableMovement() {
        enabled = true;
    }

    void DisableMovement() {
        enabled = false;
    }
}