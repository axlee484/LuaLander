using UnityEngine;

public class LandingController : MonoBehaviour
{

    [SerializeField] private Timer landingTimer;
    [Range(0f, 180f)]
    [SerializeField] private float maxlandingAngleDegrees = 5f;
    private Health health;

    void Start()
    {
        landingTimer.OnTimeOut += OnLandingTimeOut;
        health = GetComponent<Health>();
    }

    void OnLandingTimeOut()
    {
        print("Landed");
    }

    private bool IsWithinLandingAngle(Collision2D collision)
    {
        var landingAngleDot = Vector2.Dot(collision.collider.transform.up, transform.up);
        var minLandingDot = Mathf.Cos(Mathf.Deg2Rad*maxlandingAngleDegrees);
        return landingAngleDot > minLandingDot;
    }

    private void HandleLanding(Collision2D collision)
    {
        if(health.CurrentHealth <= 0) return;
        if(!IsWithinLandingAngle(collision)) return;

        landingTimer.StartTimer();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<LandingPad>(out var _))
        {
            HandleLanding(collision);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(!collision.gameObject.TryGetComponent<LandingPad>(out var _)) return;
        
        if(!IsWithinLandingAngle(collision)) {
            landingTimer.ResetTimer();
            return;
        }
        if(landingTimer.enabled) return;
        HandleLanding(collision);
        
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<LandingPad>(out var landingPad))
        {
            landingTimer.ResetTimer();
        }
    }
    
}
