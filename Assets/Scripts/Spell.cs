using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Spell
{
    [SerializeField]
    List<Glyph> glyphs;
    [SerializeField]
    int cost;
    [SerializeField]
    string element;
    [SerializeField]
    int power;
    [SerializeField]

    string movement;
    [SerializeField]

    string effect;
    [SerializeField]

    string recoil;

    public Spell(List<Glyph> gly, int cos, string ele, int pow, string mov, string eff, string rec)
    {
        glyphs = gly;
        cost = cos;
        element = ele;
        power = pow;
        movement = mov;
        effect = eff;
        recoil = rec;
    }

    public List<Glyph> GetGlyphs()
    {
        return glyphs;
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
