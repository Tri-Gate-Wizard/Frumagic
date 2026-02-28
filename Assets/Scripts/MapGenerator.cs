using UnityEngine;
using UnityEngine.Tilemaps;
public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase groundTile; 
    public TileBase wallTile;
    public TileBase TransitionTile;
    public GameObject TransitionObject;

    
    public float wallProbability = 0.2f;
    public MapMemoryKeeper mapMemoryKeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MapGenerate();
        SettingTile();
    }
    void MapGenerate()
    {
        mapMemoryKeeper.mapData = new int[mapMemoryKeeper.width, mapMemoryKeeper.height];

        for (int x = 0; x < mapMemoryKeeper.width; x++)
        {
            for (int y = 0; y < mapMemoryKeeper.height; y++)
            {
                mapMemoryKeeper.mapData[x, y] = (Random.value < wallProbability) ? 1 : 0;
                
            }
        }
        
    }
    void SettingTile()
    {
        for (int x = 0; x < mapMemoryKeeper.width; x++)
        {
            for (int y = 0; y < mapMemoryKeeper.height; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                TileBase tile = (mapMemoryKeeper.mapData[x, y] == 1) ? wallTile : groundTile;
                tilemap.SetTile(tilePos, tile);
            }
        }
        Vector3Int transpos = new Vector3Int(Random.Range(0, mapMemoryKeeper.width), Random.Range(0, mapMemoryKeeper.height),0);
        tilemap.SetTile(transpos, TransitionTile);
        TransitionObject.transform.position = transpos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
