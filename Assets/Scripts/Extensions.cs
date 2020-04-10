using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Extensions {
    public static string ToText (this BodyPartName bodyPart) { return UnCamelCase(bodyPart.ToString()); }
    public static string ToText (this CouchPartName couchPart) { return UnCamelCase(couchPart.ToString()); }

    public static string UnCamelCase(string str) {
        if (string.IsNullOrEmpty(str)) return str;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsUpper(str, i)) sb.Append(" ");
            sb.Append(char.ToLower(str[i]));
        }

        return sb.ToString();
    }

    public static T Random<T>(this List<T> list) {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }
}
