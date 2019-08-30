using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotationControl : MonoBehaviour {
    [HideInInspector] private Animator anim;

    //Motion Speeds
    [HideInInspector] private float rollRotationSpeed;
    [HideInInspector] private float pitchRotationSpeed;

    //Animation Values
    [HideInInspector] public float rollAnim;
    [HideInInspector] public float pitchAnim;

    [SerializeField] private Player player;

    //Roll Parameters
    [SerializeField] private float maxRollRotationSpeed;
    [SerializeField] private float rollRotationAcceleration;
    [SerializeField] private float rollRotationDeceleration;

    //Pitch Parameters
    [SerializeField] private float maxPitchRotationSpeed;
    [SerializeField] private float pitchRotationAcceleration;
    [SerializeField] private float pitchRotationDeceleration;

    void Start() {
        anim = GetComponent<Animator>();

        //Motion Speeds
        rollRotationSpeed = 0f;
        pitchRotationSpeed = 0f;

        //Animation Values
        rollAnim = 0f;
        pitchAnim = 0f;
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
        rollAnim = rollRotationSpeed / maxRollRotationSpeed;
        pitchAnim = pitchRotationSpeed / maxPitchRotationSpeed;
        anim.SetFloat(-rollRotationSpeed >= 0f ? "Positive Roll" : "Negative Roll", Mathf.Abs(rollAnim));
        anim.SetFloat(-pitchRotationSpeed >= 0f ? "Positive Pitch" : "Negative Pitch", Mathf.Abs(pitchAnim));
    }
}
