using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private GameObject thrustParticlesNode;
    [SerializeField] private Timer thurstTimer;

    private PlayerController playerController;
    private List<ParticleSystem.EmissionModule> thrustParticles = new();
    private RigidBodyMovement movement;

    
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        movement = GetComponent<RigidBodyMovement>();

        var thrustParticlesComps = thrustParticlesNode.GetComponentsInChildren<ParticleSystem>();
        foreach(var thrustParticlesComp in thrustParticlesComps)
        {
            ParticleSystem.EmissionModule emissionModule = thrustParticlesComp.emission;
            thrustParticles.Add(emissionModule);
        }
    }
    private void Start()
    {
        SetAllThrustParticlesActive(false);
    }
    private void SetAllThrustParticlesActive(bool setActive)
    {
        if(setActive == false && thurstTimer.enabled) return;

        for(int i = 0; i < thrustParticles.Count; i++)
        {
            SetThrustParticlesActive(i, setActive);
        }
    }

    private void SetThrustParticlesActive(int particleIndex,bool setActive)
    {
        var emission = thrustParticles[particleIndex];
        emission.enabled = setActive;
    }

    private void PlayThrustParticles()
    {
        if(!movement.IsControlEnabled)
        {
            thurstTimer.ResetTimer();
            SetAllThrustParticlesActive(false); 
            return;
        }
        if (movement.IsForceApplied || movement.IsRotationApplied) 
        {
            SetAllThrustParticlesActive(true);
            thurstTimer.StartTimer();
            return;
        }
        else
        {
            SetAllThrustParticlesActive(false);
        }
    }

    private void Update()
    {
        PlayThrustParticles();
    }
}
