using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretExpController : MonoBehaviour
{
    [SerializeField]
    private int expReq = 20;
    [SerializeField]
    private int expCur = 0;

    private int expEn1 = 0;
    private int expEn2 = 0;

    [SerializeField]
    private Image expBar = null;

    [SerializeField]
    private GameObject turUpgrade1 = null;
    [SerializeField]
    private GameObject turUpgrade2 = null;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            AddExp(1, 1);
        else if(Input.GetKeyDown(KeyCode.O))
            AddExp(1, 2);
    }
    private void AddExp(int exp, int enemy)
    {
        UpdateUI();

        if (enemy == 1)
            expEn1 += exp;
        else
            expEn2 += exp;

        expCur = expEn1 + expEn2;

        if (expCur >= expReq)
        {
            // On Level Up
            if (expEn1 > expEn2)
            {
                Instantiate(turUpgrade1, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(turUpgrade2, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void UpdateUI()
    {
        expBar.fillAmount = (float)(1f / expReq * expCur);
    }
}
