using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private GameObject thrustParticlesNode;
    private ParticleSystem[] thrustParticles;

    
    private void Awake()
    {
        thrustParticles = thrustParticlesNode.GetComponentsInChildren<ParticleSystem>();
    }

    public void PlayAllThrustParticles(bool setActive)
    {
        for(int i = 0; i < thrustParticles.Length; i++)
        {
            PlayThrustParticles(i, setActive);
        }
    }

    private void PlayThrustParticles(int particleIndex,bool setActive)
    {
        if(setActive) thrustParticles[particleIndex].Play();
        else thrustParticles[particleIndex].Stop();
    }

}
