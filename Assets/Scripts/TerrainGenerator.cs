using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public World world;
    public bool canGenerateCaves = true;

    [Space]
    [Header("Generation")]
    public float seed;
    public Vector2Int worldSize;
    public float surfaceValue = 0.25f;
    public float heightMultiplier = 30f;
    public int heightAddition = 50;
    public float terrainFreq = 0.05f;
    public float caveFreq = 0.05f;

    [Space]
    [Header("Blocks")]
    public Block dirt;
    public Block stone;
    public Block grass;
    public Block log;
    public Block coal;
    public Block iron;
    public Block gold;
    public Block diamond;

    [Space]
    [Header("Chances")]
    public int dirtLayerHeight = 5;
    public int treeFreq = 10;
    public int treeMinHeight = 4;
    public int treeMaxHeight = 10;
    public Texture2D noiseTexture;

    [Header("Ores")]
    public Ore[] ores;

    private void Start()
    {
        noiseTexture = new Texture2D(worldSize.x, worldSize.y);

        foreach (Ore ore in ores)
        {
            ore.spreadTexture = new Texture2D(worldSize.x, worldSize.y);

        }

        dirt = GameManager.Instance.allBlocks[0];
        stone = GameManager.Instance.allBlocks[1];
        grass = GameManager.Instance.allBlocks[2];
        log = GameManager.Instance.allBlocks[3];
        coal = GameManager.Instance.allBlocks[4];
        iron = GameManager.Instance.allBlocks[5];
        gold = GameManager.Instance.allBlocks[6];
        diamond = GameManager.Instance.allBlocks[7];

        if (seed == 0) seed = Random.Range(-10000, 10000);

        GenerateNoiseTexture(noiseTexture, caveFreq, surfaceValue);

        foreach (Ore ore in ores)
        {
            GenerateNoiseTexture(ore.spreadTexture, ore.freq, ore.treshold);
        }

        GenerateTerrain();
    }
    public void GenerateTree(int x, int y)
    {
        int treeHeight = Random.Range(treeMinHeight, treeMaxHeight);
        for (int i = 0; i < treeHeight; i++)
        {
            world.SetBlock(log, x, y + i);
        }
    }

    public void GenerateTerrain()
    {
        for (int x = -worldSize.x / 2; x < worldSize.x / 2; x++)
        {
            float height = Mathf.PerlinNoise((x + seed) * terrainFreq, seed * terrainFreq) * heightMultiplier + worldSize.y;
            for (int y = 0; y < height; y++)
            {
                Block block;
                if (y < height - dirtLayerHeight)
                {
                    block = stone;
                    if (ores[0].spreadTexture.GetPixel(x, y).r > 0.5f && y >= ores[0].minY && y <= ores[0].maxY) block = coal;

                    else if (ores[1].spreadTexture.GetPixel(x, y).r > 0.5f && y >= ores[1].minY && y <= ores[1].maxY) block = iron;

                    else if (ores[2].spreadTexture.GetPixel(x, y).r > 0.5f && y >= ores[2].minY && y <= ores[2].maxY) block = gold;
                    else if (ores[3].spreadTexture.GetPixel(x, y).r > 0.5f && y >= ores[3].minY && y <= ores[3].maxY) block = diamond;
                    else block = stone;
                }

                else if (y < height - 1)
                {
                    block = dirt;

                }
                else
                {
                    block = grass;
                }
                if (canGenerateCaves)
                {
                    if (noiseTexture.GetPixel(x, y).r > 0.5f)
                    {
                        world.SetBlock(block, x, y);
                    }
                }
                else world.SetBlock(block, x, y);

                if (y >= height - 1)
                {
                    int t = Random.Range(0, treeFreq);
                    if (t == 1)
                    {
                        if (world.blocksPos.Contains(new Vector2Int(x, y)))
                        {
                            GenerateTree(x, y + 1);

                        }
                    }

                }
            }
        }
    }
    public void GenerateNoiseTexture(Texture2D noise, float freq, float treshold)
    {
        for (int x = 0; x < worldSize.x; x++)
        {
            for (int y = 0; y < worldSize.y; y++)
            {
                float v = Mathf.PerlinNoise((x + seed) * freq, (y + seed) * freq);
                if (v > treshold) noise.SetPixel(x, y, Color.white);
                else noise.SetPixel(x, y, Color.black);
            }
        }
        noise.Apply();
    }
}

