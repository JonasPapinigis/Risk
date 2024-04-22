
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This class manages the colour of each individual territory.
 *
 * cubeRenderer - a reference to 
 */
public class Territory : MonoBehaviour
{   
    public TerritoryType territoryType;
    private SpriteRenderer renderer;
    public Material defaultMaterial;    
    public int armies = 1;
    public TerritoryType terr;
    public Player owner;
    public Color PlayerColor;
    public TMP_Text ArmyCounter;

    // Start is called before the first frame update
    void Start()
    {
        EnsureSpriteRenderer();
        SetColour(PlayerColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // NB: Hacky, I don't like it
    void EnsureSpriteRenderer()
    {

        renderer = GetComponent<SpriteRenderer>();
        // we need to ensure that instances have a SpriteRenderer.
        // NB: this is just temporary until individual meshes for each country
        // are added.
        if (renderer == null) {
            renderer = gameObject.AddComponent<SpriteRenderer>();
            renderer.material = defaultMaterial; // Corrected reference to renderer
        }
    }

    public void setOwner(Player player){
        owner = player; 
    }

    void SetColour(Color color){
        if (PlayerColor == Color.clear){
            renderer.color = Color.white; 
        }
        else {
            renderer.color = PlayerColor;
        }
    }

    public void SetType(TerritoryType type){
        terr = type;
    }

    private void Awake()
    {
        armies = Random.Range(1, 4);
        ArmyCounter = GetComponent<TMP_Text>();
        ArmyCounter.text = armies.ToString();
         
    }

}
