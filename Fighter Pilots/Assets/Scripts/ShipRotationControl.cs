using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotationControl : MonoBehaviour {
    [HideInInspector] private Rigidbody rb;

    [HideInInspector] private float rollRotationSpeed;
    [HideInInspector] private float pitchRotationSpeed;

    [SerializeField] private float maxRollRotationSpeed;
    [SerializeField] private float rollRotationAcceleration;
    [SerializeField] private float rollRotationDeceleration;

    [SerializeField] private float maxPitchRotationSpeed;
    [SerializeField] private float pitchRotationAcceleration;
    [SerializeField] private float pitchRotationDeceleration;

    void Start() {
        rb = GetComponent<Rigidbody>();

        rollRotationSpeed = 0f;
        pitchRotationSpeed = 0f;
    }

    void FixedUpdate() {
        //Input
        float rollInput = Input.GetAxis("Roll");
        float pitchInput = -Input.GetAxis("Pitch");
    }
}
