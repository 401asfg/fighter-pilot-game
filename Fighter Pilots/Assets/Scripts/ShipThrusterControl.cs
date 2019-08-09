using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrusterControl : MonoBehaviour {
    [HideInInspector] private Rigidbody rb;

    [HideInInspector] private float moveSpeed;
    [HideInInspector] private float rotationSpeed;

    [SerializeField] private float thrusterDeadzone;

    [SerializeField] private float maxThrusterMoveSpeed;
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxReverseMoveSpeed;
    [SerializeField] private float moveAcceleration;
    [SerializeField] private float moveDeceleration;

    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float rotationAcceleration;
    [SerializeField] private float rotationDeceleration;

    [SerializeField] private Transform tiltingBody;
    [SerializeField] private float maxTilt;

    void Start() {
        rb = GetComponent<Rigidbody>();

        moveSpeed = 0f;
        rotationSpeed = 0f;
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
        float targetRotationSpeed = thrusterDir * maxRotationSpeed;
        rotationSpeed = Mathf.Lerp(rotationSpeed, targetRotationSpeed, Time.fixedDeltaTime * (Mathf.Abs(targetRotationSpeed) >= Mathf.Abs(rotationSpeed) ? rotationAcceleration : rotationDeceleration));
        transform.Rotate(new Vector3(0f, rotationSpeed, 0f));

        //Turning Tilt
        Vector3 tiltingBodyAngles = tiltingBody.eulerAngles;
        tiltingBody.eulerAngles = new Vector3(tiltingBodyAngles.x, tiltingBodyAngles.y, -(rotationSpeed / maxRotationSpeed) * maxTilt);
    }
}
