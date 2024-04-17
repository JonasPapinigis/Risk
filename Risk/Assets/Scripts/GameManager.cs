using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

// this is a quick fix but we Unity has its own random interface and we have been using
// System.Random for this project. this is just a alias that changes Random() to be
// System.Random instead of UnityEngine.Random.
// https://docs.unity3d.com/ScriptReference/Random.html
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    // list of all players
    public List <Player> players = new List<Player>();
    // index of player currently taking their turn
    public int currPlayers;
    private int activePlayer;
    // territory manager
    public Territories territoryManager;
    private bool gameOver;
    private bool timerActive; 
    private float timer = 0.0f;
    private bool nextPressed;



    public void Start()
    {
        
        AddPlayers(currPlayers);
        InitialiseTerritories();
        RunGame();

    }

    public void Update()
    {
        if (timerActive){
            timer += Time.deltaTime;
            if (timer <= 180f){
                timer = 0f;
                timerActive = false;
            }
        }
    }

    public bool InitialisePlayers(int nPlayers)
    {   
        
    }
    public bool InitialiseTerritories() {
        terrs = territories.
    }
    public bool RunGame(){
        bool running = true;
        while (true){
            
        }
        return running;
    }

    // increments the player index unless index == players.Count
    // in which it clips back to zero.
    public void SelectTurn()
    {
        activePlayer++;
        activePlayer %= players.Count;
        return players[activePlayer];
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    private int rollDie(){
        Random rand = new Random();
        return rand.Next(1, 7);
    }

    public (bool success, int attLoss, int defLoss) Attack(Territory attacker, Territory defender, int nDieA, int nDieD){
     /**bool: return True is attack successfull, False otherwise
        int: returns num of troops subtracted from attacker
        int: return num of troop subtracted from defender

        PARAMS: 
        Territory attacker,defencer: target territories
        int nDieA,nDieD: num of die selected for each player to use during the attack
        */
        // Checks for territories not being owned by the attacker
        if (attacker.owner == defender.owner){
            throw new ArgumentException("Defending Territory owned by attacker", nameof(defender));
        }
        if (attacker == defender){
            throw new ArgumentException("Territory cannot attack itself", nameof(attacker));
        }
        // Checks if 0 < attDie < 4, 0 < defDie < 3
        if (nDieA < 1 || nDieA > 3 || nDieD < 1 || nDieD > 2){
            throw new ArgumentException("Invalid number of Dice used (MAX 3 for att., MAX 2 for def.)");
        }
        // Cumulative Dice Rolls
        List<int> attRolls = new List<int>();
        List<int> defRolls = new List<int>();
        for (int i = 0; i < nDieA; i++){
            int roll = rollDie();
            int position = attRolls.BinarySearch(roll);
            if (position < 0) position = ~position; // If item not found, BinarySearch returns bitwise complement of the next larger item's index
            attRolls.Insert(position, roll);
        }
        for (int i = 0; i < nDieD; i++){
            int roll = rollDie();
            int position = defRolls.BinarySearch(roll);
            if (position < 0) position = ~position; 
            defRolls.Insert(position, roll);
        }

        attRolls.Reverse(); // Ensures descending order
        defRolls.Reverse();

        int attackerLosses = 0, defenderLosses = 0;

        int comparisons = Math.Min(attRolls.Count, defRolls.Count);
        for (int i = 0; i < comparisons; i++) {
            if (attRolls[i] > defRolls[i]) {
                defenderLosses++; // Attacker wins this comparison
            } else {
                attackerLosses++; // Defender wins or ties this comparison
            }
    }
    }   

    public (int newTroops, int troopsLeft) deploy(Territory terr, int numTroops, int total){
        if (terr.owner != players[activePlayer]){
            throw new ArguementException("Cannot Deploy on other players' territories");
        }
        if (numTroops > total){
            throw new ArguementException("Cannot Deploy more troops than you have available");
        }

        terrTroops = terr.armies + numTroops;
        return terrTroops;
        
        
    }

    public (int troopsFrom, int troopsTarget) fortify(Territory terrFrom, Territory terrTarget, int num){
        Player plr = players[activePlayer];
        if (terrFrom.owner != plr && terrTarget.owner != plr){
            throw new ArguementException("Cannot target unowned territories");
        }
        if (terrFrom.armies <= num){
            throw new ArguementException("Insufficient troops on territory");
        }

        return (terrmFrom.armies - num, terrTarget.armies + num);

    }
    

    //TODO; 
    private int calcTroops(){
        Player plr = players[activePlayer];
    }

    public bool turn(){
        //Initialise timer
        Player plr = players[activePlayer];
        timerActive = true;
        while (timerActive){
            //Deploy until there are no troops or cancelled
            int toDeploy = calcTroops();
            while(toDeploy > 0){
                //toDeploy = 
            }
            //Attack until time runs our or cancelled
            //Fortify once or until time runs out
        }

    }
    private void AddPlayers()
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
