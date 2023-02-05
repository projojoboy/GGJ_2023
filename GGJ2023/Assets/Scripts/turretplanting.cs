using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlaceMent : MonoBehaviour
{
    public GameObject turretprefab;

    public GameObject water;

    public float plantTime = 1f;

    public int seedsAmount = 50;

    private int turretCost = 50;

    private bool canPlant = true;

    public void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (seedsAmount < turretCost || !canPlant)
                return;

            canPlant = false;

            StartCoroutine(PlantSeed());
        }
    }

    private IEnumerator PlantSeed()
    {
        water.SetActive(true);

        // Disable player movement

        yield return new WaitForSeconds(plantTime);

        Instantiate(turretprefab, transform.position + transform.right, Quaternion.identity);

        seedsAmount -= turretCost;
        
        water.SetActive(false);
        canPlant = true;
    }
}
