using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public CouchManager couchManager;
    public FlowManager flowManager;

    public void Awake() {
        DontDestroyOnLoad(this);
        if (instance == null) instance = this;
        if (instance != this) Destroy(gameObject);
    }
}