using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private PlayerSpawnPoint[] spawnPoints;
    [SerializeField] private SplitScreenView[] splitScreenViews;

    private GameObject[] players;

    void Start() {
        players = new GameObject[2];

        players[0] = spawnPoints[0].Spawn(0);
        players[1] = spawnPoints[1].Spawn(1);

        UpdateSplitscreen();
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
