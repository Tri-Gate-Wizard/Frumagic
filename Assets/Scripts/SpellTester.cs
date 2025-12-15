using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SpellTester : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var fire = new Glyph("火", x => x + 10, GlyphCategory.Element, "火", 2, "Burns target");
        var earth = new Glyph("土", x => x * 2, GlyphCategory.Element, "氷", 3, "Heavy impact");
        var straight = new Glyph("直進", x => x, GlyphCategory.Movement, "直進", 1, "Straight line");
        var circle = new Glyph("円", x => x, GlyphCategory.Shape, "円", 1, "Area of effect");

        var glyphs = new List<Glyph> { fire, earth, straight, circle };
        Spell spell = SpellManager.CreateSpell(glyphs);
        var spellList = new List<Spell> { spell };
        SpellSaveSystem.SaveSpells(spellList);
        string spellName = glyphs.Select(g => g.GetGlyphName()).Aggregate((result,current) => result + current);

        Debug.Log($"Name: {spellName} Spell: {spell.GetElement()} Power={spell.GetPower()} Cost={spell.GetManaCost()} Movement={spell.GetMovement()} Effect={spell.GetEffect()}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestLoad()
    {
        var loadedSpells = SpellSaveSystem.LoadSpells();
        Debug.Log("Loaded Spells number: " + loadedSpells.Count);
        foreach (var s in loadedSpells)
        {
            Debug.Log($"Element={s.GetElement()} Power={s.GetPower()} Cost={s.GetManaCost()} Movement={s.GetMovement()} Effect={s.GetEffect()}");
        }
    }
}
