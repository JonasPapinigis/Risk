
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class manages the colour of each individual territory.
 *
 * cubeRenderer - a reference to 
 */
public class Territory : MonoBehaviour
{   
    private SpriteRenderer renderer;
    public Material defaultMaterial;    
    public int armies = 1;
    public TerritoryType terr;
    public Player owner;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    // NB: Hacky, I don't like it
    void EnsureSpriteRenderer()
    {

        renderer = GetComponent<SpriteRenderer>();
        // we need to ensure that instances have a cube renderer.
        // NB: this is just temporary until individual meshes for each country
        // are added.
        if (renderer == null) {
            renderer = gameObject.AddComponent<SpriteRenderer>();
            //cubeRenderer.material = defaultMaterial;
        }
    }

    void setOwner(Player player){
        owner = player;
    }

    void SetColour(){}

}
