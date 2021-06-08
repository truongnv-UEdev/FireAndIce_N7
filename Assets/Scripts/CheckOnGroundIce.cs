using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnGroundIce : MonoBehaviour
{
    IceCharacter character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<IceCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Prop")
        {
            character.SetIsJumping(false);
        }
    }
}
