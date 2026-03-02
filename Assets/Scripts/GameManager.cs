using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentFloorNum;
    public Vector3 playerPosition;
    public List<int> EnemyList;
    public List<bool> livingEnemyList;
    public int battleEnemyIndex;
    public bool isWonBattle;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
