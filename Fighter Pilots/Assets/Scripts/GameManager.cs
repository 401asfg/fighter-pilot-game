using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public PlayerSpawnPoint[] spawnPoints;
    [SerializeField] private SplitScreenView[] splitScreenViews;
    [SerializeField] private float respawnDelay;

    private GameObject[] players;

    void Start() {
        players = new GameObject[2];

        for(int i = 0; i < players.Length; i++) {
            players[i] = spawnPoints[i].Spawn(i);
        }

        UpdateSplitscreen();
    }

    public void UpdateSplitscreen() {
        for(int i = 0; i < players.Length; i++) {
            players[i].GetComponentInChildren<Camera>().rect = splitScreenViews[players.Length - 1].playerViews[i];
        }
    }

    public IEnumerator RespawnPlayer(int index, PlayerSpawnPoint spawnPoint) {
        yield return new WaitForSeconds(respawnDelay);
        players[index] = spawnPoint.Spawn(index);
    }
}

[System.Serializable]
public class SplitScreenView {
    public Rect[] playerViews;
}
