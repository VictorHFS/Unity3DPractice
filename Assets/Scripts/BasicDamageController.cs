using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamageController : MonoBehaviour
{
    public List<Collider> Colliders;
    public float Damage = 1;
    public float DamageTimeGap = 1;
    public CharacterInputHandler inputHandler;
    public event System.Action OnDamage;

    private float runningTime = 0;
    private bool isAttacking = false;
    void Start()
    {
        inputHandler.OnAttack += this.OnAttack;
    }

    void Update()
    {
        if (isAttacking)
        {
            runningTime += Time.deltaTime;
        }

        if (runningTime > DamageTimeGap) // timeout
        {
            this.isAttacking = false;
            runningTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isAttacking)
        {
            return;
        }

        HealthBarController health = other.gameObject.GetComponent<HealthBarController>();

        if (!health)
        {
            return;
        }

        foreach (Collider collider in Colliders)
        {
            if (collider.bounds.Intersects(other.bounds))
            {
                this.isAttacking = false;
                runningTime = 0;
                health.applyDamage(Damage);
                this.OnDamage.Invoke();
            }
        }
    }

    private void OnAttack() {
        this.isAttacking = true;
    }
}
