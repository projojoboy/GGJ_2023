using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ondeath : MonoBehaviour
{
    public GameObject deathscreen;
    void Start()
    {
        deathscreen.SetActive(false);
    }
    void DeathScreen()
    {
        deathscreen.SetActive(true);
    }
}
