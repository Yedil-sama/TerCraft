using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Block", menuName = "Scriptable Objects/New Block")]
public class BlockSO : ScriptableObject
{
    public int id;
    public TileBase tileBase;
    public Health health;
    public Armor armor;
}
