using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    private float starttime;

    void Start()
    {
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - starttime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString();

        timerText.text = minutes + ":" + seconds;
    }
}
