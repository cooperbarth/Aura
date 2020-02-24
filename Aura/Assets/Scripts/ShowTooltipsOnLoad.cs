using System;
using System.Threading.Tasks;
using UnityEngine;

public class ShowTooltipsOnLoad : MonoBehaviour
{
    public GameObject[] tooltips;
    public float startTimeSeconds = 2f;
    public float visibleTimeSeconds = 3f;
    public float waitTimeSeconds = 5f;
    
    async void Start()
    {
        int startTime = Convert.ToInt32(startTimeSeconds * 1000);
        int visibleTime = Convert.ToInt32(visibleTimeSeconds * 1000);
        int waitTime = Convert.ToInt32(waitTimeSeconds * 1000);

        await Task.Delay(startTime);
        foreach (GameObject text in tooltips)
        {
            text.SetActive(true);
            await Task.Delay(visibleTime);
            text.SetActive(false);
            await Task.Delay(waitTime);
        }
    }
}
