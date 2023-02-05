using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    public GameObject punchpreFab;

    public Transform player;
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            GameObject punch = Instantiate(punchpreFab, player.position, Quaternion.AngleAxis(angle, Vector3.forward));
            punch.transform.position += punch.transform.right * 1.2f;
            punch.transform.parent = this.transform;
        }
    }
}
