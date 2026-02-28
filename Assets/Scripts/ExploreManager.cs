using UnityEngine;
using System.Collections.Generic;
using System;

public class ExploreManager : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerPosKeeper playerPosKeeper;
    public GameObject enemySample;
    public BattleContext battleContext;
    public int enemyCount = 3;
    public bool isCleared = true;
    //public BattleContext battleContext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // プレイヤーの位置を復元
        playerObject.transform.position = playerPosKeeper.playerPosition;
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(enemySample,i);
        }
        if (isCleared)
        {
            Debug.Log("このエリアはクリアされている!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy(GameObject enemy, int index)
    {   
        if (battleContext.livingEnemyList[index])
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(0.0f, 25.0f), UnityEngine.Random.Range(0.0f, 25.0f), 0.0f);
            GameObject enemyInstance = Instantiate(enemy, spawnPosition, Quaternion.identity);
            //enemy.GetComponent<SpriteRenderer>().sprite = enemyObj.enemySprite;
            enemyInstance.name = "EnemySample" + index;
            enemyInstance.GetComponent<EnemyBreakDown>().enemyIndex = index;
            //enemy.GetComponent<Enemy>().Initialize(enemyObj);
            //battleContext.livingEnemyList.Add(true);
            isCleared = false;
        }
        
        

    }
}
