using System.Collections.Generic;
using UnityEngine;

public class EnemyBreakDown: MonoBehaviour
{
    public List<int> enemyIDs;
    public int enemyIndex;    

    void Start()
    {
        if (enemyIndex != GameManager.instance.battleEnemyIndex)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
