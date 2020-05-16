using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteWarriorAnimationController : MonoBehaviour
{

    public CharacterInputHandler move;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        move.OnGroundTouch += this.OnGroundTouch;
        move.OnJump += this.OnJump;
        move.OnAttack += this.OnAttack;
        move.OnMoving += this.OnMoving;
        move.OnStop += this.OnStop;
    }

    void OnMoving()
    {
        animator.SetBool("Moving", true);
    }

    void OnStop()
    {
        animator.SetBool("Moving", false);
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
        animator.SetTrigger("Jump");
        animator.SetBool("OnAir", true);
    }
}
