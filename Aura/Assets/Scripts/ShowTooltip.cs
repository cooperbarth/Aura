using System;
using System.Threading.Tasks;
using UnityEngine;

public class ShowTooltip : MonoBehaviour
{
    public GameObject text;
    public float waitTimeSeconds = 3f;
    public bool once = true;

    private bool shown = false;

    async private void OnTriggerEnter(Collider other)
    {
        if (!(once && shown))
        {
            shown = true;
            text.SetActive(true);
            await Task.Delay(Convert.ToInt32(waitTimeSeconds * 1000));
            text.SetActive(false);
        }
    }
}
