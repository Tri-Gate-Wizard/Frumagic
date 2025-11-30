using UnityEngine;

public class Spell : MonoBehaviour
{
    string spellName;
    int cost;
    string element;
    int power;

    string movement;

    string effect;

    string recoil;

    public Spell(string name, int cos, string elem, int pow,
                 string move, string eff, string rec)
    {
        spellName = name;
        cost = cos;
        element = elem;
        power = pow;
        movement = move;
        effect = eff;
        recoil = rec;
    }
    public string GetSpellName()
    {
        return spellName;
    }
    public int GetManaCost()
    {
        return cost;
    }
    public string GetElement()
    {
        return element;
    }
    public int GetPower()
    {
        return power;
    }
    public string GetMovement()
    {
        return movement;
    }
    public string GetEffect()
    {
        return effect;
    }
    public string GetRecoil()
    {
        return recoil;
    }
}
