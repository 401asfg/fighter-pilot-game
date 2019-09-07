using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponControl : MonoBehaviour {
    //Ship Component References
    [SerializeField] private Player player;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform aimingBody;
    [SerializeField] private RectTransform crosshair;

    //Weapon References
    [SerializeField] private Weapon rightWeapon;
    [SerializeField] private Weapon leftWeapon;

    //Aiming Parameters
    [SerializeField] private LayerMask aimRayLayers;
    [SerializeField] private float aimRayDistance;
    [SerializeField] private float crosshairAcceleration;

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
        Ray ray = new Ray(aimingBody.position, aimingBody.forward);
        RaycastHit hit;
        Vector3 target;

        if(Physics.Raycast(ray, out hit, aimRayDistance, aimRayLayers)) {
            target = hit.point;
        }

        else {
            target = (aimRayDistance * aimingBody.forward + aimingBody.position);
        }

        rightWeapon.Aim(target - rightWeapon.transform.position);
        leftWeapon.Aim(target - leftWeapon.transform.position);

        if(cam.gameObject != aimingBody.gameObject) {
            crosshair.position = Vector3.Lerp(crosshair.position, cam.WorldToScreenPoint(target), Time.deltaTime * crosshairAcceleration);
        }
    }
}
