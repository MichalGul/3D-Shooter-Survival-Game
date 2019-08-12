using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour {

    public DeadpoolHealth deadpoolHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;





	// Use this for initialization
	void Start ()
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


        Instantiate(enemy, spawnPoints[index].position, spawnPoints[index].rotation); // tworzenie wroga w wylosowanym randomowym punkcie




    }



	
	
}
