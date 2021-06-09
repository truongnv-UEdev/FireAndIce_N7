using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Key : MonoBehaviour
{
    public GameMode manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "FireCharacter" || collision.transform.tag == "IceCharacter")
        {
            manager.setNumKey();
            Destroy(this.gameObject);
        }
    }
}
