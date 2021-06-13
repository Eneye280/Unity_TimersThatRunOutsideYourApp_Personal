using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timerStart;
    public float timer;

    [SerializeField] TextMeshProUGUI tmpTimer;

    private void Start()
    {
        timer -= TimerMaster.instance.CheckDate();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        tmpTimer.text = timer.ToString();

        if(timer <= 0)
        {
            timer = 0;
            tmpTimer.text = "Rewards : " + timer.ToString();
        }
    }

    public void SaveTimer()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        TimerMaster.instance.SaveDate();
        timer = timerStart;
        timer -= TimerMaster.instance.CheckDate();
    }

    public void CheckTimer()
    {
        print(60 - TimerMaster.instance.CheckDate() + " in real seconds has passed");
    }
}
