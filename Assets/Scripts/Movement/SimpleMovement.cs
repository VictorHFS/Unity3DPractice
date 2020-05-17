using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimpleMovement : NetworkBehaviour
{
    public Transform SelfTransform;
    public Rigidbody SelfBody;
    public float Speed;
    void FixedUpdate()
    {
        if (!this.isLocalPlayer) return;
        Vector3 directionalVelocity = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")) * Speed;
        this.SelfBody.velocity = SelfTransform.rotation  * Quaternion.Euler(0,90,0) * directionalVelocity;
    }
}
