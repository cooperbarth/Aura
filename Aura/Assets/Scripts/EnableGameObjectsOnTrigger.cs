using UnityEngine;

public class EnableGameObjectsOnTrigger : MonoBehaviour
{
    public bool once = true;
    public GameObject[] objects;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!(once && triggered))
        {
            triggered = true;
            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
            };
        }
    }
}
