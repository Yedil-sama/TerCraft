using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tileBlockPrefab;
    public List<BlockSO> allBlocksSO = new List<BlockSO>();
    public List<Block> allBlocks = new List<Block>();

    public InventorySlot selectedSlot;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        for (int i = 0; i < allBlocksSO.Count; i++)
        {
            GameObject tileBlock = Instantiate(tileBlockPrefab, transform);
            tileBlock.transform.position = new Vector2(9999, 0);
            tileBlock.GetComponent<Block>().Initialize(allBlocksSO[i]);
            allBlocks.Add(tileBlock.GetComponent<Block>());
        }
    }
    private void Start()
    {
        
    }
    public void SelectSlot(int ind)
    {
        selectedSlot = inventorySlots[ind];
    }
}
