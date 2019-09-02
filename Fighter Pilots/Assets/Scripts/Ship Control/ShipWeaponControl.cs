using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponControl : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private Transform mainCamera;

    [SerializeField] private Weapon rightWeapon;
    [SerializeField] private Weapon leftWeapon;

    [SerializeField] private RectTransform crosshair;
    [SerializeField] private LayerMask aimRayLayers;
    [SerializeField] private float aimRayDistance;

    void Update() {
        //Input
        bool fireRight = Input.GetButton("Fire Right Weapon " + player.index);
        bool fireLeft = Input.GetButton("Fire Left Weapon " + player.index);

        //Shoot
        if(fireRight) {
            rightWeapon.Shoot();
        }

        if(fireLeft) {
            leftWeapon.Shoot();
        }

        //Aim
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        RaycastHit hit;

        Vector3 target;
        Camera cam = mainCamera.GetComponent<Camera>();

        if(Physics.Raycast(ray, out hit, aimRayDistance, aimRayLayers)) {
            target = hit.point;
        }

        else {
            target = (aimRayDistance * mainCamera.forward + mainCamera.position);
        }

        rightWeapon.Aim(target - rightWeapon.transform.position);
        leftWeapon.Aim(target - leftWeapon.transform.position);
        crosshair.position = cam.WorldToScreenPoint(target);
    }
}
