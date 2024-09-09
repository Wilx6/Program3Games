using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickerText : MonoBehaviour
{

    public Text flickeringText; // Reference to the Text component
    public float flickerSpeed = 1.0f; // Speed of the flicker

    // Start is called before the first frame update
    void Start()
    {
        if (flickeringText == null)
            flickeringText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.PingPong(Time.time * flickerSpeed, 1) > 0.5f)
        {
            flickeringText.color = Color.white;
        }
        else
        {
            flickeringText.color = Color.black;
        }
    }
}
