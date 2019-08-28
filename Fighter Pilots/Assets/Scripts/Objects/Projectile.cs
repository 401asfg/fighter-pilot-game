using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private int damage;
    [SerializeField] private float speed;

    void FixedUpdate() {
        transform.position += transform.forward * speed;
    }

    void OnCollisionEnter(Collision c) {
        Player player = c.transform.root.GetComponent<Player>();

        if(player != null) {
            player.Health -= damage;
        }

        Destroy(gameObject);
    }
}
