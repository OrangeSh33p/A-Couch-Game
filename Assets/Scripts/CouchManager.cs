using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class CouchManager : MonoBehaviour {
    public List<BodyPartName> usedBodyParts;
    public List<CouchPart> usedCouchParts;

    private void Start () {
        ClearTexts ();
    }

    private void Update () {
        if (Input.GetMouseButtonDown(0)) Round ();
    }

    private void ClearTexts () {
        foreach (CouchPart couchPart in usedCouchParts) couchPart.text.text = "";
    }

    public void Round () {
        BodyPartName bodyPart = usedBodyParts[Random.Range(0, usedBodyParts.Count)];
        CouchPart couchPart = usedCouchParts[Random.Range(0, usedCouchParts.Count)];
        ClearTexts();
        couchPart.SetText(ToText(bodyPart));
        //Debug.Log("Put "+ToText(bodyPart)+" on "+ToText(couchPart.couchPartName));
    }

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
}