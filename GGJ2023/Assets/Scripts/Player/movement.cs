using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float friction = 0.95f;
    public Rigidbody2D rb;
    public Animator animator;

    private bool canMove = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void FixedUpdate()
    {
        animator.SetFloat("speed", rb.velocity.magnitude);

        if (!canMove)
            return;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(x, y) * speed;

        rb.velocity = move;
        
        if(x > 0)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 1);
        }
        if (x < 0)
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 1);
        }
    }

    public void Flip(bool flip)
    {
        if (flip)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 1);
        }
        if (!flip)
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 1);
        }
    }

    public void DisableMovement() { canMove = false; rb.velocity = Vector3.zero; }
    public void EnableMovement() { canMove = true; }
}
