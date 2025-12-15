using UnityEngine;

public class Character : MonoBehaviour
{
    public int HP;
    public int Atk;

    public bool IsAlive()
    {
        return (HP > 0);
    }

    public virtual void Damage(int damage)
    {
        Debug.Log(this.name + "は" + damage + "ダメージ受けた!");
        HP -= damage;
        if (HP <= 0)
            HP = 0;

    }
    public virtual void Heal(int amount)
    {
        Debug.Log(this.name + "は" + amount + "回復した!");
        HP += amount;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = 100;
        Atk = 20;
    }

    // Update is called once per frame
}
