using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public HealthBarController health;

    void Start()
    {
        //health.OnDeath += this.OnDeath;
    }

    public void OnDeath()
    {
        this.gameObject.SetActive(false);
    }
}
