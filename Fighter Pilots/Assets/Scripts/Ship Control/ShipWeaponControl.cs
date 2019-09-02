using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponControl : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private Transform mainCamera;

    [SerializeField] private Weapon rightWeapon;
    [SerializeField] private Weapon leftWeapon;

    [SerializeField] private LayerMask aimRayLayers;
    [SerializeField] private float aimRayDistance;

    void Update() {
        //Input
        bool fireRight = Input.GetButton("Fire Right Weapon " + player.index);
        bool fireLeft = Input.GetButton("Fire Left Weapon " + player.index);

        //Shoot
        if (fireRight) {
            rightWeapon.Shoot();
        }

        if (fireLeft) {
            leftWeapon.Shoot();
        }

        //Aim
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, aimRayDistance, aimRayLayers)) {
            rightWeapon.Aim(hit.point - rightWeapon.transform.position);
            leftWeapon.Aim(hit.point - leftWeapon.transform.position);
        }

        else {
            rightWeapon.Aim(mainCamera.forward);
            leftWeapon.Aim(mainCamera.forward);
        }
    }
}
