using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [Header("BALANCING")] 
    public int minPlayers;
    public int maxPlayers;
    
    [Header("STATE")]
    public int amountOfPlayers;

    [Header("REFERENCES")] 
    public TMP_Text amountOfPlayersText;

    public void Start() {
        SetText();
    }

    public void IncreasePlayers() {
        amountOfPlayers = Mathf.Min(amountOfPlayers + 1, maxPlayers);
        SetText();
    }

    public void DecreasePlayers() {
        amountOfPlayers = Mathf.Max(amountOfPlayers - 1, minPlayers);
        SetText();
    }

    private void SetText() {
        amountOfPlayersText.text = amountOfPlayers + " players";
    }
}
