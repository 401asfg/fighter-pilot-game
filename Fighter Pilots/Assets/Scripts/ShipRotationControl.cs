using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotationControl : MonoBehaviour {
    [HideInInspector] private Rigidbody rb;

    [HideInInspector] private float rollRotationSpeed;
    [HideInInspector] private float pitchRotationSpeed;

    [SerializeField] private Animator viewDelayAnim;

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
        float rollInput = -Input.GetAxis("Roll");
        float pitchInput = -Input.GetAxis("Pitch");

        //Roll
        float targetRollRotationSpeed = rollInput * maxRollRotationSpeed;
        rollRotationSpeed = Mathf.Lerp(rollRotationSpeed, targetRollRotationSpeed, Time.fixedDeltaTime * (Mathf.Abs(targetRollRotationSpeed) >= Mathf.Abs(rollRotationSpeed) ? rollRotationAcceleration : rollRotationDeceleration));
        transform.Rotate(0f, 0f, rollRotationSpeed);

        //Pitch
        float targetPitchRotationSpeed = pitchInput * maxPitchRotationSpeed;
        pitchRotationSpeed = Mathf.Lerp(pitchRotationSpeed, targetPitchRotationSpeed, Time.fixedDeltaTime * (Mathf.Abs(targetPitchRotationSpeed) >= Mathf.Abs(pitchRotationSpeed) ? pitchRotationAcceleration : pitchRotationDeceleration));
        transform.Rotate(pitchRotationSpeed, 0f, 0f);

        //Rotation View Delay Animations
        viewDelayAnim.SetFloat("Roll View Delay", rollRotationSpeed / maxRollRotationSpeed);
        viewDelayAnim.SetFloat("Pitch View Delay", pitchRotationSpeed / maxPitchRotationSpeed);
    }
}
