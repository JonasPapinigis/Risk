using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI P1Name; public TextMeshProUGUI P1TotalTroops; public TextMeshProUGUI P1TroopsPerTurn; public RectTransform P1Panel;
    public TextMeshProUGUI P2Name; public TextMeshProUGUI P2TotalTroops; public TextMeshProUGUI P2TroopsPerTurn; public RectTransform P2Panel;
    public TextMeshProUGUI P3Name; public TextMeshProUGUI P3TotalTroops; public TextMeshProUGUI P3TroopsPerTurn; public RectTransform P3Panel;
    public TextMeshProUGUI P4Name; public TextMeshProUGUI P4TotalTroops; public TextMeshProUGUI P4TroopsPerTurn; public RectTransform P4Panel;
    public GameManager gm;
    private int activePlayer = -1;
    public int currPlayers = InputManager.pCount;
    public List <Player> players = new List<Player>();


    void Start()
    {

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
        nextTurn += ownedConts / 3;
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
                case (3):
                    p.setArmies(35);
                case (4):
                    p.setArmies(30);
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
                P1TotalTroops = calcTroopsNextTurn(players[0]);
                P2TotalTroops = calcTroopsNextTurn(players[1]);
                P3TotalTroops = calcTroopsNextTurn(players[2]);
                P4TotalTroops = calcTroopsNextTurn(players[3]);

                P1TotalTroops = players[0].getArmies();
                P2TotalTroops = players[1].getArmies();
                P3TotalTroops = players[2].getArmies();
                P4TotalTroops = players[3].getArmies();

                

            case (3):
                //Hide P4 Elements
                P4Name.setActive(false); P4Panel.setActive(false); P4TotalTroops.setActive(false); P4TroopsPerTurn.setActive(false);
                //Set colours
                P1TotalTroops = calcTroopsNextTurn(players[0]);
                P2TotalTroops = calcTroopsNextTurn(players[1]);
                P3TotalTroops = calcTroopsNextTurn(players[2]);

                P1TotalTroops = players[0].getArmies();
                P2TotalTroops = players[1].getArmies();
                P3TotalTroops = players[2].getArmies();
            case (2):
                //Set colours
                P4Name.setActive(false); P4Panel.setActive(false); P4TotalTroops.setActive(false); P4TroopsPerTurn.setActive(false);
                P3Name.setActive(false); P3Panel.setActive(false); P3TotalTroops.setActive(false); P3TroopsPerTurn.setActive(false);
                //Set colours
                P1TotalTroops = calcTroopsNextTurn(players[0]);
                P2TotalTroops = calcTroopsNextTurn(players[1]);

                P1TotalTroops = players[0].getArmies();
                P2TotalTroops = players[1].getArmies();
        }
    }

}
