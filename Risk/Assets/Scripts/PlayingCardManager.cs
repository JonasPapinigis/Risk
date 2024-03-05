using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each player has their own PlayingCardManager
// which assigns them a card at the end of each turn
// the playing card will check for possible trade-ins for a
// player at the end of each turn.
public class PlayingCardManager : MonoBehaviour
{
    // track the trading cards the player has
    private List<PlayingCard> m_deck = new List<PlayingCard>();
    // tracks the number of times the player has traded in cards to determine
    // the amount of infantry to add.
    private int timesTraded;

    void Start() { }
    void Update() { }

    void AddCard()
    {
        m_deck.add(new PlayingCard());
    }

    /*
     * check to see if the player can trade in cards.
     *
     * returns:
     *      A list of the indicies of cards that can be traded in
     *      null, if no match is found.
     *
     * caveat:
     *      currently, this cannot check if a player has 1 of each 3 designs.
     *      3 of the same design has some logic issues
     */
    public List<int> CheckForSet()
    {
        if (m_deck.Length < 3)
            // the player has less than 3 trading cards so we cannot check
            return null;

        // the list of indicies we want to trade in
        List<int> idxToTrade = new List<int>();

        int identicalDesigns = 0;
        bool hasWildcard = false;
        int wildcardIdx = 0;

        TradingCardType prevDesign;
        // wildcard check
        for (int i=0; i<m_deck.Length; i++;) {
            if (hasWildcard)
                break;
            if (identicalDesigns == 3)
                break;

            if (m_deck[i].design == PlayingCardType.WILDCARD && m_deck.Length >= 3) {
                hasWildcard = true;
                // we remove instead of adding it to idxToTrade here as we do not want
                // to accidentally readd the wild card when selecting any two cards.
                idxToTrade.add(i);
                wildcardIdx = i;
            }

            if (m_deck[i].design == prevDesign) {
                identicalDesigns++;
                idxToTrade.Add(i);

            prevDesign = m_deck[i].design;
        }
        // we haven't found a set to trade in
        if (idxToTrade.Length < 3 || !hasWildcard)
            return null;

        // add the two remaining cards
        if (hasWildcard) {
            for (int i=0; i<m_deck.Length; i++) {
                if (i == wildcardIdx)
                    continue;
                
                if (idxToTrade.Length == 3)
                    break;

                idxToTrade.add(i);
            }
        }

        //if (identicalDesigns == 3)
            //return true;
        
        return idxToTrade;
    }
}
