using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI P1Name; public TextMeshProUGUI P1TotalTroops; public TextMeshProUGUI P1TroopsPerTurn; public RectTransform P1Panel;
    public TextMeshProUGUI P2Name; public TextMeshProUGUI P2TotalTroops; public TextMeshProUGUI P2TroopsPerTurn; public RectTransform P2Panel;
    public TextMeshProUGUI P3Name; public TextMeshProUGUI P3TotalTroops; public TextMeshProUGUI P3TroopsPerTurn; public RectTransform P3Panel;
    public TextMeshProUGUI P4Name; public TextMeshProUGUI P4TotalTroops; public TextMeshProUGUI P4TroopsPerTurn; public RectTransform P4Panel;
    public GameManager gm;
    private int activePlayer = -1;
    private InputControl IC;
    public int currPlayers;
    public List <Player> players = new List<Player>();


    void Start()
    {

    }

    void Awake(){
        currPlayers = GameData.pCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Player NextTurn()
    {
        activePlayer++;
        activePlayer %= players.Count;
        return players[activePlayer];
    }

    private int calcTroopsNextTurn(Player owner){
        int nextTurn = 0;
        List<string> ownedConts = gm.territoryManager.ContinentCheck(owner);
        int allTerrs = gm.territoryManager.getTerritoryCount(owner);
        foreach (string cont in ownedConts){
            nextTurn += gm.territoryManager.getContinentBonus(cont);
        }
        nextTurn += ownedConts.Count / 3;
        return nextTurn;

    }

    public void AddPlayers()
    {
        if (currPlayers > 6) {
            Debug.Log("Maximum players exceeded. Game session has not been created. Players: " + currPlayers);
            return;
        }
        if (currPlayers < 2) {
            Debug.Log("Not enough players for a valid game session. Game session has not been created. Players: " + currPlayers);
            return;
        }

        for (int i=0; i<currPlayers; i++) {
            // get the color based on the player index.
            // e.g. i=0 means color=Color.Red
            PlayerColor color = (PlayerColor)i;

            players.Add(new Player("", color));
        }
        foreach (Player p in players){
            switch (players.Count){
                case (2):
                    p.setArmies(40);
                    break;
                case (3):
                    p.setArmies(35);
                    break;
                case (4):
                    p.setArmies(30);
                    break;
                case (_):
                    throw new ArgumentException("Invalid number of players");
            }
        }
    }

    public List<Player> getPlayers(){
        return players;
    }

    public void SetupGUI(){
        switch (currPlayers){
            case (4):
                //Set colours
                P1TroopsPerTurn.text = calcTroopsNextTurn(players[0]).ToString();
                P2TroopsPerTurn.text = calcTroopsNextTurn(players[1]).ToString();
                P3TroopsPerTurn.text = calcTroopsNextTurn(players[2]).ToString();
                P4TroopsPerTurn.text = calcTroopsNextTurn(players[3]).ToString();

                P1TotalTroops.text = players[0].getArmies().ToString();
                P2TotalTroops.text = players[1].getArmies().ToString();
                P3TotalTroops.text = players[2].getArmies().ToString();
                P4TotalTroops.text = players[3].getArmies().ToString();
                break;

            case (3):
                //Hide P4 Elements
                changeTxtVisi(P4Name,false); P4Panel.localScale = new Vector3(0,0); changeTxtVisi(P4TotalTroops,false); changeTxtVisi(P4TroopsPerTurn,false);
                //Set colours
                P1TroopsPerTurn.text = calcTroopsNextTurn(players[0]).ToString();
                P2TroopsPerTurn.text = calcTroopsNextTurn(players[1]).ToString();
                P3TroopsPerTurn.text = calcTroopsNextTurn(players[2]).ToString();

                P1TotalTroops.text = players[0].getArmies().ToString();
                P2TotalTroops.text = players[1].getArmies().ToString();
                P3TotalTroops.text = players[2].getArmies().ToString();
                break;
            case (2):
                //Set colours
                changeTxtVisi(P4Name,false); P4Panel.localScale = new Vector3(0,0); changeTxtVisi(P4TotalTroops,false); changeTxtVisi(P4TroopsPerTurn,false);
                changeTxtVisi(P3Name,false); P3Panel.localScale = new Vector3(0,0); changeTxtVisi(P3TotalTroops,false); changeTxtVisi(P3TroopsPerTurn,false);
                //Set colours
                P1TroopsPerTurn.text = calcTroopsNextTurn(players[0]).ToString();
                P2TroopsPerTurn.text = calcTroopsNextTurn(players[1]).ToString();

                P1TotalTroops.text = players[0].getArmies().ToString();
                P2TotalTroops.text = players[1].getArmies().ToString();
                break;
        }

        
    }
    private void changeEleInt(TextMeshProUGUI element,int i){
        element.text = i.ToString();
    }
    private void changeTxtVisi(TextMeshProUGUI text, bool vis){
        Color c = text.color;
        if (vis){
            c.a = 1;
        }
        else{
            c.a = 0;
        }
        text.color = c;
    }

}
