using System.Collections.Generic;
using UnityEngine;

public class BattleStarter: MonoBehaviour
{
    public List<Enemy> enemieList;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Battle Started!");
            // バトル開始のロジックをここに追加
            UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
        }
    }
}
