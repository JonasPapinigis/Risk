using System.Collections;
using System.Collections.Generic;
using System;
using System.Timers;
using System.Threading.Tasks;

using UnityEngine;

// this is a quick fix but we Unity has its own random interface and we have been using
// System.Random for this project. this is just a alias that changes Random() to be
// System.Random instead of UnityEngine.Random.
// https://docs.unity3d.com/ScriptReference/Random.html
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    // list of all players
    
    // index of player currently taking their turn
    private int activePlayer;
    // territory manager
    public Territories territoryManager;
    private bool gameOver;
    private bool timerActive;
    private float timer = 0.0f;
    private bool nextPressed;

    // timer stuff  
    Timer turnTimer = new Timer(1000); // ms
    int timeElapsed = 0;

    public PlayerManager playerManager;
    public void Start()
    {
        
        Debug.Log("Hello world!");
        territoryManager = Instantiate(territoryManager);
        playerManager = Instantiate(playerManager);
        Debug.Log("Territory manager created!");
        turnTimer.Elapsed += async (sender, e) => await TurnTimerHandle();
        Debug.Log("Adding players");
        playerManager.AddPlayers();
        Debug.Log("Initialising territories");
        InitialiseTerritories();
        Debug.Log("Starting game");


        Task.Run(RunGame);
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
    
    public void InitialiseTerritories() {
        Debug.Log("Generating initial territories.");
        territoryManager.GenerateTerritories(playerManager.getPlayers());
        Debug.Log("Intialised terrirotirw");
    }
    public Task RunGame(){
        Debug.Log("Running game!");
        bool running = true;
        
        while (running){
            Coroutine coro = StartCoroutine(turn());
            turnTimer.Enabled = true;
            if (timeElapsed > 1000) // how many seconds is the turn?
                // the player is out of time so we cancel the turn coroutine
                // and start the next turn.
                StopCoroutine(coro);
                continue;
            
            // TODO: Game loop base case
            // we need a base condition to exit out of this loop
            // if (bleh)
            //      running = false;
            // on the next iteration we would fall through the loop and we
            // can run cleanup and exit tasks.
        }
        
        return Task.CompletedTask;
    }

    // increments the player index unless index == players.Count
    // in which it clips back to zero.


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
        if (attackerLosses > defenderLosses){
            return (true,attackerLosses,defenderLosses);
        }
        return (false,attackerLosses,defenderLosses);
    }   

    public (int newTroops, int troopsLeft) deploy(Territory terr, int numTroops, int total){
        if (terr.owner != playerManager.getPlayers()[activePlayer]){
            throw new ArgumentException("Cannot Deploy on other players' territories");
        }
        if (numTroops > total){
            throw new ArgumentException("Cannot Deploy more troops than you have available");
        }

        int terrTroops = terr.armies + numTroops;
        return (numTroops, total-numTroops);
    }

    public (int troopsFrom, int troopsTarget) fortify(Territory terrFrom, Territory terrTarget, int num){
        Player plr = playerManager.getPlayers()[activePlayer];
        if (terrFrom.owner != plr && terrTarget.owner != plr){
            throw new ArgumentException("Cannot target unowned territories");
        }
        if (terrFrom.armies <= num){
            throw new ArgumentException("Insufficient troops on territory");
        }

        return (terrFrom.armies - num, terrTarget.armies + num);

    }
    
    //This method calculates how many troops a certain player deserves at a certain point


    private Task TurnTimerHandle()
    {
        timeElapsed++;
        Debug.Log("Turn timer increment event.");
        return Task.CompletedTask;
    }

    public IEnumerator turn()
    {
        // get the next player from the queue.
        Player plr = playerManager.NextTurn();

        /*
            int troopsToDeploy = calcTroops(plr);

        */

        yield return null;
    }

    
}
