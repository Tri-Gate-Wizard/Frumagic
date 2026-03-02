using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentFloorNum;
    public int battleEnemyIndex;
    public Vector3 playerPosition;

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
