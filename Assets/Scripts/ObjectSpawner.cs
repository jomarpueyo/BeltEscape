using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    //Game Mechanics
    public Transform[] spawnPoint; // 9 spawn locations
    public GameObject[] asteroidPrefab; //Of small, med, larg
    int previousIndex;
    bool enableMed     = false;
    bool enableLarg    = false;
    bool lastSpawnLarg = false;

    //Spawning Frequency (Higher is more frequent)
    float freqMedium = 0.25f;
    float freqLarge  = 0.075f;

    //Timing
    public float timeInBetweenSpawns = 0.01f;
    float timeToFirstSpawn           = 1f;
    float timeToStartDecreasing      = 10f;
    float timeMinSpawnRate           = 0.03f;
    float timeSpawnMed               = 20f;
    float timeSpawnLarg              = 35f;
    public float gameTime;

    //Stats and Debugging
    private int[] spawnStats = { 0, 0, 0 };

    // Use this for initialization
    void Update () {
        
        gameTime = Time.timeSinceLevelLoad;

        if (gameTime > timeSpawnMed)
        {
            enableMed = true;
        }

        if (gameTime > timeSpawnLarg)
        {
            enableLarg = true;
        }

        if (Time.time >= timeToFirstSpawn)
        {
            SpawnBlocks();
            timeToFirstSpawn = Time.time + timeInBetweenSpawns;
        }

    }

    void SpawnBlocks()
    {
        float randomSpawn = Random.value;
        int randomIndex = Random.Range(0, spawnPoint.Length-1);

        if (randomIndex == previousIndex)
        {
            if (randomIndex != spawnPoint.Length-1)
            {
                randomIndex += 1;
            }
            else
            {
                randomIndex -= 1;
            }
        }

        /*If random number (0-1) spawn frequency; !!!OPTIMIZE THIS PART!!!*/
        if (randomSpawn <= freqLarge && enableLarg && !lastSpawnLarg)
        {
            /*Create object x, at position y, ??*/
            Instantiate(asteroidPrefab[2], spawnPoint[randomIndex].position, Quaternion.identity);
            lastSpawnLarg = true;
            spawnStats[2] += 1;
        }

        else if (randomSpawn <= freqMedium && enableMed)
        {
            Instantiate(asteroidPrefab[1], spawnPoint[randomIndex].position, Quaternion.identity);
            lastSpawnLarg = false;
            spawnStats[1] += 1;
        }

        else
        {
            Instantiate(asteroidPrefab[0], spawnPoint[randomIndex].position, Quaternion.identity);
            lastSpawnLarg = false;
            spawnStats[0] += 1;
        }

        //Debug.Log(spawnStats);
        previousIndex = randomIndex;

        /*Spawn Rates*/
        if (Time.timeSinceLevelLoad > timeToStartDecreasing)
        {
            timeInBetweenSpawns = (timeToStartDecreasing - timeMinSpawnRate )/ Time.timeSinceLevelLoad + timeMinSpawnRate;
        }

    }
	
}
