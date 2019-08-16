using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    void FixedUpdate() {
        transform.position += transform.forward * speed;
    }
}
