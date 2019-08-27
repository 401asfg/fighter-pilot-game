using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponControl : MonoBehaviour {
    [SerializeField] private Player player;

    [SerializeField] private Weapon rightWeapon;
    [SerializeField] private Weapon leftWeapon;

    void Update() {
        bool fireRight = Input.GetButton("Fire Right Weapon " + player.index);
        bool fireLeft = Input.GetButton("Fire Left Weapon " + player.index);

        if(fireRight) {
            rightWeapon.Shoot();
        }

        if(fireLeft) {
            leftWeapon.Shoot();
        }
    }
}
