using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsVelocity : MonoBehaviour
{
    public float Velocity = 1;
    public Rigidbody rb;

    private Quaternion eulerOffset;

    private void Start()
    {
        eulerOffset = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Update()
    {
        Vector3 direcao = rb.velocity.normalized;
        if (direcao != Vector3.zero && transform.forward != direcao)
        {
            Quaternion rotation = Quaternion.LookRotation(direcao) * eulerOffset;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Velocity * Time.deltaTime);
        }
    }
}
