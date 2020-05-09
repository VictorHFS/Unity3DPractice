using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransformMove : MonoBehaviour
{
    public float Speed = 1;
    private Rigidbody rb;
    private Transform cameraTransform;

    private void Start()
    {
        this.cameraTransform = Camera.main.transform;
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        rb.velocity = cameraTransform.forward * y * Speed;
    }
}
