using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 3;

    private void Update()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
