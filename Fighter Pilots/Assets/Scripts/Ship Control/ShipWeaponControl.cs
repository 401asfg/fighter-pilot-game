using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponControl : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private Transform mainCamera;

    [SerializeField] private Weapon rightWeapon;
    [SerializeField] private Weapon leftWeapon;

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
        bool canUseRight = rightWeapon.Aim(mainCamera.forward);
        bool canUseLeft = leftWeapon.Aim(mainCamera.forward);
    }
}
