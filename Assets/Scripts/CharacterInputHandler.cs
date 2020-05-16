using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    public event System.Action OnGroundTouch;
    public event System.Action OnJump;
    public event System.Action OnAttack;
    public event System.Action OnMoving;
    public event System.Action OnStop;

    public List<Collider> feetColliders;

    private bool holdJump = false;
    private bool touchedGround = false;
    private float jumpForce = 0.5f;
    private float jumpTime = 0.5f;
    private float curJumpTime = 0;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        inputCheck();
    }

    void FixedUpdate()
    {
        if (holdJump && jumpTime > curJumpTime)
        {
            touchedGround = false;
            curJumpTime += Time.deltaTime;
            rb.velocity += Vector3.up * jumpForce;
        } else if(touchedGround)
        {
            curJumpTime = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (Collider collider in feetColliders)
        {
            if (collision.collider.bounds.Intersects(collider.bounds))
            {
                touchedGround = true;
                OnGroundTouch.Invoke();
                return;
            }
        }
    }

    private void inputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchedGround)
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

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            OnMoving.Invoke();
        } else
        {
            OnStop.Invoke();
        }
    }
}
