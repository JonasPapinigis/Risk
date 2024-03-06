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
        m_deck.Add(new PlayingCard());
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
        if (m_deck.Count < 3)
            // the player has less than 3 trading cards so we cannot check
            return null;

        // the list of indicies we want to trade in
        List<int> idxToTrade = new List<int>();

        bool hasWildcard = false;
        int wildcardIdx = 0;

        List<int> artilleries = new List<int>();
        List<int> infantries = new List<int>();
        List<int> cavarlies = new List<int>();

        for (int i=0; i<m_deck.Count; i++) {
            if (hasWildcard) { break;}
            
            if (cavarlies.Count == 3 || infantries.Count == 3
                || artilleries.Count == 3)
                // break if any designs have more than 3
                { break;};

            // wildcard check
            if (m_deck[i].design == PlayingCardType.WILDCARD && m_deck.Count >= 3) {
                hasWildcard = true;
                // we remove instead of adding it to idxToTrade here as we do not want
                // to accidentally readd the wild card when selecting any two cards.
                idxToTrade.add(i);
                wildcardIdx = i;
            }
            
            switch (m_deck[i].design) {
                case PlayingCardType.INFANTRY:
                    infantries.add(m_deck[i]);
                    break;
                case PlayingCardType.ARTILLARY:
                    artilleries.add(m_deck[i]);
                    break;
                case PlayingCardType.CAVALRY:
                    cavarlies.add(m_deck[i]);
                    break;
                default:
                    break;
                    // wtf?
            }
        }

        // add the two remaining cards
        if (hasWildcard) {
            for (int i=0; i<m_deck.Count; i++) {
                if (i == wildcardIdx)
                    // skip over the wildcard as we have it already
                    continue;
                
                if (idxToTrade.Count == 3)
                    // we have our wildcard set
                    break;

                idxToTrade.add(i);
            }
        }

        // check to see if we have 3 of each design
        if (cavarlies.Count == 3)
            idxToTrade = cavarlies;
        if (artilleries.Count == 3)
            idxToTrade = artilleries;
        if (infantries.Count == 3)
            idxToTrade = infantries;
        
        if (infantries.Count > 0 || artilleries.Count > 0
            || cavarlies.Count > 0) {
            // pick the first of each if we have one of each design
            idxToTrade.Add(infantries[0]);
            idxToTrade.Add(cavarlies[0]);
            idxToTrade.Add(artilleries[0]);
        }
        
        // we haven't found a set to trade in
        if (idxToTrade.Count < 3 || !hasWildcard)
            return null;
        
        return idxToTrade;
    }
}
