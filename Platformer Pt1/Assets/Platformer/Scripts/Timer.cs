using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI time;
    public GameObject player;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        time.text = $"Time\n {Mathf.Floor(100 - Time.realtimeSinceStartup)}";
        if(Time.realtimeSinceStartup >= 100)
        {
            player.SetActive(false);
            Debug.Log("Out of time!");
        }
    }
}
