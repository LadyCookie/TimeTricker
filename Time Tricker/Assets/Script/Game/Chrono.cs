﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class represent a chrono, it display time, given
 * a starting time
 */
public class Chrono : MonoBehaviour
{
    private TMPro.TextMeshProUGUI timerText;

    public void Start()
    {
        timerText = GetComponent<TMPro.TextMeshProUGUI>();
        if(timerText == null) 
            Debug.LogError("Could not find any TextMeshProUGUI with tag \"Chrono\" in script Chrono.cs");
    }

    //value in seconds
    public void setTimeText(float value)
    {
        System.TimeSpan time = System.TimeSpan.FromSeconds((double) value);
        //string minutes = (value / 60f).ToString("d2");
        //string seconds = (value % 60f).ToString("d2");
        timerText.text = time.ToString("mm':'ss");
    }
}
