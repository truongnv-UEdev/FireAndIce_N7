using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Controller : MonoBehaviour
{


    // Start is called before the first frame update

    public Animator animator;
    public Water_Ice wi;
    void Start()
    {
        //animator.GetComponent<Animator>();
        //wi.GetComponent<Water_Ice>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsFreezed", wi.GetIsFreezed());
    }
}
