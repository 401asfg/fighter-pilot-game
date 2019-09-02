using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [HideInInspector] private bool canShoot;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float shootDelay;

    [SerializeField] private Transform mount;
    [SerializeField] private float maxAngle;

    void Start() {
        canShoot = true;
    }

    public bool Shoot() {
        if(canShoot) {
            GameObject createdProj = Instantiate(projectile, transform.position, Quaternion.identity);
            createdProj.transform.forward = transform.forward;
            canShoot = false;

            StartCoroutine(AllowShooting());

            return true;
        }

        return false;
    }

    private IEnumerator AllowShooting() {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public bool Aim(Vector3 direction) {
        float angle = Vector3.Angle(mount.forward, direction);

        if (angle <= maxAngle) {
            transform.forward = direction;
            return true;
        }

        transform.forward = mount.forward;
        return false;
    }
}
