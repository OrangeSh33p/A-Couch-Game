using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class FlowManager : MonoBehaviour {
    public GS gameState = GS.START_MENU;

    public List<GameObject> startMenuObjects;
    public List<GameObject> consentWarningObjects;
    public List<GameObject> playerSelectionObjects;
    public List<GameObject> playingObjects;
    
    //SHORTCUTS
    public GameManager gm { get { return GameManager.instance; } }


    public void Start() {
        ExitPlayerSelection();
        ExitPlaying();
        ExitConsentWarning();
        
        EnterStartMenu();
    }

    // --------------------
    // TRANSITIONS
    // --------------------

    public void EnterStartMenu() {
        gameState = GS.START_MENU;
        Enable(startMenuObjects);
    }

    public void ExitStartMenu() {
        Disable(startMenuObjects);
    }

    public void EnterConsentWarning() {
        gameState = GS.CONSENT_WARNING;
        Enable(consentWarningObjects);
    }

    public void ExitConsentWarning() {
        Disable(consentWarningObjects);
    }

    public void EnterPlayerSelection() {
        gameState = GS.PLAYER_SELECTION;
        Enable(playerSelectionObjects);
    }

    public void ExitPlayerSelection() {
        Disable(playerSelectionObjects);
    }

    public void EnterPlaying() {
        gameState = GS.PLAYING;
        Enable(playingObjects);
        gm.couchManager.StartPosition();
    }

    public void ExitPlaying() {
        Disable(playingObjects);
    }
    
    // --------------------
    // UTILS
    // --------------------

    private void Enable(List<GameObject> list) {
        list.ForEach(obj => obj.gameObject.SetActive(true));
    }

    private void Disable(List<GameObject> list) {
        list.ForEach(obj => obj.gameObject.SetActive(false));
    }
}

public enum GS {
    START_MENU,
    PLAYER_SELECTION,
    CONSENT_WARNING,
    STARTING_POSITION,
    PLAYING,
    END_SCREEN
}
