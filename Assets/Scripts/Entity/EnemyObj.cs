using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyObj", menuName = "Scriptable Objects/EnemyObj")]
public class EnemyObj : ScriptableObject
{
    public string enemyName;
    public int enemyID;
    public int HP;
    public int Atk;
    public List<ElementEnum> weakness;
    public Sprite enemySprite;
}
