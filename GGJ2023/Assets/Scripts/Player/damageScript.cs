using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class damageScript : MonoBehaviour
{
    public float attackTimer = 1f;

    public Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if(attackTimer < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(5);
            collision.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 8, ForceMode2D.Impulse);

            Collider2D collider = GetComponent<Collider2D>();

            if (collider)
                collider.enabled = false;
        }
    }
}
