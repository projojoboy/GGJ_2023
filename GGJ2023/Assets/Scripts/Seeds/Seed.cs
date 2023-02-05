using UnityEngine;

public class Seed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<TurretPlaceMent>().AddSeeds(1);
            Destroy(gameObject);
        }
    }
}