using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    public float attackTimer = 1f;

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
            collision.GetComponent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
