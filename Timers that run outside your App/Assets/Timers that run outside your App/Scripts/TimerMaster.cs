using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMaster : MonoBehaviour
{
    public static TimerMaster instance;

    DateTime currentData;
    DateTime oldData;

    public string saveLocation;

    private void Awake()
    {
        instance = this;

        saveLocation = "lastSaveDatei";

    }

    public float CheckDate()
    {
        currentData = System.DateTime.Now;
        string tempString = PlayerPrefs.GetString(saveLocation, "1");

        long tempLong = Convert.ToInt64(tempString);
        DateTime oldDate = DateTime.FromBinary(tempLong);
        print("Old Date : " + oldDate);

        TimeSpan difference = currentData.Subtract(oldDate);
        print("Difference: " + difference);

        return (float)difference.TotalSeconds;

    }

    public void SaveDate()
    {
        PlayerPrefs.SetString(saveLocation,System.DateTime.Now.ToBinary().ToString());
        print("Saving this date to player prefs: " + System.DateTime.Now);
    }
}
