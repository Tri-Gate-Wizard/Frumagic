using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spell
{
    List<Glyph> glyphs;
    int cost;
    string element;
    int power;

    string movement;

    string effect;

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
