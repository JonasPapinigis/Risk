using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor
{
    Red,
    Blue,
    Green,
    Yellow,
    Purple,
    Pink
}

public class Player : MonoBehaviour
{

    public string Name { get; set; }
    public PlayerColor colour { get; set; }

    private List<Territory> territories = new List<Territory>();
    private List<PlayingCard> cards = new List<PlayingCard>();
    private int armies;
    private int ownedTerritories; // Tracks the number of territories owned
    private int ownedInfantries; // Tracks the number of infantry units owned
    private PlayingCard[] ownedPlayingCards; // Existing Unity-based property for playing cards

    public Player(string name="", PlayerColor colour=PlayerColor.Red)
    {
        Name = name;
        Colour = colour;
        armies = 0;
        ownedTerritories = 0;
        ownedInfantries = 0;
    }

    public void AddTerritory(Territory territory)
    {
        territories.Add(territory);
        ownedTerritories++; // Increment the ownedTerritories counter
    }

    public void RemoveTerritory(Territory territory)
    {
        territories.Remove(territory);
        ownedTerritories--; // Decrement the ownedTerritories counter
    }

    public void DeployArmies(Territory territory, int numberOfArmies)
    {
        if (territories.Contains(territory) && numberOfArmies <= armies)
        {
            territory.armies += numberOfArmies;
            armies -= numberOfArmies;
            ownedInfantries += numberOfArmies; // Update the ownedInfantries counter
        }
    }

    public bool EnsurePlayerAlive()
    {
        return territories.Count > 0; // Updated to use the list for a more accurate count
    }

    public bool CanUsePlayingCards()
    {
        // Implementation depends on your game's mechanics
        return cards.Count > 0; // Example condition
    }

    // Placeholder for the Unity MonoBehaviour Start and Update methods
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Additional functionality and methods can be added here
}
