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
