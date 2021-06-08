using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAnimationManager : MonoBehaviour
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
        if (character.GetIsJumping())
        {
            animator.SetBool("isJumping", true);
        } else animator.SetBool("isJumping", false);

        if (character.GetIsRunning())
        {
            animator.SetBool("isRunning", true);
        }
        else animator.SetBool("isRunning", false);
    }
}
