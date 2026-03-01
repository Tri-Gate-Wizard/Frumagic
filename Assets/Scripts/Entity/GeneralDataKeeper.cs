using UnityEngine;

[CreateAssetMenu(fileName = "GeneralDataKeeper", menuName = "Scriptable Objects/GeneralDataKeeper")]
public class GeneralDataKeeper : ScriptableObject
{
    public int currentFloorNum;
    public int maxFloorNum;
    public bool isFloorChanged;
}
