using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeOut = 1f;
    public float TimeOut => timeOut;
    private float timeLeft = 0f;
    bool isRunning = false;

    public event Action OnTimeOut;
    public void StartTimer()
    {
        isRunning = true;
    }

    public void Stop()
    {
        timeLeft = 0f;
        isRunning = false;
    }

    public void Reset()
    {
        timeLeft = timeOut;
        isRunning = false;
    }

    void Update()
    {
        if(!isRunning) return;
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            Stop();
            OnTimeOut?.Invoke();
        }
    }
}
