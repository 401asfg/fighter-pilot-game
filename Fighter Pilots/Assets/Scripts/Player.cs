using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [HideInInspector] public int index;
    [SerializeField] private int health;

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
        Destroy(transform.root.gameObject);
    }
}
