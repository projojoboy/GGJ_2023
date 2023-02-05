using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlaceMent : MonoBehaviour
{
    public GameObject turretprefab;

    public Transform player;

    public GameObject water;

    public float plantTime = 1f;

    public float seedsAmount = 2f;
    public void Update()
    {

        if (seedsAmount > 0)
        {

            if (Input.GetKey(KeyCode.E))
            {
                water.SetActive(true);
                if (plantTime < 0)
                {
                    plantTime = 1;
                    var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                    GameObject punch = Instantiate(turretprefab, player.position, Quaternion.AngleAxis(angle, Vector3.forward));
                    punch.transform.position += punch.transform.right * 1f;
                    seedsAmount -= 1;
                    water.SetActive(false);
                }
                plantTime -= Time.deltaTime;
            }
        }

    }
}
