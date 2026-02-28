using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapFolder", menuName = "Scriptable Objects/MapFolder")]
public class MapFolder : ScriptableObject
{
    public List<GameObject> maps;
}
