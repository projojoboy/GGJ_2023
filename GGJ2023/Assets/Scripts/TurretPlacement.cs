using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacement : MonoBehaviour
{
    public GameObject turretprefab;

    public GameObject water;

    public float plantTime = 1f;

    public int seedsAmount = 40;

    private int turretCost = 50;

    private bool canPlant = true;

    private movement move = null;
    private punch punch = null;

    public Text text;

    private void Awake()
    {
        move = GetComponent<movement>();
        punch = GetComponent<punch>();
    }

    private void Update()
    {
        text.text = seedsAmount.ToString();
        if (Input.GetKey(KeyCode.E))
        {
            if (seedsAmount < turretCost || !canPlant)
                return;

            canPlant = false;

            StartCoroutine(PlantSeed());
        }
    }

    public void AddSeeds(int amount)
    {
        seedsAmount += amount;
    }

    private IEnumerator PlantSeed()
    {
        water.SetActive(true);

        // Disable player movement
        move.DisableMovement();
        punch.enabled = false; 
        yield return new WaitForSeconds(plantTime);

        Vector3 dir = new Vector3(1,-1,0);

        if(transform.localScale.x < 0) { dir.x = -dir.x; }

        Instantiate(turretprefab, transform.position + dir, Quaternion.identity).SetActive(true);

        seedsAmount -= turretCost;
        
        water.SetActive(false);
        move.EnableMovement();
        punch.enabled = true;
        canPlant = true;
    }
}
