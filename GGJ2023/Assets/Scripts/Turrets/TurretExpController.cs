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
    private SpriteRenderer enemySpriteRenderer;

    [SerializeField]
    private Sprite enemy1Sprite;

    [SerializeField]
    private Sprite enemy2Sprite;

    [SerializeField]
    private SpriteRenderer upgradePlantSpriteRenderer;

    [SerializeField]
    private Sprite upgradePlant1Sprite;

    [SerializeField]
    private Sprite upgradePlant2Sprite;

    [SerializeField]
    private GameObject turUpgrade1 = null;
    [SerializeField]
    private GameObject turUpgrade2 = null;

    public void AddExp(int exp, int enemy)
    {
        if (enemy == 1)
            expEn1 += exp;
        else
            expEn2 += exp;

        // Update sprites
        enemySpriteRenderer.sprite = (expEn1 > expEn2) ? enemy1Sprite : enemy2Sprite;

        upgradePlantSpriteRenderer.sprite = (expEn1 > expEn2) ? upgradePlant1Sprite : upgradePlant2Sprite;

        expCur = expEn1 + expEn2;

        UpdateUI();

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
