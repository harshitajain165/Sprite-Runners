using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    public GameObject reward1;
    private Vector3 spawnPos1 = new Vector3(25,0, 0);
    private Vector3 spawnPos2 = new Vector3(235,0, 0);
    private Vector3 spawnPos3 = new Vector3(20,6, 0);
    private float StartDelay = 2.0f;
    private float repeatRate = 1.9f;
    private float StartDelay2 = 10.0f;
    private float repeatRate2 =  8.5f;
    private float StartDelay3 = 2.0f;
    private float repeatRate3 =  8.5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle1", StartDelay, repeatRate);
        InvokeRepeating("SpawnObstacle2", StartDelay2, repeatRate2);
        InvokeRepeating("SpawnObstacle3", StartDelay3, repeatRate3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle1(){

        if(playerControllerScript.gameOver == false){
        Instantiate(obstaclePrefab1, spawnPos1, obstaclePrefab1.transform.rotation);}
        // Instantiate(obstaclePrefab2, spawnPos2, obstaclePrefab2.transform.rotation);

    }
    void SpawnObstacle2(){
        if(playerControllerScript.gameOver == false){
        Instantiate(obstaclePrefab2, spawnPos2, obstaclePrefab2.transform.rotation);}
    //      Instantiate(obstaclePrefab2, spawnPos, obstaclePrefab2.transform.rotation);

    
    }

    void SpawnObstacle3(){
        if(playerControllerScript.gameOver == false){
        Instantiate(reward1, spawnPos3, reward1.transform.rotation);}
        //  Instantiate(obstaclePrefab2, spawnPos, reward1.transform.rotation);

    
    }
}
