
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/*
 * This class manages the colour of each individual territory.
 *
 * cubeRenderer - a reference to 
 */
public class Territory : MonoBehaviour  , IPointerEnterHandler, IPointerExitHandler//,IPointerClickHandler
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
        //SetColour(PlayerColor);
    }

    // Update is called once per frame
    void Update()
    {
        TMP_Text textComponent = ArmyCounter.GetComponent<TMP_Text>();
        textComponent.text = armies.ToString();
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

    public void isHovered(bool hovered){

        Color color = renderer.material.color;
        if (hovered){
        color += new Color(0.1f,0.1f,0.1f,0.1f);
        }
        else{
            color -= new Color(0.1f,0.1f,0.1f,0.1f);
        }
        renderer.material.color = color;
    }

    public void OnPointerEnter(PointerEventData eventData){
        isHovered(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        isHovered(false);
    }

    public void setOwner(Player player){
        owner = player; 
    }

    public void SetColour(UnityEngine.Color color){
        EnsureSpriteRenderer();
        
        PlayerColor = color;
        if (PlayerColor == Color.clear){
            Debug.Log("Invalid player colour, setting to white.");
            renderer.color = Color.white;
            Debug.Log("" + PlayerColor);
            //SetColour(PlayerColor);
            
        }
        else {
            Debug.Log("Set " + territoryType + " to " + PlayerColor);
            renderer.color = PlayerColor;
            
        }
    }

    public void SetType(TerritoryType type){
        territoryType = type;
    }

    private void Awake()
    {
        //armies = Random.Range(1, 4);
        ArmyCounter = GetComponent<TMP_Text>();
        ArmyCounter.text = armies.ToString();
    }
    public Player getOwner(){
        return owner;
    }

}
