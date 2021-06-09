using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnGroundFire : MonoBehaviour
{
    FireCharacter character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<FireCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Object")
        {
            character.SetIsJumping(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            character.SetIsPushing(true);
        }
        
    }
}
