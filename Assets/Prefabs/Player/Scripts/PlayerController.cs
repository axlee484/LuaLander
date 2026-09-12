using System.Collections;
using System.Reflection.Metadata;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RigidBodyMovement movement;
    [SerializeField] private Health health;
    [SerializeField] private HurtBox hurtBox;
    [SerializeField] private HitBox hitBox;
    [SerializeField] private float maxSafeImpactSpeed = 10f;
    [SerializeField] private float damagePerImpactSpeed = 10f;
    [SerializeField] private AudioClip collideSound;
    [SerializeField] private AudioSource audioSource;
    private AudioManager audioManager;

    private float collisionImpact;
    public float CollisionImpact => collisionImpact;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private float GetCollisionImpact(Collision2D collision)
    {
        // print("Collision impact: "+collision.relativeVelocity.magnitude);
        if(collision.relativeVelocity.magnitude <= maxSafeImpactSpeed) return 0;
        var excessSpeed = collision.relativeVelocity.magnitude - maxSafeImpactSpeed;
        audioManager.PlaySfx(collideSound);
        collisionImpact = excessSpeed;
        return excessSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var impact = GetCollisionImpact(collision);
        health.TakeDamage(damagePerImpactSpeed*impact);
    }
    void Debug()
    {
        var debugNode = transform.Find("Debug/Text").gameObject.GetComponent<TextMeshPro>();
        debugNode.text = $"State: {GetComponent<PlayerStateMachine>().CurrentState.Id}";
    }


    void Update()
    {
        Debug();
    }
}
