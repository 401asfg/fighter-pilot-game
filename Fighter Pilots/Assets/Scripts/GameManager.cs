using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private PlayerSpawnPoint[] spawnPoints;

    void Start() {
        spawnPoints[0].Spawn(0);
        spawnPoints[1].Spawn(1);
        spawnPoints[2].Spawn(2);
        spawnPoints[3].Spawn(3);
    }
}
