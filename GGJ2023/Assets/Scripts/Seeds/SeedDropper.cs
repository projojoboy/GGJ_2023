using UnityEngine;

public class SeedDropper : MonoBehaviour
{
    public int minAmount = 2;
    public int maxAmount = 4;
    public float minSpeed = 0.3f;
    public float maxSpeed = 2;

    public GameObject seedPrefab;

    public void DropSeeds()
    {
        int seedAmount = Random.Range(minAmount, maxAmount + 1);

        for (int i = 0; i < seedAmount; i++)
        {
            Vector2 force = new(Random.Range(-1, 2), Random.Range(-1, 2));
            force.Normalize();

            float speed = Random.Range(minSpeed, maxSpeed);

            GameObject seedObject = Instantiate(seedPrefab, transform.position, Quaternion.identity);
            seedObject.GetComponent<Rigidbody2D>().AddForce(force * speed, ForceMode2D.Impulse);
        }
    }
}