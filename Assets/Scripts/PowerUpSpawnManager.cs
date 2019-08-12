using UnityEngine;
using System.Collections;

public class PowerUpSpawnManager : MonoBehaviour {

    public DeadpoolHealth deadpoolHealth;
    public GameObject[] powerUps;
    public float spawnTime = 8f;
    public Transform[] spawnPoints;





    // Use this for initialization
    void Start()
    {

        InvokeRepeating("SpawnEnemys", spawnTime, spawnTime);

    }

    void SpawnEnemys()
    {

        if (deadpoolHealth.currentHealth <= 0f)
        {
            return;
        }

        int index = Random.Range(0, spawnPoints.Length); //losowanie punktu spawnu
        int randomPower = Random.Range(0, powerUps.Length);


        Instantiate(powerUps[randomPower], spawnPoints[index].position, spawnPoints[index].rotation); // tworzenie losowego power upa w wylosowanym randomowym punkcie




    }




}
