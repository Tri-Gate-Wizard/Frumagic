using UnityEngine;
using UnityEngine.Tilemaps;
public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase groundTile; 
    public TileBase wallTile;
    public TileBase TransitionTile;
    public GameObject TransitionObject;

    public int width = 50;
    public int height = 50;
    public float wallProbability = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int[,] map = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = (Random.value < wallProbability) ? 1 : 0;
                TileBase tile = (map[x, y] == 1) ? wallTile : groundTile;
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
        Vector3Int transpos = new Vector3Int(Random.Range(0, width), Random.Range(0, height),0);
        tilemap.SetTile(transpos, TransitionTile);
        TransitionObject.transform.position = transpos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
