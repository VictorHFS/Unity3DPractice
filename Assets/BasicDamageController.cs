using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamageController : MonoBehaviour
{
    public List<Collider> Colliders;
    public float Damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        HealthBarController health = other.gameObject.GetComponent<HealthBarController>();

        Debug.Log("health -> " + health);
        if (health)
        {
            Debug.Log("health -> " + health);
            foreach (Collider collider in Colliders)
            {
                if (collider.bounds.Intersects(other.bounds))
                {
                    Debug.Log("applyDamage");
                    health.applyDamage(Damage);
                }
            }
        }
    }
}
