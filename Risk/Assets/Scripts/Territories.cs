using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TerritoryColour : int
{
    RED = 0,
    BLUE = 1,
    GREEN = 2,
    ORANGE = 3,
    PURPLE = 4,
    YELLOW = 5
}

public enum TerritoryType: int
{
    ALASKA,
    ALBERTA,
    ONTARIO,
    WESTERN_AMERICA,
    EASTERN_AMERICA,
    QUEBEC,
    CENTRAL_AMERICA,
    GREENLAND,
    NORTHWEST_AMERICA,
    BRAZIL,
    VENEZUELA,
    PERU,
    ARGENTINA,
    WESTERN_AUSTRALIA,
    EASTERN_AUSTRALIA,
    INDONESIA,
    PAPUA_NEW_GUINEA,
    UKRAINE,
    SKANDINAVIA,
    ICELAND,
    GREAT_BRITAIN,
    NORTHERN_EUROPE,
    WESTERN_EUROPE,
    SOUTHERN_EUROPE,
    YAKUTSK,
    SIBERIA,
    KAMCHATKA,
    IRKUTSK,
    URAL,
    JAPAN,
    MONGOLIA,
    CHINA,
    MIDDLE_EAST,
    INDIA,
    SIAM,
    AFGANISTAN,
    EAST_AFRICA,
    EGYPT,
    CONGO,
    MADAGASCAR,
    SOUTH_AFRICA,
    NORTH_AFRICA
}

public class Territories : MonoBehaviour
{
    public static int nTerritories = 46;


    public Dictionary<TerritoryType, Territory> territories = new Dictionary<TerritoryType, Territory>();
    
