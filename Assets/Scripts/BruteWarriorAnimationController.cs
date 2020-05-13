using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteWarriorAnimationController : MonoBehaviour
{

    public SimpleTransformMove move;

    public Rigidbody rb;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        move.OnGroundTouch += this.OnGroundTouch;
        move.OnJump += this.OnJump;
        move.OnAttack += this.OnAttack;
    }

    void Update()
    {
        bool moving = rb.velocity.magnitude > 0;
        animator.SetBool("Moving", moving);
        animator.SetInteger("Velocity", (int) move.Speed);
    }
     void OnGroundTouch()
    {
        animator.SetBool("OnAir", false);
    }

     void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    void OnJump()
    {
        Debug.Log("Jump");
        animator.SetTrigger("Jump");
        animator.SetBool("OnAir", true);
    }
}
