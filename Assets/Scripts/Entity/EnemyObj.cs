using UnityEngine;

[CreateAssetMenu(fileName = "EnemyObj", menuName = "Scriptable Objects/EnemyObj")]
public class EnemyObj : ScriptableObject
{
    public string enemyName;
    public int enemyID;
    public int HP;
    public int Atk;
    public string weakness;
    public Sprite enemySprite;
}
