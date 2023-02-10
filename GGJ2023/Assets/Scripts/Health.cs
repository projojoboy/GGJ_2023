using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;
    [SerializeField]
    private int curHealth = 0;
    [SerializeField]
    private bool destroyOnDeath = false;

    [SerializeField]
    private Image healthbar = null;

    public UnityEvent OnDeath = new UnityEvent();

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        curHealth -= dmg;
        UpdateUI();

        if (curHealth <= 0)
            Dead();
    }

    private void UpdateUI()
    {
        healthbar.fillAmount = 1f / (float)maxHealth * (float)curHealth;
    }

    public void HealHealth(int hp)
    {
        if (curHealth >= maxHealth)
            return; 

        curHealth += hp;
        UpdateUI();
    }

    private void Dead()
    {
        OnDeath?.Invoke();

        if (destroyOnDeath)
            Destroy(gameObject);
    }
}
