using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [HideInInspector] public int index;
    [SerializeField] private int health;
    [SerializeField] private GameManager gameManager;

    public int Health {
        get {
            return health;
        }

        set {
            health = value;

            if(health <= 0) {
                health = 0;
                Die();
            }
        }
    }

    public void Die() {
        StartCoroutine(gameManager.RespawnPlayer(index, gameManager.spawnPoints[index]));
        Destroy(transform.root.gameObject);
    }

    void OnCollisionEnter(Collision c) {
        Die();
    }
}
