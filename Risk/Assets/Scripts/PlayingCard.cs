using System;
using System.Collections.Generic;
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
        System.Random random = new System.Random();
        Array terrValues = Enum.GetValues(typeof(TerritoryType));
        Array designValues = Enum.GetValues(typeof(PlayingCardType));
        design = (PlayingCardType)designValues.GetValue(
            random.Next(designValues.Length-1));
        territory = (TerritoryType)terrValues.GetValue(
            random.Next(terrValues.Length-1));
    }
}
