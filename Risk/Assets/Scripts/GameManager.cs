using System.Collections;
using System.Collection.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // list of all players
    public List <Player> players = new List<Player>();
    // player currently taking their turn
    public Player currPlayer;
    // territory manager
    public Territories territoryManager;

    public Start()
    {
        // we need a way in some menu to define how many players
        // there are
        Init(3);
    }

    public Update()
    {

    }

    public void Init(int nPlayers)
    {
        for (int i=0; i < nPlayers; i++) {
            players.add(new Player();)
        }
        territoryManager = new Territories();
        // we would eventually call this...
        //territoryManager.AssignTerritories(nPlayers);
    }
}
