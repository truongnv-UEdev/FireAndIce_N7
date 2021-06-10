using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameMode manager;
    Animator animator;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.getNumberKeys() >= manager.numberOfKey)
        {
            isOpen = true;   
        }

        animator.SetBool("isOpen", isOpen);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "FireCharacter" || collision.transform.tag == "IceCharacter")
        {
            if (isOpen)
            {
                manager.setIsEndGame(true);
            }  
        }
    }
}
