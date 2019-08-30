using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonViewReaction : MonoBehaviour {
    //Ship References
    [SerializeField] private ShipThrusterControl thrusterCtrl;
    [SerializeField] private ShipRotationControl rotationCtrl;
    [SerializeField] private Transform target;

    //View Alteration Parameters
    [SerializeField] private float thrusterMagReactionDistance;
    [SerializeField] private float thrusterDirReactionAngle;
    [SerializeField] private float rollReactionAngle;
    [SerializeField] private float pitchReactionAngle;

    [HideInInspector] private Vector3 startPosition;

    void Start() {
        startPosition = transform.localPosition;
    }

    void FixedUpdate() {
        transform.LookAt(target, target.up);

        //Thruster Magnitude Reaction
        float thrusterMag = thrusterCtrl.thrusterMagAnim;
        transform.localPosition = startPosition + new Vector3(0f, 0f, -thrusterMag * thrusterMagReactionDistance);

        //Thruster Direction Reaction
        float thrusterDir = thrusterCtrl.thrusterDirAnim;
        transform.RotateAround(target.position, target.up, -thrusterDir * thrusterDirReactionAngle);

        //Roll Reaction
        float roll = rotationCtrl.rollAnim;
        transform.RotateAround(target.position, target.forward, -roll * rollReactionAngle);

        //Pitch Reaction
        float pitch = rotationCtrl.pitchAnim;
        transform.RotateAround(target.position, target.right, -pitch * pitchReactionAngle);
    }
}
