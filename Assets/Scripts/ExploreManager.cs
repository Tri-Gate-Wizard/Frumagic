using UnityEngine;
using System.Collections.Generic;
using System;

public class ExploreManager : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerPosKeeper playerPosKeeper;
    public GameObject enemySample;
    public BattleContext battleContext;
    public GeneralDataKeeper generalDataKeeper;
    public int enemyCount = 3;
    public bool isCleared = true;
    public MapFolder mapFolder;
    private GameObject currentMap;
    //public BattleContext battleContext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // プレイヤーの位置を復元
        Debug.Log("現在のフロア: " + generalDataKeeper.currentFloorNum);

        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        playerObject.transform.position = playerPosKeeper.playerPosition;
        playerController.TransitionEnd(); // フロア遷移が完了したことをPlayerControllerに通知
        currentMap = Instantiate(mapFolder.maps[generalDataKeeper.currentFloorNum], Vector3.zero, Quaternion.identity);
        if (generalDataKeeper.isFloorChanged)
        {
            //playerObject.transform.position = Vector3.zero; // フロアが変わった場合はプレイヤーを初期位置に配置
            generalDataKeeper.isFloorChanged = false;
        }
        
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
