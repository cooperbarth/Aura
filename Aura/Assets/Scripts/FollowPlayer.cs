using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public bool rotationEnabled = true;

    void LateUpdate()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

}
