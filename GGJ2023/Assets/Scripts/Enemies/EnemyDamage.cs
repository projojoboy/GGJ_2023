using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
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
        if(collision.CompareTag("Player") || collision.CompareTag("Turret"))
        {
            collision.GetComponent<Health>().TakeDamage(1);

            Collider2D collider = GetComponent<Collider2D>();

            if (collider)
                collider.enabled = false;
        }
    }
}
