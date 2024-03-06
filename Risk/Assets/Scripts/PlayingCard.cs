using System;
using UnityEngine;

public enum PlayingCardType : int
{
    INFANTRY = 0,
    CAVALRY,
    ARTILLARY,
    WILDCARD
}

public class PlayingCard : MonoBehaviour
{
    public PlayingCardType design;
    public TerritoryType territory;

    void Start()
    {
        GenerateCard();
    }

    void Update()
    {

    }

    // Generate a random design and territory to be allocated to the card.
    public void GenerateCard()
    {
        //Static variable below, Fix later
        System.Random random = new Random();
        List<TerritoryType> terrValues = Enum.GetValues(typeof(TerritoryType));
        List<PlayingCardType> designValues = Enum.GetValues(typeof(PlayingCardType));
        design = (PlayingCardType)designValues.GetValue(
            random.Next(designValues.Length));
        territory = (TerritoryType)terrValues.GetValue(
            random.Next(terrValues.Length));
    }
}
