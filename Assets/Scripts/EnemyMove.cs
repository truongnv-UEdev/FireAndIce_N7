using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rb;
    int h = 1;
    public float speed = 2f;
    public float timeMoveOneSide = 1f;
    float curTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= timeMoveOneSide)
        {
            ChangeDirection();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * h, rb.velocity.y);
    }

    void ChangeDirection()
    {
        h *= -1;
        curTime -= timeMoveOneSide;
        if(h > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else GetComponent<SpriteRenderer>().flipX = false;
    }
}
