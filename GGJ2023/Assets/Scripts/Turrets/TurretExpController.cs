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

    [SerializeField]
    private Image expBar = null;

    private void AddExp(int exp)
    {
        expCur += exp;
        UpdateUI();

        if(expCur >= expReq) 
        { 
            // On Level Up
        }
    }

    private void UpdateUI()
    {
        expBar.fillAmount = (float)(1f / expReq * expCur);
    }
}
