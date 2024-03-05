using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    ALASKA = 0,
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
    public int nTerritories = 46;
    public GameObject territoryPrefab;
    private Dictionary<TerritoryType,TerritoryType[]> adjacent = new Dictionary<TerritoryType,TerritoryType[]>(){
            (TerritoryType.ALASKA, new TerritoryType[] {TerritoryType.KAMCHATKA,TerritoryType.NORTHWEST_AMERICA,TerritoryType.ALBERTA }),
            (TerritoryType.ALBERTA, new TerritoryType[] {TerritoryType.ALASKA,TerritoryType.NORTHWEST_AMERICA,TerritoryType.ONTARIO,TerritoryType.WESTERN_AMERICA }),
            (TerritoryType.ONTARIO, new TerritoryType[] {TerritoryType.ALBERTA,TerritoryType.QUEBEC,TerritoryType.EASTERN_AMERICA,TerritoryType.WESTERN_AMERICA,TerritoryType.NORTHWEST_AMERICA,TerritoryType.GREENLAND}),
            (TerritoryType.WESTERN_AMERICA, new TerritoryType[] {TerritoryType.CENTRAL_AMERICA,TerritoryType.EASTERN_AMERICA,TerritoryType.ONTARIO,TerritoryType.ALBERTA }),
            (TerritoryType.EASTERN_AMERICA, new TerritoryType[] {TerritoryType.CENTRAL_AMERICA,TerritoryType.WESTERN_AMERICA,TerritoryType.ONTARIO,TerritoryType.QUEBEC }),
            (TerritoryType.QUEBEC, new TerritoryType[] { TerritoryType.EASTERN_AMERICA,TerritoryType.ONTARIO,TerritoryType.GREENLAND}),
            (TerritoryType.CENTRAL_AMERICA, new TerritoryType[] {TerritoryType.VENEZUELA,TerritoryType.WESTERN_AMERICA,TerritoryType.EASTERN_AMERICA}),
            (TerritoryType.GREENLAND, new TerritoryType[] {TerritoryType.QUEBEC,TerritoryType.ONTARIO,TerritoryType.NORTHWEST_AMERICA,TerritoryType.ICELAND }),
            (TerritoryType.NORTHWEST_AMERICA, new TerritoryType[] {TerritoryType.ALBERTA,TerritoryType.ONTARIO,TerritoryType.GREENLAND,TerritoryType.ALASKA }),
            (TerritoryType.BRAZIL, new TerritoryType[] {TerritoryType.ARGENTINA,TerritoryType.PERU,TerritoryType.VENEZUELA,TerritoryType.NORTH_AFRICA }),
            (TerritoryType.VENEZUELA, new TerritoryType[] { TerritoryType.CENTRAL_AMERICA,TerritoryType.PERU,TerritoryType.BRAZIL}),
            (TerritoryType.PERU, new TerritoryType[] {TerritoryType.ARGENTINA,TerritoryType.BRAZIL,TerritoryType.VENEZUELA }),
            (TerritoryType.ARGENTINA, new TerritoryType[] { TerritoryType.PERU,TerritoryType.BRAZIL}),
            (TerritoryType.WESTERN_AUSTRALIA, new TerritoryType[] {TerritoryType.INDONESIA,TerritoryType.PAPUA_NEW_GUINEA,TerritoryType.EASTERN_AUSTRALIA }),
            (TerritoryType.EASTERN_AUSTRALIA, new TerritoryType[] {TerritoryType.WESTERN_AUSTRALIA,TerritoryType.PAPUA_NEW_GUINEA }),
            (TerritoryType.INDONESIA, new TerritoryType[] {TerritoryType.WESTERN_AUSTRALIA,TerritoryType.PAPUA_NEW_GUINEA,TerritoryType.SIAM }),
            (TerritoryType.PAPUA_NEW_GUINEA, new TerritoryType[] {TerritoryType.EASTERN_AUSTRALIA,TerritoryType.WESTERN_AUSTRALIA,TerritoryType.INDONESIA }),
            (TerritoryType.UKRAINE, new TerritoryType[] { TerritoryType.MIDDLE_EAST,TerritoryType.AFGANISTAN,TerritoryType.URAL,TerritoryType.SOUTHERN_EUROPE,TerritoryType.NORTHERN_EUROPE,TerritoryType.SKANDINAVIA}),
            (TerritoryType.SKANDINAVIA, new TerritoryType[] { TerritoryType.GREAT_BRITAIN,TerritoryType.NORTHERN_EUROPE,TerritoryType.UKRAINE,TerritoryType.ICELAND}),
            (TerritoryType.ICELAND, new TerritoryType[] { TerritoryType.GREAT_BRITAIN,TerritoryType.GREENLAND, TerritoryType.SKANDINAVIA}),
            (TerritoryType.GREAT_BRITAIN, new TerritoryType[] {TerritoryType.WESTERN_EUROPE,TerritoryType.NORTHERN_EUROPE,TerritoryType.SKANDINAVIA,TerritoryType.ICELAND}),
            (TerritoryType.NORTHERN_EUROPE, new TerritoryType[] { TerritoryType.SOUTHERN_EUROPE,TerritoryType.WESTERN_EUROPE,TerritoryType.UKRAINE,TerritoryType.SKANDINAVIA,TerritoryType.GREAT_BRITAIN}),
            (TerritoryType.WESTERN_EUROPE, new TerritoryType[] { TerritoryType.NORTH_AFRICA,TerritoryType.SOUTHERN_EUROPE,TerritoryType.NORTHERN_EUROPE,TerritoryType.GREAT_BRITAIN}),
            (TerritoryType.SOUTHERN_EUROPE, new TerritoryType[] { TerritoryType.NORTH_AFRICA,TerritoryType.EGYPT,TerritoryType.MIDDLE_EAST,TerritoryType.UKRAINE,TerritoryType.NORTHERN_EUROPE,TerritoryType.WESTERN_EUROPE}),
            (TerritoryType.YAKUTSK, new TerritoryType[] { TerritoryType.IRKUTSK,TerritoryType.KAMCHATKA,TerritoryType.SIBERIA}),
            (TerritoryType.SIBERIA, new TerritoryType[] { TerritoryType.CHINA,TerritoryType.MONGOLIA,TerritoryType.IRKUTSK,TerritoryType.YAKUTSK,TerritoryType.URAL}),
            (TerritoryType.KAMCHATKA, new TerritoryType[] { TerritoryType.ALASKA,TerritoryType.YAKUTSK,TerritoryType.IRKUTSK,TerritoryType.MONGOLIA,TerritoryType.JAPAN}),
            (TerritoryType.IRKUTSK, new TerritoryType[] { TerritoryType.MONGOLIA,TerritoryType.KAMCHATKA,TerritoryType.YAKUTSK,TerritoryType.SIBERIA}),
            (TerritoryType.URAL, new TerritoryType[] { TerritoryType.AFGANISTAN,TerritoryType.CHINA,TerritoryType.SIBERIA,TerritoryType.UKRAINE}),
            (TerritoryType.JAPAN, new TerritoryType[] { TerritoryType.MONGOLIA,TerritoryType.KAMCHATKA}),
            (TerritoryType.MONGOLIA, new TerritoryType[] { TerritoryType.CHINA,TerritoryType.SIBERIA,TerritoryType.IRKUTSK,TerritoryType.KAMCHATKA,TerritoryType.JAPAN}),
            (TerritoryType.CHINA, new TerritoryType[] { TerritoryType.SIAM,TerritoryType.INDIA,TerritoryType.AFGANISTAN,TerritoryType.URAL,TerritoryType.SIBERIA,TerritoryType.MONGOLIA}),
            (TerritoryType.MIDDLE_EAST, new TerritoryType[] { TerritoryType.EGYPT,TerritoryType.EAST_AFRICA,TerritoryType.INDIA,TerritoryType.AFGANISTAN,TerritoryType.UKRAINE,TerritoryType.SOUTHERN_EUROPE}),
            (TerritoryType.INDIA, new TerritoryType[] { TerritoryType.SIAM,TerritoryType.CHINA,TerritoryType.AFGANISTAN,TerritoryType.MIDDLE_EAST}),
            (TerritoryType.SIAM, new TerritoryType[] { TerritoryType.INDONESIA,TerritoryType.CHINA,TerritoryType.INDIA}),
            (TerritoryType.AFGANISTAN, new TerritoryType[] { TerritoryType.MIDDLE_EAST,TerritoryType.INDIA,TerritoryType.CHINA,TerritoryType.SIBERIA,TerritoryType.URAL,TerritoryType.UKRAINE}),
            (TerritoryType.EAST_AFRICA, new TerritoryType[] { TerritoryType.SOUTH_AFRICA,TerritoryType.CONGO,TerritoryType.NORTH_AFRICA,TerritoryType.EGYPT,TerritoryType.MADAGASCAR}),
            (TerritoryType.EGYPT, new TerritoryType[] { TerritoryType.NORTH_AFRICA,TerritoryType.EAST_AFRICA,TerritoryType.MIDDLE_EAST,TerritoryType.SOUTHERN_EUROPE}),
            (TerritoryType.CONGO, new TerritoryType[] { TerritoryType.SOUTH_AFRICA,TerritoryType.NORTH_AFRICA,TerritoryType.EAST_AFRICA}),
            (TerritoryType.MADAGASCAR, new TerritoryType[] { TerritoryType.SOUTH_AFRICA,TerritoryType.EAST_AFRICA}),
            (TerritoryType.SOUTH_AFRICA, new TerritoryType[] { TerritoryType.MADAGASCAR,TerritoryType.EAST_AFRICA,TerritoryType.CONGO}),
            (TerritoryType.NORTH_AFRICA, new TerritoryType[] { TerritoryType.WESTERN_EUROPE,TerritoryType.SOUTHERN_EUROPE,TerritoryType.EGYPT,TerritoryType.EAST_AFRICA,TerritoryType.CONGO}),
    };

    private Dictionary<string,(TerritoryType[],int)> continents = new Dictionary<string,(TerritoryType[],int)>(){
        ("s_america", (new TerritoryType[] {TerritoryType.ARGENTINA, TerritoryType.PERU, TerritoryType.BRAZIL, TerritoryType.VENEZUELA}, 3)),
        ("n_america", (new TerritoryType[] {TerritoryType.CENTRAL_AMERICA, TerritoryType.EASTERN_AMERICA, TerritoryType.WESTERN_AMERICA, TerritoryType.QUEBEC, TerritoryType.ONTARIO, TerritoryType.ALBERTA, TerritoryType.ALASKA, TerritoryType.NORTHWEST_AMERICA, TerritoryType.GREENLAND}, 5)),
        ("europe", (new TerritoryType[] {TerritoryType.WESTERN_EUROPE, TerritoryType.SOUTHERN_EUROPE, TerritoryType.UKRAINE, TerritoryType.NORTHERN_EUROPE, TerritoryType.SKANDINAVIA, TerritoryType.ICELAND, TerritoryType.GREAT_BRITAIN}, 5)),
        ("africa", (new TerritoryType[] {TerritoryType.SOUTH_AFRICA, TerritoryType.CONGO, TerritoryType.MADAGASCAR, TerritoryType.EAST_AFRICA, TerritoryType.EGYPT, TerritoryType.NORTH_AFRICA}, 3)),
        ("asia", (new TerritoryType[] {TerritoryType.MIDDLE_EAST, TerritoryType.INDIA, TerritoryType.SIAM, TerritoryType.CHINA, TerritoryType.AFGANISTAN, TerritoryType.MONGOLIA, TerritoryType.JAPAN, TerritoryType.URAL, TerritoryType.SIBERIA, TerritoryType.IRKUTSK, TerritoryType.YAKUTSK, TerritoryType.KAMCHATKA}, 7)),
        ("australia", (new TerritoryType[] {TerritoryType.WESTERN_AUSTRALIA, TerritoryType.EASTERN_AUSTRALIA, TerritoryType.PAPUA_NEW_GUINEA, TerritoryType.INDONESIA}, 2))
    };

    private Color[] colours = {
        Color.red,
        Color.blue,
        Color.green,
        new Color(1f, 0.5f, 0f),
        new Color(0.5f, 0f, 0.5f),
        Color.yellow,
        Color.white
    };

    // Start is called before the first frame update
    void Start()
    {
        GenerateTerritories();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateTerritories()
    {
        for (int i=0; i<nTerritories; i++) {
            GameObject territoryObject = Instantiate(
                territoryPrefab,
                new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)), // Randomize position
                Quaternion.identity);
            Territory territory = territoryObject.GetComponent<Territory>();

            
            if (territory != null)
                territory.SetColour(GetRandomColor());
            else
                Debug.Log("BAAAHAA");
        }
    }

    Color GetRandomColor()
    {
        int randomIndex = Random.Range(0, colours.Length);
        return colours[randomIndex];
    }
}
