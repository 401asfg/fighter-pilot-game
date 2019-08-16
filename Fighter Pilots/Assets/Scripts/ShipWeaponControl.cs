using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponControl : MonoBehaviour {
    [HideInInspector] private float rightDelay;
    [HideInInspector] private float leftDelay;

    [SerializeField] private Transform rightWeapon;
    [SerializeField] private Transform leftWeapon;
    [SerializeField] private GameObject projectile;

    [SerializeField] private float fireRate;

    void Start() {
        rightDelay = 0f;
        leftDelay = 0f;
    }

    void Update() {
        bool fireRight = Input.GetButton("Fire Right Weapon");
        bool fireLeft = Input.GetButton("Fire Left Weapon");

        if(fireRight && rightDelay <= 0f) {
            GameObject createdProj = Instantiate(projectile, rightWeapon.position, Quaternion.identity);
            createdProj.transform.forward = rightWeapon.forward;
            rightDelay = 1f / fireRate;
        }

        if(fireLeft && leftDelay <= 0f) {
            GameObject createdProj = Instantiate(projectile, leftWeapon.position, Quaternion.identity);
            createdProj.transform.forward = leftWeapon.forward;
            leftDelay = 1f / fireRate;
        }

        rightDelay = rightDelay > 0f ? rightDelay - Time.deltaTime : 0f;
        leftDelay = leftDelay > 0f ? leftDelay - Time.deltaTime : 0f;
    }
}
