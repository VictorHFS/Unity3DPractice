using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    public ParticleSystem Particle;
    public BasicDamageController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller.OnDamage += PlayParticle;
    }

    void PlayParticle()
    {
        if (!Particle.isPlaying)
        {
            Particle.Play();
        }
    }
}