    private Dictionary<TerritoryType,TerritoryType[]> adjacent = new Dictionary<TerritoryType,TerritoryType[]>(){
            {TerritoryType.ALASKA, new TerritoryType[] {TerritoryType.KAMCHATKA,TerritoryType.NORTHWEST_AMERICA,TerritoryType.ALBERTA }},
            {TerritoryType.ALBERTA, new TerritoryType[] {TerritoryType.ALASKA,TerritoryType.NORTHWEST_AMERICA,TerritoryType.ONTARIO,TerritoryType.WESTERN_AMERICA }},
            {TerritoryType.ONTARIO, new TerritoryType[] {TerritoryType.ALBERTA,TerritoryType.QUEBEC,TerritoryType.EASTERN_AMERICA,TerritoryType.WESTERN_AMERICA,TerritoryType.NORTHWEST_AMERICA,TerritoryType.GREENLAND}},
            {TerritoryType.WESTERN_AMERICA, new TerritoryType[] {TerritoryType.CENTRAL_AMERICA,TerritoryType.EASTERN_AMERICA,TerritoryType.ONTARIO,TerritoryType.ALBERTA }},
            {TerritoryType.EASTERN_AMERICA, new TerritoryType[] {TerritoryType.CENTRAL_AMERICA,TerritoryType.WESTERN_AMERICA,TerritoryType.ONTARIO,TerritoryType.QUEBEC }},
            {TerritoryType.QUEBEC, new TerritoryType[] { TerritoryType.EASTERN_AMERICA,TerritoryType.ONTARIO,TerritoryType.GREENLAND}},
            {TerritoryType.CENTRAL_AMERICA, new TerritoryType[] {TerritoryType.VENEZUELA,TerritoryType.WESTERN_AMERICA,TerritoryType.EASTERN_AMERICA}},
            {TerritoryType.GREENLAND, new TerritoryType[] {TerritoryType.QUEBEC,TerritoryType.ONTARIO,TerritoryType.NORTHWEST_AMERICA,TerritoryType.ICELAND }},
            {TerritoryType.NORTHWEST_AMERICA, new TerritoryType[] {TerritoryType.ALBERTA,TerritoryType.ONTARIO,TerritoryType.GREENLAND,TerritoryType.ALASKA }},
            {TerritoryType.BRAZIL, new TerritoryType[] {TerritoryType.ARGENTINA,TerritoryType.PERU,TerritoryType.VENEZUELA,TerritoryType.NORTH_AFRICA }},
            {TerritoryType.VENEZUELA, new TerritoryType[] { TerritoryType.CENTRAL_AMERICA,TerritoryType.PERU,TerritoryType.BRAZIL}},
            {TerritoryType.PERU, new TerritoryType[] {TerritoryType.ARGENTINA,TerritoryType.BRAZIL,TerritoryType.VENEZUELA }},
            {TerritoryType.ARGENTINA, new TerritoryType[] { TerritoryType.PERU,TerritoryType.BRAZIL}},
            {TerritoryType.WESTERN_AUSTRALIA, new TerritoryType[] {TerritoryType.INDONESIA,TerritoryType.PAPUA_NEW_GUINEA,TerritoryType.EASTERN_AUSTRALIA }},
            {TerritoryType.EASTERN_AUSTRALIA, new TerritoryType[] {TerritoryType.WESTERN_AUSTRALIA,TerritoryType.PAPUA_NEW_GUINEA }},
            {TerritoryType.INDONESIA, new TerritoryType[] {TerritoryType.WESTERN_AUSTRALIA,TerritoryType.PAPUA_NEW_GUINEA,TerritoryType.SIAM }},
            {TerritoryType.PAPUA_NEW_GUINEA, new TerritoryType[] {TerritoryType.EASTERN_AUSTRALIA,TerritoryType.WESTERN_AUSTRALIA,TerritoryType.INDONESIA }},
            {TerritoryType.UKRAINE, new TerritoryType[] { TerritoryType.MIDDLE_EAST,TerritoryType.AFGANISTAN,TerritoryType.URAL,TerritoryType.SOUTHERN_EUROPE,TerritoryType.NORTHERN_EUROPE,TerritoryType.SKANDINAVIA}},
            {TerritoryType.SKANDINAVIA, new TerritoryType[] { TerritoryType.GREAT_BRITAIN,TerritoryType.NORTHERN_EUROPE,TerritoryType.UKRAINE,TerritoryType.ICELAND}},
            {TerritoryType.ICELAND, new TerritoryType[] { TerritoryType.GREAT_BRITAIN,TerritoryType.GREENLAND, TerritoryType.SKANDINAVIA}},
            {TerritoryType.GREAT_BRITAIN, new TerritoryType[] {TerritoryType.WESTERN_EUROPE,TerritoryType.NORTHERN_EUROPE,TerritoryType.SKANDINAVIA,TerritoryType.ICELAND}},
            {TerritoryType.NORTHERN_EUROPE, new TerritoryType[] { TerritoryType.SOUTHERN_EUROPE,TerritoryType.WESTERN_EUROPE,TerritoryType.UKRAINE,TerritoryType.SKANDINAVIA,TerritoryType.GREAT_BRITAIN}},
            {TerritoryType.WESTERN_EUROPE, new TerritoryType[] { TerritoryType.NORTH_AFRICA,TerritoryType.SOUTHERN_EUROPE,TerritoryType.NORTHERN_EUROPE,TerritoryType.GREAT_BRITAIN}},
            {TerritoryType.SOUTHERN_EUROPE, new TerritoryType[] { TerritoryType.NORTH_AFRICA,TerritoryType.EGYPT,TerritoryType.MIDDLE_EAST,TerritoryType.UKRAINE,TerritoryType.NORTHERN_EUROPE,TerritoryType.WESTERN_EUROPE}},
            {TerritoryType.YAKUTSK, new TerritoryType[] { TerritoryType.IRKUTSK,TerritoryType.KAMCHATKA,TerritoryType.SIBERIA}},
            {TerritoryType.SIBERIA, new TerritoryType[] { TerritoryType.CHINA,TerritoryType.MONGOLIA,TerritoryType.IRKUTSK,TerritoryType.YAKUTSK,TerritoryType.URAL}},
            {TerritoryType.KAMCHATKA, new TerritoryType[] { TerritoryType.ALASKA,TerritoryType.YAKUTSK,TerritoryType.IRKUTSK,TerritoryType.MONGOLIA,TerritoryType.JAPAN}},
            {TerritoryType.IRKUTSK, new TerritoryType[] { TerritoryType.MONGOLIA,TerritoryType.KAMCHATKA,TerritoryType.YAKUTSK,TerritoryType.SIBERIA}},
            {TerritoryType.URAL, new TerritoryType[] { TerritoryType.AFGANISTAN,TerritoryType.CHINA,TerritoryType.SIBERIA,TerritoryType.UKRAINE}},
            {TerritoryType.JAPAN, new TerritoryType[] { TerritoryType.MONGOLIA,TerritoryType.KAMCHATKA}},
            {TerritoryType.MONGOLIA, new TerritoryType[] { TerritoryType.CHINA,TerritoryType.SIBERIA,TerritoryType.IRKUTSK,TerritoryType.KAMCHATKA,TerritoryType.JAPAN}},
            {TerritoryType.CHINA, new TerritoryType[] { TerritoryType.SIAM,TerritoryType.INDIA,TerritoryType.AFGANISTAN,TerritoryType.URAL,TerritoryType.SIBERIA,TerritoryType.MONGOLIA}},
            {TerritoryType.MIDDLE_EAST, new TerritoryType[] { TerritoryType.EGYPT,TerritoryType.EAST_AFRICA,TerritoryType.INDIA,TerritoryType.AFGANISTAN,TerritoryType.UKRAINE,TerritoryType.SOUTHERN_EUROPE}},
            {TerritoryType.INDIA, new TerritoryType[] { TerritoryType.SIAM,TerritoryType.CHINA,TerritoryType.AFGANISTAN,TerritoryType.MIDDLE_EAST}},
            {TerritoryType.SIAM, new TerritoryType[] { TerritoryType.INDONESIA,TerritoryType.CHINA,TerritoryType.INDIA}},
            {TerritoryType.AFGANISTAN, new TerritoryType[] { TerritoryType.MIDDLE_EAST,TerritoryType.INDIA,TerritoryType.CHINA,TerritoryType.SIBERIA,TerritoryType.URAL,TerritoryType.UKRAINE}},
            {TerritoryType.EAST_AFRICA, new TerritoryType[] { TerritoryType.SOUTH_AFRICA,TerritoryType.CONGO,TerritoryType.NORTH_AFRICA,TerritoryType.EGYPT,TerritoryType.MADAGASCAR}},
            {TerritoryType.EGYPT, new TerritoryType[] { TerritoryType.NORTH_AFRICA,TerritoryType.EAST_AFRICA,TerritoryType.MIDDLE_EAST,TerritoryType.SOUTHERN_EUROPE}},
            {TerritoryType.CONGO, new TerritoryType[] { TerritoryType.SOUTH_AFRICA,TerritoryType.NORTH_AFRICA,TerritoryType.EAST_AFRICA}},
            {TerritoryType.MADAGASCAR, new TerritoryType[] { TerritoryType.SOUTH_AFRICA,TerritoryType.EAST_AFRICA}},
            {TerritoryType.SOUTH_AFRICA, new TerritoryType[] { TerritoryType.MADAGASCAR,TerritoryType.EAST_AFRICA,TerritoryType.CONGO}},
            {TerritoryType.NORTH_AFRICA, new TerritoryType[] { TerritoryType.WESTERN_EUROPE,TerritoryType.SOUTHERN_EUROPE,TerritoryType.EGYPT,TerritoryType.EAST_AFRICA,TerritoryType.CONGO}},
    };

