using System;
using UnityEngine;

public class Timer: MonoBehaviour
{
    [SerializeField] private float timeOut = 1f;
    [SerializeField] private bool isFixedTimeScale = false;
    public float TimeOut  {get => timeOut; set=>  timeOut = value;}
    private float timeLeft = 0f;

    public event Action OnTimeOut;
    private void Start()
    {
        enabled = false;
    }
    public void StartTimer()
    {
        
        enabled = true;
        timeLeft = timeOut;
    }

    public void ResetTimer()
    {
        enabled = false;
        timeLeft = timeOut;
    }

    private void StopTimer()
    {
        timeLeft = 0f;
        OnTimeOut?.Invoke();
        enabled = false;
    }


    private void Tick()
    {
        if(timeLeft <= 0) StopTimer();
        timeLeft -= Time.deltaTime;
    }

    void Update()
    {
        if(isFixedTimeScale) return;
        Tick();
        
    }

    void FixedUpdate()
    {
        if(!isFixedTimeScale) return;
        Tick();
    }
}
