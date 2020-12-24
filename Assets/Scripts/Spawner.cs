using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public float spawnAngleMax;
    public Vector2 spawnSizeMinMax;
    public GameObject[] asteroids;
    float nextSpawnTime;
    Vector2 screenHalfSize;
    
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime){
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);          
            // GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition , Quaternion.Euler(Vector3.forward * spawnAngle));
            // newBlock.transform.localScale = Vector3.one * spawnSize;

            //Spawn asteroid
            GameObject randomAsteroid = asteroids[Random.Range(0,asteroids.Length)];
            Vector2 asteroidSpawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);  
            //GameObject newAsteroid = (GameObject)
            Instantiate(randomAsteroid, asteroidSpawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));           
        }
    }

}
