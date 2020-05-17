using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public HealthBarController health;
    // Start is called before the first frame update
    void Start()
    {
        health.OnDeath += this.OnDeath;
    }

    void OnDeath()
    {
        this.gameObject.SetActive(false);
    }
}
