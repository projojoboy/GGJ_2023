using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 3;

    [SerializeField]
    private UnityEvent OnDeath = new UnityEvent();

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
            Dead();
    }

    public void HealHealth(int hp)
    {
        health += hp;
    }

    private void Dead()
    {
        OnDeath?.Invoke();
    }
}
