using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour {
    //Rotation Values
    [HideInInspector] private float hRot;
    [HideInInspector] private float vRot;

    [SerializeField] private Player player;

    //Perspective Transform References
    [SerializeField] private Transform firstPersonHolder;
    [SerializeField] private Transform thirdPersonHolder;
    [SerializeField] private Transform thirdPersonRearViewHolder;

    //Rotation Parameters
    [SerializeField] private float maxHorizontalRotation;
    [SerializeField] private float maxVerticalRotation;
    [SerializeField] private float lookPivotAcceleration;
    [SerializeField] private float lookNeutralAcceleration;

    void Start() {
        hRot = 0f;
        vRot = 0f;
    }

    void FixedUpdate() {
        bool lookingBack = Input.GetButton("Look Back " + player.index);
        bool togglePerspective = Input.GetButtonDown("Toggle Perspective " + player.index);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        //First Person View Pivot
        if (transform.parent == firstPersonHolder) {
            float targetHRot = Input.GetAxis("Horizontal Look " + player.index) * maxHorizontalRotation;
            float targetVRot = Input.GetAxis("Vertical Look " + player.index) * maxVerticalRotation;

            hRot = Mathf.Lerp(hRot, targetHRot + (lookingBack ? 1f : 0f) * 180f, Time.fixedDeltaTime * (Mathf.Abs(targetHRot) >= Mathf.Abs(hRot) ? lookPivotAcceleration : lookNeutralAcceleration));
            vRot = Mathf.Lerp(vRot, targetVRot, Time.fixedDeltaTime * (Mathf.Abs(targetVRot) >= Mathf.Abs(vRot) ? lookPivotAcceleration : lookNeutralAcceleration));

            transform.localEulerAngles += new Vector3(vRot, hRot, 0f);
        }

        //Third Person Rear View
        else if(transform.parent == thirdPersonHolder || transform.parent == thirdPersonRearViewHolder) {
            transform.SetParent(!lookingBack ? thirdPersonHolder : thirdPersonRearViewHolder);
        }

        //Toggle Perspective
        if(togglePerspective) {
            if(transform.parent == firstPersonHolder) {
                transform.SetParent(thirdPersonHolder);
            }

            else if(transform.parent == thirdPersonHolder || transform.parent == thirdPersonRearViewHolder) {
                transform.SetParent(firstPersonHolder);
            }
        }
	}
}
