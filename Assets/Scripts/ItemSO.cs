using UnityEngine;
public enum ItemtType
{
    Block,
    Weapon,
    Armor,
    Accessory,
    Potion,
    Food
}
[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/New Item")]
public class ItemSO : ScriptableObject
{
    public Sprite sprite;
    public int maxAmount;
    public ItemtType type;
}
