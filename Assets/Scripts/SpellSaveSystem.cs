using System.Collections.Generic;
using UnityEngine;

public class SpellSaveSystem
{
    public static void SaveSpells(List<Spell> spells)
    {
        // Implement saving logic here
        SpellList spellList = new SpellList();
        spellList.spells = spells;
        foreach (var s in spells)
        {
            Debug.Log($"Element={s.GetElement()} Power={s.GetPower()} Cost={s.GetManaCost()} Movement={s.GetMovement()} Effect={s.GetEffect()}");
        }
        string json = JsonUtility.ToJson(spellList);
        PlayerPrefs.SetString("SavedSpell", json);
        Debug.Log(json);
        PlayerPrefs.Save();
        Debug.Log($"Spell saved");
    }

    public static List<Spell> LoadSpells()
    {
        // Implement loading logic here
        if (PlayerPrefs.HasKey("SavedSpell"))
        {
            string json = PlayerPrefs.GetString("SavedSpell");
            SpellList spelllist = JsonUtility.FromJson<SpellList>(json);
            Debug.Log($"Spell loaded");
            return spelllist.spells;
        }
        else
        {
            Debug.Log("No saved spell found");
            return null;
        }
    }
}
