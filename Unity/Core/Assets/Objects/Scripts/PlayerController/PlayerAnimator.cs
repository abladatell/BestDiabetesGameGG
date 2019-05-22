using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    AnimatorOverrideController overrideController;

    //Controls animations.
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack()
    {
        animator.SetTrigger("attack");
    }
}
