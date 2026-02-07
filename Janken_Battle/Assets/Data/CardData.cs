using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public enum CardType
    {
        Rock,
        Paper,
        Scissors,
        Barrier
    }
    public enum SpecialEffect
    {
        None,
        Recover
    }
    public CardType cardType;
    public SpecialEffect specialEffect;
    public int power;
}
