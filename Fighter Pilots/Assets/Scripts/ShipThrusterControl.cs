using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrusterControl : MonoBehaviour {
    [HideInInspector] private Rigidbody rb;
    [HideInInspector] private Animator anim;

    [HideInInspector] private float moveSpeed;
    [HideInInspector] private float turnSpeed;

    [SerializeField] private float thrusterDeadzone;

    [SerializeField] private float maxThrusterMoveSpeed;
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveDeceleration;

    [SerializeField] private float maxTurnSpeed;
    [SerializeField] private float turnAcceleration;
    [SerializeField] private float turnDeceleration;

    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        moveSpeed = 0f;
        turnSpeed = 0f;
    }

    void FixedUpdate() {
        //Thruster Input
        float rightThruster = Input.GetAxis("Right Thruster");
        float leftThruster = Input.GetAxis("Left Thruster");

        float thrusterMag = Mathf.Max(rightThruster, leftThruster) > thrusterDeadzone ? Mathf.Max(rightThruster, leftThruster) : 0f;
        float thrusterDir = Mathf.Abs(rightThruster - leftThruster) > thrusterDeadzone ? rightThruster - leftThruster : 0f;

        //Forward Movement
        float targetMoveSpeed = thrusterMag * maxThrusterMoveSpeed + minMoveSpeed;
        moveSpeed = Mathf.Lerp(moveSpeed, targetMoveSpeed, Time.fixedDeltaTime * (Mathf.Abs(targetMoveSpeed) >= Mathf.Abs(moveSpeed) ? moveAcceleration : moveDeceleration));
        rb.velocity = transform.forward * moveSpeed;

        //Turning
        float targetTurnSpeed = thrusterDir * maxTurnSpeed;
        turnSpeed = Mathf.Lerp(turnSpeed, targetTurnSpeed, Time.fixedDeltaTime * (Mathf.Abs(targetTurnSpeed) >= Mathf.Abs(turnSpeed) ? turnAcceleration : turnDeceleration));
        transform.Rotate(new Vector3(0f, turnSpeed, 0f));

        //Animations
        anim.SetFloat("Thruster Direction", -turnSpeed / maxTurnSpeed);
    }
}
