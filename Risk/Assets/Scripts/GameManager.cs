using System.Collections;
using System.Collections.Generic;
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

    bool success = defenderLosses > attackerLosses;
    return (success, attackerLosses, defenderLosses);
    }
}