    private Dictionary<string,(TerritoryType[],int)> continents = new Dictionary<string,(TerritoryType[],int)>(){
        {"s_america", (new TerritoryType[] {TerritoryType.ARGENTINA, TerritoryType.PERU, TerritoryType.BRAZIL, TerritoryType.VENEZUELA}, 3)},
        {"n_america", (new TerritoryType[] {TerritoryType.CENTRAL_AMERICA, TerritoryType.EASTERN_AMERICA, TerritoryType.WESTERN_AMERICA, TerritoryType.QUEBEC, TerritoryType.ONTARIO, TerritoryType.ALBERTA, TerritoryType.ALASKA, TerritoryType.NORTHWEST_AMERICA, TerritoryType.GREENLAND}, 5)},
        {"europe", (new TerritoryType[] {TerritoryType.WESTERN_EUROPE, TerritoryType.SOUTHERN_EUROPE, TerritoryType.UKRAINE, TerritoryType.NORTHERN_EUROPE, TerritoryType.SKANDINAVIA, TerritoryType.ICELAND, TerritoryType.GREAT_BRITAIN}, 5)},
        {"africa", (new TerritoryType[] {TerritoryType.SOUTH_AFRICA, TerritoryType.CONGO, TerritoryType.MADAGASCAR, TerritoryType.EAST_AFRICA, TerritoryType.EGYPT, TerritoryType.NORTH_AFRICA}, 3)},
        {"asia", (new TerritoryType[] {TerritoryType.MIDDLE_EAST, TerritoryType.INDIA, TerritoryType.SIAM, TerritoryType.CHINA, TerritoryType.AFGANISTAN, TerritoryType.MONGOLIA, TerritoryType.JAPAN, TerritoryType.URAL, TerritoryType.SIBERIA, TerritoryType.IRKUTSK, TerritoryType.YAKUTSK, TerritoryType.KAMCHATKA}, 7)},
        {"australia", (new TerritoryType[] {TerritoryType.WESTERN_AUSTRALIA, TerritoryType.EASTERN_AUSTRALIA, TerritoryType.PAPUA_NEW_GUINEA, TerritoryType.INDONESIA}, 2)}
    };

