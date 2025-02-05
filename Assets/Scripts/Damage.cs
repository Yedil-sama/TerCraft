using System;
public enum DamageType
{
    Physical,
    Magical,
    True
}
[Serializable]
public class Damage 
{
    public float amount;
    public float penetration;
    public DamageType type;
}
