using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class CouchManager : MonoBehaviour {
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
        
        BodyPartName randomBodyPart = usedBodyParts[Random.Range(0, usedBodyParts.Count)];
        CouchPart randomCouchPart = usedCouchParts[Random.Range(0, usedCouchParts.Count)];
        randomCouchPart.SetText(ToText(randomBodyPart));
        //Debug.Log("Put "+ToText(bodyPart)+" on "+ToText(couchPart.couchPartName));
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
        foreach (CouchPart couchPart in usedCouchParts) couchPart.text.text = "";
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
            usedCouchParts.Remove (CouchPartName.armrest);
        } else {
            usedCouchParts.Remove (CouchPartName.leftArmrest);
            usedCouchParts.Remove (CouchPartName.rightArmrest);
        }

        if (lateralizeBackrests) {
            usedCouchParts.Remove (CouchPartName.backrest);
        } else {
            usedCouchParts.Remove (CouchPartName.leftBackrest);
            usedCouchParts.Remove (CouchPartName.rightBackrest);
        }

        if (lateralizeCushions) {
            usedCouchParts.Remove (CouchPartName.cushion);
        } else {
            usedCouchParts.Remove (CouchPartName.leftCushion);
            usedCouchParts.Remove (CouchPartName.rightCushion);
        }
    }
}