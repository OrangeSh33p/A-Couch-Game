using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CouchPart {
    public CouchPartName couchPartName;
    public List<TextMeshProUGUI> texts;
    

    public void SetText (string bodyPart) {
        foreach (TextMeshProUGUI text in texts) {
            text.text = bodyPart;
        }
    }
}