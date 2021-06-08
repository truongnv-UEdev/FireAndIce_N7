using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCharacter : MonoBehaviour
{
    bool isJump = false;
    private float jumpForce = 7.0f;
    private float speed = 4.0f;
    bool isJumping = false;
    public GameObject spawnPosition;
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
    }

    void FixedUpdate()
    {
        Movement();
        if (isJump) Jump();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            this.transform.position = spawnPosition.transform.position;
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
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void SetIsJumping(bool IsJumping)
    {
        isJumping = IsJumping;
    }
}
