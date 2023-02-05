using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float friction = 0.95f;
    public Rigidbody2D rb;
    public Animator animator;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y= Input.GetAxis("Vertical");
        
        
        Vector2 move = new Vector2(x, y) * speed;

        rb.velocity = move;
        animator.SetFloat("speed", Mathf.Abs(x+y));
        if(x > 0)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 1);
        }
        if (x < 0)
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 1);
        }
    }
}
