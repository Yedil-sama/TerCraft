using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerBuilding : MonoBehaviour
{
    [SerializeField] private World world;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Block block;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 pos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            world.RemoveBlock(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 pos =  tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            world.SetBlock(block, Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
        }
    }
}
