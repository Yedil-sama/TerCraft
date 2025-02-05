using System;
using UnityEngine;
[Serializable]
public class Health : Stat
{
    public float regeneration;
    public float regenRate;
    [HideInInspector] public float lastRegenerationTime = 0f;
}
