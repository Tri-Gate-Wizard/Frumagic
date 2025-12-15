using System;
using UnityEngine;

public enum GlyphCategory
{
    Element,
    Movement,
    Shape
}

public class Glyph
{
    string glyphName;
    Func<int, int> powerOperation;
    GlyphCategory category;
    string trait;

    int baseCost;

    string hiddenEffect;

    public Glyph(string name, Func<int,int> powOpe, GlyphCategory cat, string trai, int baseC, string hiddenEff)
    {
        glyphName = name;
        powerOperation = powOpe;
        category = cat;
        trait = trai;
        baseCost = baseC;
        hiddenEffect = hiddenEff;
    }

    public string GetGlyphName()
    {
        return glyphName;
    }

    public Func<int, int> GetPowerOperation()
    {
        return powerOperation;
    }

    public GlyphCategory GetCategory()
    {
        return category;
    }

    public string GetTrait()
    {
        return trait;
    }
    
    public int GetBaseCost()
    {
        return baseCost;
    }
    public string GetHiddenEffect()
    {
        return hiddenEffect;
    }


}
