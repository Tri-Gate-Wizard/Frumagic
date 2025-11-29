using System;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class BattleManager : MonoBehaviour
{   
    bool playerTurn = true;
    int turnCount = 0;
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
        bool battlecontinues = true;
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
            turnCount++;
            if (turnCount >= 10)
            {
                Debug.Log("Battle ended in a draw due to turn limit.");
                battlecontinues = false;
            }
        }
        
        

        // Code to initiate battle sequence

    }
    void PlayerTurn()
    {
        Debug.Log("Make your move!");
        string input = "";  // Placeholder for player input
        input = Console.ReadLine();
        if (input == "attack")
        {
            Debug.Log("You attacked the enemy!");
            // Code to handle attack
            playerTurn = false;
        }
        else if (input == "defend")
        {
            Debug.Log("You defended against the enemy's attack!");
            // Code to handle defense
            playerTurn = false;
        }
        else
        {
            Debug.Log("Invalid move. Try again.");
        }
    }

    void EnemyTurn()
    {
        Debug.Log("Enemy's turn!");
        // Code for enemy action
        Debug.Log("The enemy attacked you!");
        playerTurn = true;
    }
}
