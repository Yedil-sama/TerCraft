using System;
using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour, IHealth
{
    public Health health;
    public Armor armor;
    public event Action OnTakeDamage;
    public event Action OnHealUp;
    private void Awake()
    {
        
    }
    private void Update()
    {
        if (health.lastRegenerationTime + health.regenRate <= Time.time)
        {
            health.lastRegenerationTime = Time.time;
            Regenerate();
        }
    }
    public virtual void Regenerate()
    {
        health.current += health.regeneration;
        if (health.current == health.total)
        {
            return;
        }
        if (health.current > health.total)
        {
            health.current = health.total;
            return;
        }
    }
    public virtual float TakeDamage(Damage damage)
    {
        damage.amount -= armor.current;
        if (damage.amount < 0)
        {
            damage.amount = 1;
        }
        health.current -= damage.amount;
        if (health.current <= 0)
        {
            (health.current, damage.amount) = (0, damage.amount + health.current);
        }
        OnTakeDamage?.Invoke();
        return damage.amount;
    }

    public virtual float HealUp(float heal)
    {
        health.current += heal;
        if (health.current > health.total)
        {
            (health.current, heal) = (health.total, heal + health.total - health.current);
        }
        OnHealUp?.Invoke();
        return heal;
    }
    public void Effect(Stat stat, float amount, float duration)
    {
        StartCoroutine(Activate(stat, amount, duration));
    }
    protected IEnumerator Activate(Stat stat, float amount, float duration)
    {
        stat.total += amount;
        yield return new WaitForSeconds(duration);
        stat.total -= amount;
    }
}
