using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CouchPart {
    public CouchPartName couchPartName;
    public TextMeshProUGUI text;

    public void SetText (string bodyPart) {
        text.text = bodyPart;
    }
}