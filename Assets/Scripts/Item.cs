using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemSO itemSO;
    public int amount;
    public Image icon;
    public TMP_Text amountText;
    public ItemtType type;
    private void Start()
    {
        Set();
    }
    public void Set()
    {
        if (itemSO == null) return;
        icon.sprite = itemSO.sprite;
        if (amount > 1) amountText.text = amount.ToString();
        type = itemSO.type;
    }
}
