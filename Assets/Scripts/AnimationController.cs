using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    FireCharacter character;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<FireCharacter>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isJumping", character.GetIsJumping());

        animator.SetBool("isRunning", character.GetIsRunning());

        animator.SetBool("isPushing", character.GetIsPushing());
    }
}
