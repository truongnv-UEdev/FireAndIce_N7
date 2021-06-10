using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class Water_Ice : MonoBehaviour
{
    // Start is called before the first frame update
    bool isFreeze;
    bool isVaporize;
    bool isIceStanding;
    AudioSource freezing;
   
    void Start()
    {
        isFreeze = false;
        isVaporize = false;
        isIceStanding = false;
        freezing = GetComponent<AudioSource>();
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVaporize)
        {
            isVaporize = false;
            if (isFreeze && !isIceStanding)
            {
                vaporizeObject();
            }
        } 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "FireCharacter")
        {
            if (isFreeze && !isIceStanding)
            {
                Thread Vaporize = new Thread(() =>
                {
                    timeVaporize();
                });
                Vaporize.Start();
            }
        }
        if (collision.transform.tag == "IceCharacter")
        {
            isFreeze = true;
            isIceStanding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "IceCharacter")
        {
            isIceStanding = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "IceCharacter")
        {
            if (!isFreeze)
            {
                freezeObject();
            }
        }
    }

    void freezeObject()
    {
        freezing.Play();
        
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        isFreeze = true;
        transform.tag = "Ground";
    }

    void vaporizeObject()
    {
        
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        isFreeze = false;
        transform.tag = "Water";
    }

    void timeVaporize()
    {
        Thread.Sleep(1000);
        isVaporize = true;   
    }

    public bool GetIsFreezed()
    {
        return isFreeze;
    }
}
