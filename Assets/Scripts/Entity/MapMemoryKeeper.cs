using UnityEngine;

[CreateAssetMenu(fileName = "MapMemoryKeeper", menuName = "Scriptable Objects/MapMemoryKeeper")]
public class MapMemoryKeeper : ScriptableObject
{
    public string mapName;
    public int mapID;
    public int width;
    public int height;
    public int[,] mapData;
}
