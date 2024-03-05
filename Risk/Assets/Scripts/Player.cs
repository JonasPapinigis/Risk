using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public enum Color
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
    public int PlayerId { get; set; }
    public string Name { get; set; }
    public Color Colour { get; set; }

    private List<Territory> territories = new List<Territory>();
    private List<Card> cards = new List<Card>();
    private int armies;
    private int ownedTerritories; // Tracks the number of territories owned
    private int ownedInfantries; // Tracks the number of infantry units owned
    private PlayingCard[] ownedPlayingCards; // Existing Unity-based property for playing cards

    public Player(int playerId, string name, Color colour)
    {
        PlayerId = playerId;
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
            territory.Armies += numberOfArmies;
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