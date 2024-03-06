using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // list of all players
    public List <Player> players = new List<Player>();
    // index of player currently taking their turn
    public int currPlayer;
    // territory manager
    public Territories territoryManager;
    private bool gameOver;

    public void Start()
    {
        // we need a way in some menu to define how many players
        // there are
        Init(3);
    }

    public void Update()
    {

    }

    public void Init(int nPlayers)
    {   
        //COMMENTED OUT TILL PLAYER INITIALISATION SOLVED
        /**
        for (int i=0; i < nPlayers; i++) {
            players.Add(new Player());
        }
        territoryManager = new Territories();
        */
        // we would eventually call this...
        //territoryManager.AssignTerritories(nPlayers);

        // while (!isGameOver()) {
        //    SelectTurn()
        //    ...
        //    ...
        // }      
    }

    // increments the player index unless index == players.Count
    // in which it clips back to zero.
    public void SelectTurn()
    {
        currPlayer++;
        currPlayer %= players.Count;
    }

    public bool isGameOver()
    {
        return gameOver;
    }
}
