using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class World : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector2Int worldSize;
    public List<Block> blocks = new List<Block>();
    public List<Vector2Int> blocksPos = new List<Vector2Int>();    
    public GameObject tileBlockPrefab;

    private void Awake()
    {

    }
    public void SetBlock(Block block, int x, int y)
    {
        if (blocksPos.Contains(new Vector2Int(x, y))) return;
        if (block == null) return;

        int index = GameManager.Instance.allBlocksSO.IndexOf(block.baseBlock);
        if (index == -1) return;

        Block newBlock = GameManager.Instance.allBlocks[index];
        blocks.Add(newBlock);
        blocksPos.Add(new Vector2Int(x, y));
        tilemap.SetTile(new Vector3Int(x, y, 0), newBlock.tileBase);
    }
    public void RemoveBlock(int x, int y)
    {
        int index = blocksPos.IndexOf(new Vector2Int(x, y));
        if (index == -1) return;

        int ind = GameManager.Instance.allBlocksSO.IndexOf(blocks[index].baseBlock);
        if (ind == -1) return;

        GameObject tileBlock = Instantiate(GameManager.Instance.allBlocks[ind].gameObject, tilemap.transform);
        

        blocks.RemoveAt(index);
        blocksPos.RemoveAt(index);
        tilemap.SetTile(new Vector3Int(x, y, 0), null);

        tileBlock.transform.position = new Vector2((x + 0.4f) * 0.16f, (y + 0.4f) * 0.16f);
        tileBlock.GetComponent<Block>().isDropped = true;
        tileBlock.AddComponent<Rigidbody2D>();
        tileBlock.GetComponent<SpriteRenderer>().sprite = ((Tile)tileBlock.GetComponent<Block>().tileBase).sprite;

    }
}
