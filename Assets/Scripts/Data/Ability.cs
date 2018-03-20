using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AbilityTypes { None, DamagingST,DamagingAOE, HealingST, HealingAOE }

[CreateAssetMenu(fileName = "AbilityConfiguration", menuName = "SWLTCG/Ability")]
public class Ability : ScriptableObject
{
    public string Name;
    public bool Dot;
    public int DotTurns;
    public AbilityTypes Type;
    public int Power;
    public int Cost;
    public bool CanCrit;
    public bool AegisPowerMatches;
    public int AegisPower;
    public bool CanBeUsedOnLastTurn;
}
