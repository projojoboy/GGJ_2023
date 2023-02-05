using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private movement move;

    private void Awake()
    {
        move = transform.parent.GetComponent<movement>();
    }

    public void DisableHammer()
    {
        gameObject.SetActive(false); 
        transform.parent.GetComponent<punch>().enabled = true;
        move.EnableMovement();
    }

}
