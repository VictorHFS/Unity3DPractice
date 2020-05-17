using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image Background;
    public Image Foreground;
    public float MaxHealth;
    public event System.Action OnDeath;
    private float currentHealth;
    private float maxHealthScale;

    void Start()
    {
        maxHealthScale = Foreground.transform.localScale.x;
        currentHealth = MaxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }

    public void applyDamage(float damage)
    {
        this.currentHealth -= damage;
        float scaledDamage = (damage * maxHealthScale) / MaxHealth;
        Foreground.transform.localScale = new Vector3(
            Mathf.Clamp(Foreground.transform.localScale.x - scaledDamage, 0, MaxHealth),
            Foreground.transform.localScale.y,
            Foreground.transform.localScale.z);
    }
}
