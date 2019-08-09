using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotationControl : MonoBehaviour {
    [HideInInspector] private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {

    }
}
