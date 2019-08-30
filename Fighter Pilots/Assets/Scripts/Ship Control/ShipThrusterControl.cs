using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrusterControl : MonoBehaviour {
    //Component References
    [HideInInspector] private Rigidbody rb;
    [HideInInspector] private Animator anim;

    //Motion Speeds
    [HideInInspector] private float moveSpeed;
    [HideInInspector] private float turnSpeed;

    //Animation Values
    [HideInInspector] public float thrusterMagAnim;
    [HideInInspector] public float thrusterDirAnim;

    [SerializeField] private Player player;

    [SerializeField] private float thrusterDeadzone;

    //Move Parameters
    [SerializeField] private float maxThrusterMoveSpeed;
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveDeceleration;

    //Turn Parameters
    [SerializeField] private float maxTurnSpeed;
    [SerializeField] private float turnAcceleration;
    [SerializeField] private float turnDeceleration;

    void Start() {
        //Component References
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //Motion Speeds
        moveSpeed = 0f;
        turnSpeed = 0f;

        //Animation Values
        thrusterMagAnim = 0f;
        thrusterDirAnim = 0f;
    }

    void FixedUpdate() {
        //Thruster Input
        float rightThruster = Input.GetAxis("Right Thruster " + player.index);
        float leftThruster = Input.GetAxis("Left Thruster " + player.index);

        float thrusterMag = Mathf.Max(rightThruster, leftThruster) > thrusterDeadzone ? (rightThruster + leftThruster) / 2f : 0f;
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
        thrusterMagAnim = (moveSpeed - minMoveSpeed) / maxThrusterMoveSpeed;
        thrusterDirAnim = turnSpeed / maxTurnSpeed;
        anim.SetFloat("Thruster Magnitude", thrusterMagAnim);
        anim.SetFloat(-turnSpeed >= 0f ? "Positive Thruster" : "Negative Thruster", Mathf.Abs(thrusterDirAnim));
    }
}
