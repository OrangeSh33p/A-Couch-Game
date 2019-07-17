using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using System.Linq;

public class CouchManager : MonoBehaviour {
    [Header("BALANCING")]
    public int players;

    [Header("OPTIONS")]
    public bool useHeads;
    public bool useButts;
    public bool useElbows;
    public bool useKnees;
    public bool lateralizeBodies;
    public bool lateralizeCushions;
    public bool lateralizeArmrests;
    public bool lateralizeBackrests;
    public bool personalizeCommands;

    [Header("REFERENCES")]
    public List<CouchPart> allCouchParts;
    public List<BodyPartName> allBodyParts;

    [Header("STATE")]
    public List<BodyPartName> usedBodyParts;
    public List<CouchPart> usedCouchParts;
    public int previousPlayer;

    private void Start () {
        BuildBodyParts ();
        BuildCouchParts ();
        ClearTexts ();
    }

    private void Update () {
        if (Input.GetMouseButtonDown(0)) NextRound ();
    }

    public void NextRound () {
        ClearTexts();

        string textToDisplay = "";
        
        if (personalizeCommands) {
            textToDisplay += "player "+(previousPlayer+1)+"\n";
            previousPlayer = (previousPlayer + 1)%players;
        }

        BodyPartName randomBodyPart = usedBodyParts[Random.Range(0, usedBodyParts.Count)];
        CouchPart randomCouchPart = usedCouchParts[Random.Range(0, usedCouchParts.Count)];

        textToDisplay += ToText(randomBodyPart);
        randomCouchPart.SetText(textToDisplay);
    }


    ////////////////////
    // UTILS
    ////////////////////


    public string ToText (BodyPartName bodyPart) { return UnCamelCase(bodyPart.ToString()); }
    public string ToText (CouchPartName couchPart) { return UnCamelCase(couchPart.ToString()); }

    public string UnCamelCase(string str) {
        if (string.IsNullOrEmpty(str)) return str;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsUpper(str, i)) sb.Append(" ");
            sb.Append(char.ToLower(str[i]));
        }

        return sb.ToString();
    }

    private void ClearTexts () {
        foreach (CouchPart couchPart in usedCouchParts) couchPart.SetText("");
    }

    private void BuildBodyParts () {
        usedBodyParts = allBodyParts;

        if (!useHeads) usedBodyParts.Remove (BodyPartName.head);
        if (!useButts) usedBodyParts.Remove (BodyPartName.butt);

        if (lateralizeBodies) {
            usedBodyParts.Remove (BodyPartName.hand);
            usedBodyParts.Remove (BodyPartName.foot);
            usedBodyParts.Remove (BodyPartName.elbow);
            usedBodyParts.Remove (BodyPartName.knee);

            if (!useElbows) {
                usedBodyParts.Remove (BodyPartName.leftElbow);
                usedBodyParts.Remove (BodyPartName.rightElbow);
            } 

            if (!useKnees) {
                usedBodyParts.Remove (BodyPartName.leftKnee);
                usedBodyParts.Remove (BodyPartName.rightKnee);
            } 
        } else {
            usedBodyParts.Remove (BodyPartName.leftHand);
            usedBodyParts.Remove (BodyPartName.rightHand);
            usedBodyParts.Remove (BodyPartName.leftFoot);
            usedBodyParts.Remove (BodyPartName.rightFoot);
            usedBodyParts.Remove (BodyPartName.leftElbow);
            usedBodyParts.Remove (BodyPartName.rightElbow);
            usedBodyParts.Remove (BodyPartName.leftKnee);
            usedBodyParts.Remove (BodyPartName.rightKnee);

            if (!useElbows) usedBodyParts.Remove (BodyPartName.elbow);
            if (!useKnees) usedBodyParts.Remove (BodyPartName.knee);
        }
    }

    private void BuildCouchParts () {
        usedCouchParts = allCouchParts;

        if (lateralizeArmrests) {
            RemoveCouchPart (CouchPartName.armrest);
        } else {
            RemoveCouchPart (CouchPartName.leftArmrest);
            RemoveCouchPart (CouchPartName.rightArmrest);
        }

        if (lateralizeBackrests) {
            RemoveCouchPart (CouchPartName.backrest);
        } else {
            RemoveCouchPart (CouchPartName.leftBackrest);
            RemoveCouchPart (CouchPartName.rightBackrest);
        }

        if (lateralizeCushions) {
            RemoveCouchPart (CouchPartName.cushion);
        } else {
            RemoveCouchPart (CouchPartName.leftCushion);
            RemoveCouchPart (CouchPartName.rightCushion);
        }
    }

    private void RemoveCouchPart (CouchPartName partToRemove) {
        usedCouchParts = usedCouchParts.Where(part => part.couchPartName != partToRemove).ToList();
    }
}