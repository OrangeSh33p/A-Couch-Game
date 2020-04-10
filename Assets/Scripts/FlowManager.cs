using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowManager : MonoBehaviour {
    public GS gameState = GS.START_MENU;

    public TMP_Text startMenuText;
    public List<TMP_Text> playingTexts;

    public void ExitStartMenu() {
        startMenuText.gameObject.SetActive(false);
    }

    public void EnterPlaying() {
        playingTexts.ForEach(text => text.gameObject.SetActive(true));
    }
}

public enum GS {
    START_MENU,
    PLAYERS_SELECTION,
    CONSENT_WARNING,
    STARTING_POSITION,
    PLAYING,
    END_SCREEN
}
