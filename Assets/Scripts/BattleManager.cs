using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BattleManager : MonoBehaviour
{   
    [SerializeField] BattleContext battleContext; 
    [SerializeField] EnemyDatabase enemyDatabase;

    public GameObject enemyPrefab;
    public Player player;
    public List<Enemy> enemyList;
    
    public Canvas battleCanvas;
    bool playerTurn = true;
    int turnCount = 0;
    bool battlecontinues = true;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetBattle();
        //TurnManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBattle()
    {
        // Code to reset battle state
        battleCanvas.enabled = true;
        turnCount = 0;
        foreach (int enemyID in battleContext.enemyList)
        {
            Debug.Log("敵ID: " + enemyID);
        }
        enemyDatabase.Init();
        foreach (int enemyID in battleContext.enemyList)
        {
            EnemyObj enemyObj = enemyDatabase.GetEnemyByID(enemyID);
            Debug.Log("敵の名前: " + enemyObj.enemyName);
            Debug.Log("敵のHP: " + enemyObj.HP);
            Debug.Log("敵の攻撃力: " + enemyObj.Atk);
            Debug.Log("敵の弱点: " + enemyObj.weakness);
            SpawnEnemy(enemyObj);
        }
        
    }

    void EndBattle()
    {
        // Code to end battle state
        Debug.Log("バトル終了！");
        battleCanvas.enabled = false;

    }

    void SpawnEnemy(EnemyObj enemyObj)
    {
        Debug.Log(enemyObj.enemyName + "が現れた！");
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.name = enemyObj.enemyName;
        enemy.GetComponent<SpriteRenderer>().sprite = enemyObj.enemySprite;
        enemy.GetComponent<Enemy>().Initialize(enemyObj);
        enemyList.Add(enemy.GetComponent<Enemy>());

    }
    public void TurnManager(string action)
    {   
        
        playerTurn = true;
        if(battlecontinues == true)
        {
            if (playerTurn)
            {
                PlayerTurn(action);
                EnemyTurn();
            }
            turnCount++;
            Debug.Log(turnCount + "ターン目終了");
            
            if (turnCount >= 10)
            {
                Debug.Log("時間切れ…");
                battlecontinues = false;
            }
            if(battlecontinues == false)
            {
                EndBattle();
            }
        }
        //Debug.Log("バトル終了！");

    }
    void PlayerTurn(string action)
    {
        Debug.Log("行動を選択してね!");
        if (action == "Attack")
        {
            Debug.Log(enemyList[1].name + "に" + /*fireball.GetSpellName() +*/ "で攻撃!");
            enemyList[0].Damage(player.Atk /*+ fireball.GetPower()*/);
            if(!enemyList[0].IsAlive())
            {
                Debug.Log(enemyList[0].name + " の負け!");
                // Code to handle enemy defeat
                battlecontinues = false;
            }
            playerTurn = false;
        }
        else if (action == "Defend")
        {
            Debug.Log("防御成功!");
            // Code to handle defense
            playerTurn = false;
        }
        else
        {
            Debug.Log("よくわからんかったわ。もう一回言ってくれ");
        }
    }

    void EnemyTurn()
    {
        if(enemyList[0].IsAlive() == false)
        {
            return;
        }
        Debug.Log("相手のターン!");
        // Code for enemy action
        Debug.Log(enemyList[0].name + "の攻撃!");
        player.Damage(enemyList[0].enemyObj.Atk);

        if(!player.IsAlive())
        {
            Debug.Log("あなたの負け!");
            // Code to handle player defeat
            battlecontinues = false;
        }
        playerTurn = true;
    }
}