    private UnityEngine.Color[] colours = {
        UnityEngine.Color.red,
        UnityEngine.Color.blue,
        UnityEngine.Color.green,
        new UnityEngine.Color(1f, 0.5f, 0f),
        new UnityEngine.Color(0.5f, 0f, 0.5f),
        UnityEngine.Color.yellow,
        UnityEngine.Color.white
    };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Territory[] ReshuffleTerritories(Territory[] territories)
    {
        // knuth shuffle algorithm
        for (int t = 0; t < territories.Length; t++ )
        {
            Territory tmp = territories[t];
            int r = UnityEngine.Random.Range(t, territories.Length);
            territories[t] = territories[r];
            territories[r] = tmp;
        }

        return territories;
    }

    public void GenerateTerritories(List<Player> players)
    {   
        var foundTerritories = FindObjectsOfType<Territory>();
        foundTerritories = ReshuffleTerritories(foundTerritories);

        for (int i=0; i<foundTerritories.Length; i++) {
            // add the territory to the territory list.
            territories[foundTerritories[i].territoryType] = foundTerritories[i];
            Debug.Log("Found territory " + foundTerritories[i].territoryType);
        }
        Debug.Log("Found " + foundTerritories.Length + " territories.");

        List<(Territory,Player)> ownerList = new List<(Territory,Player)>();
        Queue<Player> queue = new Queue<Player>(players);
        Debug.Log(players.Count);
        Debug.Log(queue.Count);

        int idx = 0;
        foreach (var item in territories) {
            if (idx >= players.Count)
                idx = 0;
            Player playerUsed = players[idx];
            Territory territory = item.Value;
            territory.setOwner(playerUsed);
            territory.armies = UnityEngine.Random.Range(1,4);
            ownerList.Add((territory, playerUsed));
            Debug.Log("Player: " + playerUsed.id + " Colour IDX: " + playerUsed.colour + " Player Array Index: "+ idx);
            territory.SetColour(colours[idx]);
            //queue.Enqueue(playerUsed);
            idx++;

            Debug.Log("Territory " + territory.territoryType + " got " + territory.armies + " armies.");
        }
    }



    public UnityEngine.Color GetRandomColor()
    {

        int randomIndex = UnityEngine.Random.Range(0, colours.Length);
        return colours[randomIndex];
    }

    public List<string> ContinentCheck(Player p)
    {
        List<string> continentsOwned = new List<string>();
        

        foreach (var continent in continents)
        {
            bool ownsAll = true;  
            string continentName = continent.Key;
            TerritoryType[] territoriesInContinent = continent.Value.Item1; 
            foreach (TerritoryType te in territoriesInContinent)
            {

                if (territories[te].getOwner() != p)
                {
                    ownsAll = false;
                    break;
                }
            }

            if (ownsAll)
            {
                continentsOwned.Add(continentName);
            }
        }

        return continentsOwned;
    }

    public int getContinentBonus(string continent)
    {
        switch (continent)
        {
            case "s_america":
                return 2;
            case "australia":
                return 2;
            case "n_america":
                return 5;
            case "europe":
                return 5;
            case "africa":
                return 3;
            case "asia":
                return 7;
            default:
                throw new ArgumentException("Invalid continent name provided.", "continent");
        }
    }

    public int getTerritoryCount(Player p){
        int totalTerr = 0;
        foreach (KeyValuePair<TerritoryType, Territory> entry in territories){
            if (entry.Value.getOwner() == p){
                totalTerr++;
            }
        }
        return totalTerr;
    }
}

