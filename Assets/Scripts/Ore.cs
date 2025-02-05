using System;
using UnityEngine;

[Serializable]
public class Ore
{
    public string name;
    public float freq;
    public float treshold;
    public int minY;
    public int maxY;
    public Texture2D spreadTexture;
}