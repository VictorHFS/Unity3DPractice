using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeParticleController : MonoBehaviour
{
    public ParticleSystem SmokeParticle;
    public ParticleSystem ExplosionParticle;
    public HealthBarController HealthBar;
    public DeathController Death;
    private bool checkDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.OnHealthChange += Check;
    }


    private void Update()
    {
        if (checkDeath && this.ExplosionParticle.isStopped)
        {
            Death.OnDeath();
        }
    }

    void Check(float health)
    {
        CheckExplosionPlay(health);
        CheckSmokePlay(health);
    }
    private void CheckExplosionPlay(float health)
    {
        Debug.Log("health -> " + health);
        Debug.Log("ExplosionParticle.isPlaying -> " + ExplosionParticle.isPlaying);
        if (health <= 0 && !ExplosionParticle.isPlaying)
        {
            SmokeParticle.Stop();
            ExplosionParticle.Play();
            checkDeath = true;
        }
    }

    private void CheckSmokePlay(float health)
    {
        float halvedHealth = HealthBar.MaxHealth / 2;
        if (health > 0 && halvedHealth > health && !SmokeParticle.isPlaying)
        {
            SmokeParticle.Play();
        }
    }
}
