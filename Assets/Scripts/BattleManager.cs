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
    bool isDefend = false;
    int turnCount = 0;
    int Def = 1;
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
        int i = 0;

        foreach (int enemyID in battleContext.enemyList)
        {
            EnemyObj enemyObj = enemyDatabase.GetEnemyByID(enemyID);
            Debug.Log("敵の名前: " + enemyObj.enemyName);
            Debug.Log("敵のHP: " + enemyObj.HP);
            Debug.Log("敵の攻撃力: " + enemyObj.Atk);
            Debug.Log("敵の弱点: " + enemyObj.weakness);
            SpawnEnemy(enemyObj,new Vector3(i * 3.0f, i * -1.0f, 0.0f));
            i++;
        }
        
    }

    void EndBattle()
    {
        // Code to end battle state
        Debug.Log("バトル終了！");
        battleCanvas.enabled = false;
        battleContext.livingEnemyList[battleContext.battledEnemyIndex] = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExploreScene");
    }

    void SpawnEnemy(EnemyObj enemyObj, Vector3 position)
    {
        Debug.Log(enemyObj.enemyName + "が現れた！");
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemy.name = enemyObj.enemyName;
        enemy.GetComponent<SpriteRenderer>().sprite = enemyObj.enemySprite;
        enemy.GetComponent<Enemy>().Initialize(enemyObj);
        enemyList.Add(enemy.GetComponent<Enemy>());

    }
    public void TurnManager(string action)
    {   
            PlayerTurn(action);
            Def = 1;
            
            if (turnCount >= 10)
            {
                Debug.Log("時間切れ…");
                battlecontinues = false;
            }
            if(battlecontinues == false)
            {
                EndBattle();
            }
        //Debug.Log("バトル終了！");

    }
    void PlayerTurn(string action)
    {
        Debug.Log("行動を選択してね!");
        if (action == "Attack")
        {
            Debug.Log(enemyList[0].name + "に" + /*fireball.GetSpellName() +*/ "で攻撃!");
            enemyList[0].Damage(player.Atk /*+ fireball.GetPower()*/);
            if(!enemyList[0].IsAlive())
            {
                Debug.Log(enemyList[0].name + " は倒れた!");
                // Code to handle enemy defeat
                battlecontinues = false;
            }
            turnCount++;
            if (!isDefend)
            {
                EnemyTurn();
            }
            Debug.Log(turnCount + "ターン目終了");
            isDefend = false;
        }
        else if (action == "Defend")
        {
            isDefend = true;
            Def = 2;
            Debug.Log("防御成功!");
            EnemyTurn();
        }
        else if (action == "Item")
        {
            Debug.Log("アイテムを使った!");
            player.Heal(20);
        }
        else
        {
            Debug.Log("よくわからんかったわ。もう一回言ってくれ");
        }
    }

    void EnemyTurn()
    {
        foreach(Enemy enemy in enemyList)
        {
            
        
            if(enemy.IsAlive() == false)
            {
                return;
            }
            Debug.Log("相手のターン!");
            // Code for enemy action
            Debug.Log(enemy.name + "の攻撃!");
            player.Damage(enemy.enemyObj.Atk/Def);

            if(!player.IsAlive())
            {
                Debug.Log("あなたの負け!");
                // Code to handle player defeat
                battlecontinues = false;
            }
                
        }
    }
}
