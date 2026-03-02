using UnityEngine;

public class FloorManager : MonoBehaviour
{

    //public GeneralDataKeeper generalDataKeeper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadNextFloor()
    {
        // フロア遷移のロジックをここに追加
        Debug.Log("Loading next floor...");
        //generalDataKeeper.currentFloorNum++;
        GameManager.instance.currentFloorNum++;
        if (GameManager.instance.currentFloorNum >= 3)
        {
            GameManager.instance.currentFloorNum = 0; // フロア数をリセット
        }
        //generalDataKeeper.isFloorChanged = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExploreScene");
    }
}
