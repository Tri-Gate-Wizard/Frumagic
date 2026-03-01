using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    public BattleContext battleContext;
    public PlayerPosKeeper playerPosKeeper;
    public GeneralDataKeeper generalDataKeeper;
    public FloorManager floorManager;
    private bool isTransitioning = false;

    void Update()
    {
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Camera.main.nearClipPlane;
            targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
            targetPosition.z = 0;
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f){
                isMoving = false;
            }
        }
    }
    public void TransitionEnd()
    {
        isTransitioning = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Battle Started!");
            // バトル開始のロジックをここに追加
            battleContext.enemyList = other.GetComponent<EnemyBreakDown>().enemyIDs;
            battleContext.battledEnemyIndex = other.GetComponent<EnemyBreakDown>().enemyIndex;
            playerPosKeeper.playerPosition = transform.position;
            UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
        }
        else if (other.CompareTag("Transition") && !isTransitioning)
        {
            Debug.Log("Transition Triggered!");
            isTransitioning = true;
            // フロア遷移のロジックをここに追加
            playerPosKeeper.playerPosition = new Vector3(0, 0, 0); // フロア遷移後のプレイヤーの位置を設定
            floorManager.LoadNextFloor();

        }
    }

    
}
