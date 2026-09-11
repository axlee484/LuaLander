using UnityEngine;

public class TimerProgressBar : ProgressBar
{
    [SerializeField] private Timer timer;
    public override float MaxValue => timer.CountDown;
    public override float Value => timer.CountDown - timer.TimeLeft;
}
