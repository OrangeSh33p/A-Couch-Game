using UnityEngine;

public class CouchManager : MonoBehaviour {
    // [Header("REFERENCES")]
    
    //SHORTCUTS
    public GameManager gm { get { return GameManager.instance; } }

    public void StartPosition() {
        ClearTexts();
        Debug.Log("start position");
    }

    public void NextRound () {
        ClearTexts();

        string textToDisplay = "";
        
        if (gm.balancingManager.playMode != PM.NO_TURNS) {
            int activePlayer = GetNextPlayer();
            textToDisplay += "player " + activePlayer + "\n";
            gm.playerManager.activePlayer = activePlayer;
        }

        textToDisplay += GetBodyPart().ToText();
        GetCouchPart().SetText(textToDisplay);
    }


    // --------------------
    // UTILS
    // --------------------

    private void ClearTexts () { 
        gm.balancingManager.usedCouchParts.ForEach(cp => cp.SetText(""));
    }

    private int GetNextPlayer() {
        int nextPlayer;
        if (gm.balancingManager.playMode == PM.RANDOM_TURNS) {
            nextPlayer = Random.Range(1, gm.playerManager.amountOfPlayers);
            if (nextPlayer >= gm.playerManager.activePlayer) nextPlayer++;
        } else {
            nextPlayer = gm.playerManager.activePlayer + 1;
            if (nextPlayer > gm.playerManager.amountOfPlayers) nextPlayer = 1;
        }

        return nextPlayer;
    }

    private BodyPartName GetBodyPart() {
        return gm.balancingManager.usedBodyParts.Random();
    }

    private CouchPart GetCouchPart() {
        return gm.balancingManager.usedCouchParts.Random();
    }
}