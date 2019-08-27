using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotationControl : MonoBehaviour {
    [HideInInspector] private Animator anim;

    [HideInInspector] private float rollRotationSpeed;
    [HideInInspector] private float pitchRotationSpeed;

    [SerializeField] private Player player;

    [SerializeField] private float maxRollRotationSpeed;
    [SerializeField] private float rollRotationAcceleration;
    [SerializeField] private float rollRotationDeceleration;

    [SerializeField] private float maxPitchRotationSpeed;
    [SerializeField] private float pitchRotationAcceleration;
    [SerializeField] private float pitchRotationDeceleration;

    void Start() {
        anim = GetComponent<Animator>();

        rollRotationSpeed = 0f;
        pitchRotationSpeed = 0f;
    }

    void FixedUpdate() {
        //Input
        float rollInput = -Input.GetAxis("Roll " + player.index);
        float pitchInput = -Input.GetAxis("Pitch " + player.index);

        //Roll
        float targetRollRotationSpeed = rollInput * maxRollRotationSpeed;
        rollRotationSpeed = Mathf.Lerp(rollRotationSpeed, targetRollRotationSpeed, Time.fixedDeltaTime * (Mathf.Abs(targetRollRotationSpeed) >= Mathf.Abs(rollRotationSpeed) ? rollRotationAcceleration : rollRotationDeceleration));
        transform.Rotate(0f, 0f, rollRotationSpeed);

        //Pitch
        float targetPitchRotationSpeed = pitchInput * maxPitchRotationSpeed;
        pitchRotationSpeed = Mathf.Lerp(pitchRotationSpeed, targetPitchRotationSpeed, Time.fixedDeltaTime * (Mathf.Abs(targetPitchRotationSpeed) >= Mathf.Abs(pitchRotationSpeed) ? pitchRotationAcceleration : pitchRotationDeceleration));
        transform.Rotate(pitchRotationSpeed, 0f, 0f);

        //Animations
        anim.SetFloat(-rollRotationSpeed >= 0f ? "Positive Roll" : "Negative Roll", Mathf.Abs(rollRotationSpeed / maxRollRotationSpeed));
        anim.SetFloat(-pitchRotationSpeed >= 0f ? "Positive Pitch" : "Negative Pitch", Mathf.Abs(pitchRotationSpeed / maxPitchRotationSpeed));
    }
}
