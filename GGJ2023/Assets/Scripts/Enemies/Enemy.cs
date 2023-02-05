using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public int enemyType = 1;
    public float range;
    public float turretWateringRange;
    public LayerMask turretMask;

    private NavMeshAgent _agent;

    public Transform Target { get => _target; set => _target = value; }
    private Transform _target;

    public void WaterClosestTurret()
    {
        GameObject turret = FindClosestTurret(GameObject.FindGameObjectsWithTag("Turret"));

        if (!turret)
            return;

        if (Vector3.Distance(transform.position, turret.transform.position) > turretWateringRange)
            return;

        TurretExpController turretExpController = turret.GetComponent<TurretExpController>();

        if (!turretExpController)
            return;

        turretExpController.AddExp(1, enemyType);
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        int randomTarget = Random.Range(0, 1);

        SetTarget(randomTarget);

        _agent.SetDestination(_target.position);
    }

    private void Update()
    {
        UpdateWiggleRotation();
        UpdateTurretScan();

        _agent.SetDestination(_target.position);
    }

    private void UpdateWiggleRotation()
    {
        float pingPongValue = Mathf.PingPong(Time.time * 2, 1);
        float rotation = Mathf.Lerp(-0.2f, 0.2f, pingPongValue);
        transform.rotation = Quaternion.Euler(0, 0, rotation * 30f);
    }

    private void UpdateTurretScan()
    {
        Collider2D[] turretColliders = Physics2D.OverlapCircleAll(transform.position, range, turretMask);

        if (turretColliders.Length > 0)
        {
            if (_target.CompareTag("Player"))
                SetTarget(1);
        }
    }

    private void SetTarget(int target)
    {
        switch (target)
        {
            // Player
            case 0:

                _target = GameObject.FindGameObjectWithTag("Player").transform;

                break;
                
            // Closest Turret
            case 1:

                _target = FindClosestTurret(GameObject.FindGameObjectsWithTag("Turret")).transform;

                if (!_target)
                    SetTarget(1);

                break;
        }
    }

    private GameObject FindClosestTurret(GameObject[] turrets)
    {
        GameObject closestTurret = null;

        if (turrets.Length <= 0)
            return null;

        float range = 999;

        foreach (GameObject turret in turrets)
        {
            float distance = Vector2.Distance(transform.position, turret.transform.position);

            if (distance < range)
            {
                range = distance;
                closestTurret = turret;
            }
        }

        return closestTurret;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, turretWateringRange);
    }
}
