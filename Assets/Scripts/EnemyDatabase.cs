using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDatabase", menuName = "Scriptable Objects/EnemyDatabase")]
public class EnemyDatabase : ScriptableObject
{
    public List<EnemyObj> enemies;

    private Dictionary<int, EnemyObj> enemyDict;

    public void Init()
    {
        enemyDict = new Dictionary<int, EnemyObj>();
        foreach (var enemy in enemies)
        {
            enemyDict[enemy.enemyID] = enemy;
        }
    }

    public EnemyObj GetEnemyByID(int id)
    {

        return enemyDict[id];
    }
}
