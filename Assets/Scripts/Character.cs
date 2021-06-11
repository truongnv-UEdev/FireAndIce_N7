using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
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
    string inputHorizontalName;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
    }

    public void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis(inputHorizontalName) * speed, rb.velocity.y, 0f);
        rb.velocity = move;

        if (Input.GetAxis(inputHorizontalName) < -0.0001f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis(inputHorizontalName) > 0.0001f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Jump()
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

    public void SetIsJump(bool IsJump)
    {
        isJump = IsJump;
    }

    public bool GetIsJump()
    {
        return isJump;
    }

    public bool GetIsRunning()
    {
        return Mathf.Abs(this.rb.velocity.x) > 1;
    }

    public void SetIsPushing(bool IsPushing)
    {
        isPushing = IsPushing;
    }
    public bool GetIsPushing()
    {
        return isPushing;
    }

    public void SetIsRespawn(bool IsRespawn)
    {
        isRespawn = IsRespawn;
    }
    public bool GetIsRespawn()
    {
        return isRespawn;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }
    public void SetInputHorizontalName(string InputHorizontalName)
    {
        inputHorizontalName = InputHorizontalName;
    }

    public void SetRigidbody2D(Rigidbody2D Rb)
    {
        rb=Rb;
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rb;
    }

    public void OnDeath()
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

    public void Respawn()
    {
        isRespawn = false;
        this.transform.position = spawnPosition.transform.position;
        isAlive = true;
    }
}
