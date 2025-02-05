using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Block : MonoBehaviour, IHealth
{
    public BlockSO baseBlock;
    public TileBase tileBase;
    public Health health;
    public Armor armor;

    public bool isDropped = false;

    public event Action OnTakeDamage;
    public event Action OnHealUp;
    private void Awake()
    {
        Initialize(baseBlock);
    }
    public void Initialize(BlockSO block)
    {
        if (block == null) return;
        tileBase = block.tileBase;
        health = block.health;
        armor = block.armor;
        baseBlock = block;
    }
    public float TakeDamage(Damage damage)
    {
        damage.amount -= armor.current;
        if (damage.amount < 0)
        {
            damage.amount = 0;
        }
        health.current -= damage.amount;
        if (health.current <= 0)
        {
            (health.current, damage.amount) = (0, damage.amount + health.current);
        }
        OnTakeDamage?.Invoke();
        return damage.amount;
    }

    public float HealUp(float heal)
    {
        health.current += heal;
        if (health.current > health.total)
        {
            (health.current, heal) = (health.total, heal + health.total - health.current);
        }
        OnHealUp?.Invoke();
        return heal;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isDropped && other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
