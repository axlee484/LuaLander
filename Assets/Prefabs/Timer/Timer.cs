using System;
using UnityEngine;

public class Timer: MonoBehaviour
{
    [SerializeField] private float countDown = 1f;
    [SerializeField] private bool isFixedTimeScale = false;
    public float CountDown  {get => countDown; set=>  countDown = value;}
    private float timeLeft = 0f;

    public event Action TimeOut;
    private void Awake()
    {
        enabled = false;
    }
    public void StartTimer()
    {
        
        enabled = true;
        timeLeft = countDown;
    }

    public void ResetTimer()
    {
        enabled = false;
        timeLeft = countDown;
    }

    private void StopTimer()
    {
        timeLeft = 0f;
        TimeOut?.Invoke();
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
