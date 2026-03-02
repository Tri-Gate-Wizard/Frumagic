using System.Collections.Generic;
using UnityEngine;

public class EnemyBreakDown: MonoBehaviour
{
    public List<int> enemyIDs;
    public int enemyIndex;    

    void Start()
    {
        gameObject.SetActive(false);
        if (enemyIndex == GameManager.instance.battleEnemyIndex && GameManager.instance.isWonBattle)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        GameManager.instance.isWonBattle = false; // フラグをリセット
    }
}
