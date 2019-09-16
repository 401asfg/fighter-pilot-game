﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public PlayerSpawnPoint[] spawnPoints;
    [SerializeField] private SplitScreenView[] splitScreenViews;
    [SerializeField] private int playerAmount;

    private GameObject[] players;

    void Start() {
        players = new GameObject[playerAmount];

        for(int i = 0; i < players.Length; i++) {
            players[i] = spawnPoints[i].Spawn(i);
        }

        UpdateSplitscreen();
    }

    void Update() {
        for(int i = 0; i < players.Length; i++) {
            if(players[i] == null) {
                players[i] = spawnPoints[0].Spawn(i);
                UpdateSplitscreen();
            }
        }
    }

    public void UpdateSplitscreen() {
        for(int i = 0; i < players.Length; i++) {
            players[i].GetComponentInChildren<Camera>().rect = splitScreenViews[players.Length - 1].playerViews[i];
        }
    }
}

[System.Serializable]
public class SplitScreenView {
    public Rect[] playerViews;
}
