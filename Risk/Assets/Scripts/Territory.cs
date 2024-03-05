
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
    private int placedInfantries;
    public TerritoryType terr;

    // Start is called before the first frame update
    void Start()
    {
        EnsureSpriteRenderer();
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

    public void SetColour(Color colour)
    {
        EnsureSpriteRenderer();
        cubeRenderer.color = colour;
    }
}
