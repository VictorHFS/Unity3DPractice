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
    private float jumpTime = 1;
    private float curJumpTime = 0;

    void Update()
    {
        inputCheck();
    }

    void FixedUpdate()
    {
        if (holdJump && jumpTime > curJumpTime)
        {
            curJumpTime += Time.deltaTime * jumpTime;
            //rb.velocity += Vector3.up;
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

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            OnMoving.Invoke();
        } else
        {
            OnStop.Invoke();
        }
    }
}
