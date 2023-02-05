using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    public GameObject punchpreFab;

    public Transform player;
    [SerializeField]
    private GameObject hammer = null;

    private movement move = null;

    private void Awake()
    {
        move = GetComponent<movement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hammer.SetActive(true);
            move.DisableMovement();

            var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            GameObject punch = Instantiate(punchpreFab, player.position, Quaternion.AngleAxis(angle, Vector3.forward));
            punch.transform.position += punch.transform.right * .7f;
            punch.transform.parent = this.transform;
            this.enabled = false;
        }
    }
}
