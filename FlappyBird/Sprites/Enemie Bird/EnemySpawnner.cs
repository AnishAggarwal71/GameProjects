using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject GameObjectSpawn;
    private GameObject Clone;
    public float timeToSpawn = 4f;
    public float firstSpawn = 10f;

    // Update is called once per frame
    void Update()
    {
        firstSpawn -= Time.deltaTime;
        if(firstSpawn <= 0f)
        {
            Clone = Instantiate(GameObjectSpawn, gameObject.transform.position, Quaternion.identity) as GameObject;
            firstSpawn = timeToSpawn;
        }
    }
}
