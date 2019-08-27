using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour {
    [SerializeField] private GameObject player;

    public void Spawn(int index) {
        GameObject playerInst = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
        playerInst.transform.parent = null;
        playerInst.GetComponent<Player>().index = index;
    }
}
