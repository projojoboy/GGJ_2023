using UnityEngine;

public class TurretController : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField]
    private GameObject bullet = null;
    [SerializeField]
    private int bulletSpeed = 1;

    [Header("Turret Settings")]
    [SerializeField]
    private int attackRange = 0;
    [SerializeField]
    private float fireRate = 1;
    [SerializeField]
    private float spread = .2f;
    [SerializeField]
    private Transform shootPoint = null;
    [SerializeField]
    private LayerMask mask = new LayerMask();

    private GameObject closestEnemy = null;

    private float timeToFire = 0;

    void Update()
    {
        FindClosestEnemy();
        Attack();
    }

    private void Attack()
    {
        if (closestEnemy == null)
            return;

        if (Time.time < timeToFire)
            return;

        var dir = closestEnemy.transform.position - shootPoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bul = Instantiate(bullet, shootPoint.position, Quaternion.AngleAxis(angle + Random.Range(-spread, spread), Vector3.forward));
        bul.GetComponent<Rigidbody>().velocity = bul.transform.right * bulletSpeed;

        timeToFire = Time.time + 1 / fireRate;
    }

    private void FindClosestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, mask);

        if (enemies.Length <= 0)
        {
            closestEnemy = null;
            return;
        }

        float enemyRange = 999;

        foreach (var e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);

            if (dist < enemyRange)
            {
                enemyRange = dist;
                closestEnemy = e.gameObject;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
