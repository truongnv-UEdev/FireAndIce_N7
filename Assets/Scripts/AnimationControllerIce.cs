using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerIce : MonoBehaviour
{
    Animator animator;
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isJumping", character.GetIsJumping());

        animator.SetBool("isRunning", character.GetIsRunning());

        animator.SetBool("isPushing", character.GetIsPushing());

        animator.SetBool("isAlive", character.GetIsAlive());
    }
}
