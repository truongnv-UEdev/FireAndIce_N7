using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class HayBale_Burn : MonoBehaviour
{
    // Start is called before the first frame update
    bool isDestroy;
    bool isDoOnce;
    public ParticleSystem fire, spark, glow;
    AudioSource fireSound;
    void Start()
    {
        isDestroy = false;
        isDoOnce = true;
        fireSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "FireCharacter")
        {
            if (isDoOnce)
            {
                fireSound.Play();
                isDoOnce = false;
            }
            fire.Play();
            spark.Play();
            glow.Play();
            Thread destroy = new Thread(() =>
            {
                SetIsDestroy();
            });
            destroy.Start();
        }
    }

    void SetIsDestroy()
    {
        Thread.Sleep(2000);
        isDestroy = true;
    }
}
