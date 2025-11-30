using System;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class BattleManager : MonoBehaviour
{   
    public Player player;
    public Enemy enemy;
    public Canvas battleCanvas;
    bool playerTurn = true;
    int turnCount = 0;
    bool battlecontinues = true;

    Spell fireball = new Spell("Fireball", 10, "Fire", 30, "Straight", "Burn", "None");
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
    }

    void EndBattle()
    {
        // Code to end battle state
        Debug.Log("バトル終了！");
        battleCanvas.enabled = false;

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
            Debug.Log(enemy.name + "に" + fireball.GetSpellName() + "で攻撃!");
            enemy.Damage(player.Atk + fireball.GetPower());
            if(!enemy.IsAlive())
            {
                Debug.Log(enemy.name + " の負け!");
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
        if(enemy.IsAlive() == false)
        {
            return;
        }
        Debug.Log("相手のターン!");
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
