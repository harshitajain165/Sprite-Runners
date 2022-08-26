using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    private Vector3 spawnPos1 = new Vector3(25,8, -2);
    private Vector3 spawnPos2 = new Vector3(32,8, -2);
    private float StartDelay = 2.0f;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle1", StartDelay, repeatRate);
        InvokeRepeating("SpawnObstacle2", StartDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle1(){
        Instantiate(obstaclePrefab1, spawnPos1, obstaclePrefab1.transform.rotation);
        // Instantiate(obstaclePrefab2, spawnPos, obstaclePrefab2.transform.rotation);

    }
    void SpawnObstacle2(){
        Instantiate(obstaclePrefab2, spawnPos2, obstaclePrefab2.transform.rotation);
        // Instantiate(obstaclePrefab2, spawnPos, obstaclePrefab2.transform.rotation);

    }
}
