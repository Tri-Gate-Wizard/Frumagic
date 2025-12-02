using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public static class SpellManager
{
    public static Spell CreateSpell(List<Glyph> glyphs)
    {
        int totalCost = glyphs.Sum(g => g.GetBaseCost());
        string element = ResolveElement(glyphs);
        int power = CalculatePower(glyphs);
        string movement = ResolveMovement(glyphs);
        string effects = ResolveEffects(glyphs);
        string recoil = ResolveRecoil(glyphs);
        return new Spell(glyphs, totalCost, element, power, movement, effects, recoil);
    }

    static string ResolveElement(List<Glyph> glyphs)
    {   
        var elementGlyphs = glyphs.Where(g => g.GetCategory() == GlyphCategory.Element).Select(g => g.GetTrait()).ToList();

        if (elementGlyphs.Count == 0)
            return "無";
        if (elementGlyphs.Count == 1)
            return elementGlyphs[0];
        else
        {
            if (elementGlyphs.Contains("火") && elementGlyphs.Contains("水"))
                return "蒸気";
            if (elementGlyphs.Contains("火") && elementGlyphs.Contains("土"))
                return "溶岩";
            if (elementGlyphs.Contains("火") && elementGlyphs.Contains("風"))
                return "熱波";
            if (elementGlyphs.Contains("火") && elementGlyphs.Contains("雷"))
                return "火雷";
            if (elementGlyphs.Contains("火") && elementGlyphs.Contains("氷"))
                return "熱湯";
            if (elementGlyphs.Contains("火") && elementGlyphs.Contains("光"))
                return "陽炎";
            if (elementGlyphs.Contains("火") && elementGlyphs.Contains("闇"))
                return "黒炎";
            if (elementGlyphs.Contains("水") && elementGlyphs.Contains("土"))
                return "泥";
            if (elementGlyphs.Contains("水") && elementGlyphs.Contains("風"))
                return "渦";
            if (elementGlyphs.Contains("水") && elementGlyphs.Contains("雷"))
                return "帯電";
            if (elementGlyphs.Contains("水") && elementGlyphs.Contains("氷"))
                return "氷水";
            if (elementGlyphs.Contains("水") && elementGlyphs.Contains("光"))
                return "聖水";
            if (elementGlyphs.Contains("水") && elementGlyphs.Contains("闇"))
                return "深海";
            if (elementGlyphs.Contains("土") && elementGlyphs.Contains("風"))
                return "砂嵐";
            if (elementGlyphs.Contains("土") && elementGlyphs.Contains("雷"))
                return "磁場";
            if (elementGlyphs.Contains("土") && elementGlyphs.Contains("氷"))
                return "凍土";
            if (elementGlyphs.Contains("土") && elementGlyphs.Contains("光"))
                return "治癒";
            if (elementGlyphs.Contains("土") && elementGlyphs.Contains("闇"))
                return "呪物";
            if (elementGlyphs.Contains("風") && elementGlyphs.Contains("雷"))
                return "嵐";
            if (elementGlyphs.Contains("風") && elementGlyphs.Contains("氷"))
                return "吹雪";
            if (elementGlyphs.Contains("風") && elementGlyphs.Contains("光"))
                return "清風";
            if (elementGlyphs.Contains("風") && elementGlyphs.Contains("闇"))
                return "毒";
            if (elementGlyphs.Contains("雷") && elementGlyphs.Contains("氷"))
                return "雷氷";
            if (elementGlyphs.Contains("雷") && elementGlyphs.Contains("光"))
                return "雷光";
            if (elementGlyphs.Contains("雷") && elementGlyphs.Contains("闇"))
                return "黒雷";
            if (elementGlyphs.Contains("氷") && elementGlyphs.Contains("光"))
                return "鏡";
            if (elementGlyphs.Contains("氷") && elementGlyphs.Contains("闇"))
                return "封印";
            if (elementGlyphs.Contains("光") && elementGlyphs.Contains("闇"))
                return "黄昏";
            if (elementGlyphs.Contains("火"))
                return "火";
            if (elementGlyphs.Contains("水"))
                return "水";
            if (elementGlyphs.Contains("土"))
                return "土";
            if (elementGlyphs.Contains("風"))
                return "風";
            if (elementGlyphs.Contains("雷"))
                return "雷";
            if (elementGlyphs.Contains("氷"))
                return "氷";
            if (elementGlyphs.Contains("光"))
                return "光";
            if (elementGlyphs.Contains("闇"))
                return "闇";
        }
        return "火"; // Placeholder
    }
    static int CalculatePower(List<Glyph> glyphs)
    {
        int basePower = 10;
        foreach (var g in glyphs)
        {
            var Ope = g.GetPowerOperation();
            basePower = Ope(basePower);
        }

        return basePower;
    }

    static string ResolveMovement(List<Glyph> glyphs)
    {
        var movementGlyphs = glyphs.Where(g => g.GetCategory() == GlyphCategory.Movement).Select(g => g.GetTrait()).ToList();
        if (movementGlyphs.Count == 0)
            return "直線";
        return movementGlyphs[0];
    }

    static string ResolveEffects(List<Glyph> glyphs)
    {
        var effectGlyphs = glyphs.Where(g => g.GetCategory() == GlyphCategory.Shape).Select(g => g.GetTrait()).ToList();
        if (effectGlyphs.Count == 0)
            return "なし";
        return effectGlyphs[0];
    }

    static string ResolveRecoil(List<Glyph> glyphs)
    {
        return "なし";
    }

}
