using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyPunch : MonoBehaviour
{
    public float range;
    public float punchDelayTime = 1;
    public GameObject punchPrefab;

    private Enemy _enemy;

    private float _punchDelayTimer;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _punchDelayTimer = punchDelayTime;
    }

    private void Update()
    {
        if (!_enemy.Target)
            return;

        if (_punchDelayTimer > 0)
            _punchDelayTimer -= Time.deltaTime;
        else
        {
            InstantiateMeleeAttack();

            _punchDelayTimer = punchDelayTime;
        }
    }

    private void InstantiateMeleeAttack()
    {
        if (Vector3.Distance(transform.position, _enemy.Target.position) > range)
            return;

        Vector3 direction = _enemy.Target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject punchObject = Instantiate(punchPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward), transform);
        punchObject.transform.position += punchObject.transform.right * 1.2f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
