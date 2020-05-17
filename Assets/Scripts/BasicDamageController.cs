using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamageController : MonoBehaviour
{
    public List<Collider> Colliders;
    public float Damage = 1;
    public float DamageTimeGap = 1;
    public float PushForce = 1;
    public CharacterInputHandler inputHandler;
    public event System.Action OnDamage;

    private Rigidbody targetBody;
    private Vector3 forceToBeApplied = Vector3.zero;
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

    void FixedUpdate()
    {
        if (forceToBeApplied != Vector3.zero && targetBody)
        {
            Debug.Log("targetBody -> " + targetBody);
            Debug.Log("forceToBeApplied -> "+ forceToBeApplied);
            targetBody.AddForce(forceToBeApplied);
            targetBody = null;
            forceToBeApplied = Vector3.zero;
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
                Vector3 damageDirection = (other.gameObject.transform.position - collider.gameObject.transform.position).normalized;
                forceToBeApplied = replaceY(damageDirection * PushForce, PushForce);
                targetBody = other.gameObject.GetComponent<Rigidbody>();
                OnDamage.Invoke();
            }
        }
    }

    private Vector3 removeY(Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }

    private Vector3 replaceY(Vector3 vector, float y)
    {
        return new Vector3(vector.x, y, vector.z);
    }

    private void OnAttack() {
        this.isAttacking = true;
    }
}
