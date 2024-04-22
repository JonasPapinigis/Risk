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

        private int calcTroops(Player owner){
        int terrOwned = 0;
        foreach ((Territory t, Player p) tuple in territoryManager.ownerList){
            if (tuple.Item2 == owner){
                terrOwned++;
            }
        }
        return terrOwned / 3;
    }

    private void AddPlayers(int currPlayers)
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
            // TODO: player name

            players.Add(new Player("", color));
        }
    }
}
