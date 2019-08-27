using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [HideInInspector] private bool canShoot;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float shootDelay;

    void Start() {
        canShoot = true;
    }

    public void Shoot() {
        if(canShoot) {
            GameObject createdProj = Instantiate(projectile, transform.position, Quaternion.identity);
            createdProj.transform.forward = transform.forward;
            canShoot = false;

            StartCoroutine(AllowShooting());
        }
    }

    private IEnumerator AllowShooting() {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
