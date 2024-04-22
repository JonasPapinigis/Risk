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

public class Player
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
        colour = colour;
        armies = 0;
        ownedTerritories = 0;
        ownedInfantries = 0;
    }


    public void setArmies(int i){
        armies = i;
    }

    public void incrementArmies(int i){
        armies += i;
    }

    public int getArmies(){
        return armies;
    }

}
