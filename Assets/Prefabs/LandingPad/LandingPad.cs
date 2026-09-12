using UnityEngine;

public class LandingPad : MonoBehaviour
{
    [SerializeField] private int multiplier = 1;
    [SerializeField] private Timer landingTimer;
    [Range(0f, 180f)]
    [SerializeField] private float maxlandingAngleDegrees;
    public float MaxLandingAngleDegrees => maxlandingAngleDegrees;
    public Timer LandingTimer => landingTimer;
    public int Multiplier => multiplier;
}
