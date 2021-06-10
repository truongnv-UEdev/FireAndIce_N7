using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class FireCharacter : MonoBehaviour
{
    bool isAlive = true;
    bool isJump = false;
    bool isPushing = false;
    bool isRespawn = true;
    private float jumpForce = 7.0f;
    private float speed = 4.0f;
    bool isJumping = false;
    public GameObject spawnPosition;
    public AudioSource jumpSound, deadSound;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("JumpFire") && !isJumping)
        {
            isJump = true;
            
        }
        if (isRespawn)
        {
            Respawn();
        }

    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            Movement();
            if (isJump) Jump();
        } else rb.velocity = Vector3.zero;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            if (isAlive)
            {
                OnDeath();
            }  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            if (isAlive)
            {
                OnDeath();
            }
        }
    }

    void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("HorizontalFire") * speed, rb.velocity.y, 0f);
        rb.velocity = move;

        if (Input.GetAxis("HorizontalFire") < -0.0001f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis("HorizontalFire") > 0.0001f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Jump()
    {
        isJump = false;
        isJumping = true;
        jumpSound.Play();
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void SetIsJumping(bool IsJumping)
    {
        isJumping = IsJumping;
    }

    public bool GetIsJumping()
    {
        return isJumping;
    }

    public bool GetIsRunning()
    {
        return Mathf.Abs(rb.velocity.x) > 1;
    }

    public void SetIsPushing(bool IsPushing)
    {
        isPushing = IsPushing;
    }
    public bool GetIsPushing()
    {
        return isPushing;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }

    void OnDeath()
    {
        deadSound.Play();
        isAlive = false;

        Thread respawn = new Thread(() =>
        {
            WaitToRespawn();
        });
        respawn.Start();
    }

    void WaitToRespawn()
    {
        Thread.Sleep(2000);
        isRespawn = true;
    }

    void Respawn()
    {
        isRespawn = false;
        this.transform.position = spawnPosition.transform.position;
        isAlive = true;
    }
}
