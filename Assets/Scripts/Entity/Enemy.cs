using UnityEngine;

public class Enemy :Character
{
    public EnemyObj enemyObj;
    public int currentHP;

    public void Initialize(EnemyObj obj)
    {
        enemyObj = obj;
        currentHP = enemyObj.HP;
        
    }

    public override void Damage(int damage)
    {
        Debug.Log(this.name + "は" + damage + "ダメージ受けた!");
        currentHP -= damage;
        if (currentHP <= 0)
            currentHP = 0;

    }

    public override void Heal(int amount)
    {
        Debug.Log(this.name + "は" + amount + "回復した!");
        currentHP += amount;
    }
    
}
