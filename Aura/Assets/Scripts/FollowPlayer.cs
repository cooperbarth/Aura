using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    void LateUpdate()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

}
