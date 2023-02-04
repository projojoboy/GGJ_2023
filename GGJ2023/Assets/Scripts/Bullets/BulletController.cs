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
}
