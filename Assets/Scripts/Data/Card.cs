using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardConfiguration", menuName = "SWLTCG/Card", order = 1)]
public class CardConfiguration : ScriptableObject
{
    public string Name;
    public int Hp;
    public AegisTypes AegisType;
    public int AegisHp;
    public Image CardImage;
    public WeaponTypes Weapon;
    public int WeaponResources;
    public float CritChance;
    public float EvadeChance;
    public float GlanceChance;
    public Ability Ability;
    public Ability HiddenAbility;
}
