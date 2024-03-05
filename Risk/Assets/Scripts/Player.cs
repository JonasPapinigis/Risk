using System.Collections;
using System.Collection.Generic;
using UnityEngine;

class Player : MonoBehaviour
{
    private int ownedTerritories;
    private int ownedInfantries;
    private PlayingCard[] ownedPlayingCards;

    public bool ensurePlayerAlive()
    {
        return ownedTerritories > 0;
    }

    public bool canUsePlayingCards()
    {
        return null;
    }
}
