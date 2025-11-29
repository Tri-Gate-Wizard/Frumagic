using System;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class BattleManager : MonoBehaviour
{   
    public Player player;
    public Enemy enemy;
    bool playerTurn = true;
    int turnCount = 0;
    bool battlecontinues = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetBattle();
        TurnManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBattle()
    {
        // Code to reset battle state
    }
    void TurnManager()
    {   
        
        playerTurn = true;
        while(battlecontinues == true)
        {
            if (playerTurn)
            {
                PlayerTurn();
            }
            else
            {
                EnemyTurn();
            }
            Debug.Log(turnCount + "ターン目終了");
            turnCount++;
            
            if (turnCount >= 10)
            {
                Debug.Log("時間切れ…");
                battlecontinues = false;
            }
        }
        Debug.Log("バトル終了！");

    }
    void PlayerTurn()
    {
        Debug.Log("行動を選択してね!");
        string input = "";  // Placeholder for player input
        //input = Console.ReadLine();
        input = "attack"; //仮の入力
        if (input == "attack")
        {
            Debug.Log(enemy.name + "に攻撃!");
            enemy.Damage(player.Atk);
            if(!enemy.IsAlive())
            {
                Debug.Log(enemy.name + " の負け!");
                // Code to handle enemy defeat
                battlecontinues = false;
            }
            playerTurn = false;
        }
        else if (input == "defend")
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
        Debug.Log("Enemy's turn!");
        // Code for enemy action
        Debug.Log(enemy.name + "の攻撃!");
        player.Damage(enemy.Atk);
        if(!player.IsAlive())
        {
            Debug.Log("あなたの負け!");
            // Code to handle player defeat
            battlecontinues = false;
        }
        playerTurn = true;
    }
}
