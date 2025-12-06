using UnityEngine;

public class BattleStarter: MonoBehaviour
{
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
