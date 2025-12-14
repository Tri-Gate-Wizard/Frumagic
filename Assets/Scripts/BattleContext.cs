using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BattleContext", menuName = "Scriptable Objects/BattleContext")]
public class BattleContext : ScriptableObject
{
    public List<int> enemyList;
}
