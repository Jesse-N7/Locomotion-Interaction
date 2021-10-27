using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{

    public Transform spawnPoint;  //where the object will spawn
    public Rigidbody Prefab;      // what we can select as our object to spawn

    void OnTriggerEnter()
    {

        Instantiate(Prefab, spawnPoint.position, spawnPoint.rotation);
    }

}