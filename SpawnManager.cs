using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    //enemy variables
    public GameObject[] enemyPrefabs;
    public float spawnPosX;
    public float spawnPosZ;
    public float spawnRangeX;
    public float spawnRangeZ;
    public float startDelay;
    public float spawnInterval;

    //powerup variables
    public GameObject[] powerupPrefabs;
    public float spawnPowerupDelay;
    public float spawnPowerupInterval;
    private float spawnRangePowerup = 20;

    void Start()
    {
        InvokeRepeating(("SpawnEnemiesUp"), startDelay, spawnInterval);
        InvokeRepeating(("SpawnEnemiesRight"), startDelay, spawnInterval);
        InvokeRepeating(("SpawnEnemiesLeft"), startDelay, spawnInterval);
        InvokeRepeating(("SpawnEnemiesDown"), startDelay, spawnInterval);
        InvokeRepeating(("SpawnRandomPowerup"), spawnPowerupDelay, spawnPowerupInterval);
    }


    void Update()
    {
        
    }

    void SpawnEnemiesUp()
    {
        int enemyIndexUp = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeZ, spawnRangeZ), 5, spawnPosX);
        Instantiate(enemyPrefabs[enemyIndexUp], spawnPos, enemyPrefabs[enemyIndexUp].transform.rotation);
    }

    void SpawnEnemiesRight()
    {
        int enemyIndexRight = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, 5, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(enemyPrefabs[enemyIndexRight], spawnPos, enemyPrefabs[enemyIndexRight].transform.rotation);
    }

    void SpawnEnemiesLeft()
    {
        int enemyIndexLeft = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(-spawnPosX, 5, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(enemyPrefabs[enemyIndexLeft], spawnPos, enemyPrefabs[enemyIndexLeft].transform.rotation);
    }

    void SpawnEnemiesDown()
    {
        int enemyIndexDown = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeZ, spawnRangeZ), 5, -spawnPosX);
        Instantiate(enemyPrefabs[enemyIndexDown], spawnPos, enemyPrefabs[enemyIndexDown].transform.rotation);
    }

    private Vector3 PowerupSpawnPosition()
    {
        {
            float spawnPowerupPosX = Random.Range(-spawnRangePowerup, spawnRangePowerup);
            float spawnPowerupPosZ = Random.Range(-spawnRangePowerup, spawnRangePowerup);
            Vector3 randomPowerupPos = new Vector3(spawnPowerupPosX, 1, spawnPowerupPosZ);
            return randomPowerupPos;
        }
    }

    void SpawnRandomPowerup()
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], PowerupSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
    }
}
