using System;
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

    public void Add(string bodyPartName) {
        foreach (TextMeshProUGUI text in texts) {
            if (text.text.Contains(bodyPartName)) {
                int number = int.Parse(text.text
                    .Remove(text.text.IndexOf(bodyPartName, StringComparison.Ordinal), bodyPartName.Length)
                    .Trim());
                text.text = number+1 + bodyPartName;
            } else {
                text.text = "1 " + bodyPartName;
            }
        }
    }
}