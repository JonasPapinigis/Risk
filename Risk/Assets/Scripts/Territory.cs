
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
    private MeshRenderer cubeRenderer;
    public Material defaultMaterial;    
    private int placedInfantries;
    public TerritoryType terr;

    // Start is called before the first frame update
    void Start()
    {
        EnsureMeshRenderer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // NB: Hacky, I don't like it
    void EnsureMeshRenderer()
    {

        cubeRenderer = GetComponent<MeshRenderer>();
        // we need to ensure that instances have a cube renderer.
        // NB: this is just temporary until individual meshes for each country
        // are added.
        if (cubeRenderer == null) {
            cubeRenderer = gameObject.AddComponent<MeshRenderer>();
            //cubeRenderer.material = defaultMaterial;
        }
    }

    public void SetColour(Color colour)
    {
        EnsureMeshRenderer();
        cubeRenderer.material.color = colour;
    }
}
