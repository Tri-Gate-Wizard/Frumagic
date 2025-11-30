using UnityEngine;

public class Spell
{
    string spellName;
    int manaCost;
    string element;
    int power;

    public Spell(string name, int cost, string elem, int pow)
    {
        spellName = name;
        manaCost = cost;
        element = elem;
        power = pow;
    }
    public string GetSpellName()
    {
        return spellName;
    }
    public int GetManaCost()
    {
        return manaCost;
    }
    public string GetElement()
    {
        return element;
    }
    public int GetPower()
    {
        return power;
    }
}
