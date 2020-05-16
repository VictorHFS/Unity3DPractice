using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image Background;
    public Image Foreground;
    public float MaxHealth;
    private float currentHealth;
    private float maxHealthScale;

    void Start()
    {
        maxHealthScale = Foreground.transform.localScale.x;
    }

    public void applyDamage(float damage)
    {
        float scaledDamage = (damage * maxHealthScale) / MaxHealth;
        Foreground.transform.localScale = new Vector3(
            Mathf.Clamp(Foreground.transform.localScale.x - scaledDamage, 0, MaxHealth),
            Foreground.transform.localScale.y,
            Foreground.transform.localScale.z);
    }
}
