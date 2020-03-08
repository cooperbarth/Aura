using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public new CapsuleCollider collider;
    public bool rotationEnabled = true;

    void LateUpdate()
    {
        transform.position = player.transform.position;
        collider.transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        collider.transform.rotation = player.transform.rotation;
    }

}
