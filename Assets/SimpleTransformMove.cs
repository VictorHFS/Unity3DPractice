using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransformMove : MonoBehaviour
{
    public float MaxSpeed = 20;    
    public float Acceleration = 1;
    public float Deceleration= 1;

    public float Speed = 0;
    public event System.Action OnGroundTouch;
    public event System.Action OnJump;
    public event System.Action OnAttack;

    public List<Collider> feetColliders;

    private float direction = 0;
    private Rigidbody rb;
    private Transform cameraTransform;

    private bool holdJump = false;
    private float jumpTime = 1;
    private float curJumpTime = 0;

    private void Start()
    {
        this.cameraTransform = Camera.main.transform;
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        checkDirection();
        inputCheck();
    }

    void FixedUpdate()
    {
        checkAcceleration();
        if (holdJump && jumpTime > curJumpTime)
        {
            curJumpTime += Time.deltaTime * jumpTime;
            rb.velocity += Vector3.up;
        } else
        {
            curJumpTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach( Collider collider in feetColliders)
        {
            if (other.bounds.Intersects(collider.bounds))
            {
                OnGroundTouch.Invoke();
                return;
            }
        }
    }

    private void inputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdJump = true;
            OnJump.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            holdJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnAttack.Invoke();
        }
    }

    private void checkAcceleration()
    {
        float y = Input.GetAxis("Vertical");
        if (Mathf.Abs(y) > 0)
        {
            Speed += Acceleration * Time.deltaTime;
        }
        else
        {
            Speed -= Deceleration * Time.deltaTime;
        }
        Speed = Mathf.Clamp(Speed, 0, MaxSpeed);

        rb.velocity = cameraTransform.forward * direction * Speed;
    }

    void checkDirection()
    {
        float y = Input.GetAxis("Vertical");
        if (y > 0)
        {
            direction = 1;
        }
        else if (y < 0)
        {
            direction = -1;
        }
    }
}
