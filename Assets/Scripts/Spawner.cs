using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [HideInInspector]
    public int trajectoryVariance;

    [HideInInspector]
    public int spawnCap;

    [HideInInspector]
    public float spawnCoolDown;

    [HideInInspector]
    public int spawnDistanceStraight;

    [HideInInspector]
    public int spawnDistanceCircular;

    private float nextInvertChange;

    [HideInInspector]
    public bool astronautActive;

    [HideInInspector]
    public bool alienActive;

    [HideInInspector]
    public bool laserActive;

    [HideInInspector]
    public bool asteroidActive;

    [HideInInspector]
    public bool sameSpawns;

    [HideInInspector]
    public bool invertRotationOn;

    [HideInInspector]
    public bool enableSpawnerV2;

    [HideInInspector]
    public bool enableTutorial;

    public List<string> objectList;

    public GameObject asteroidPrefab;
    public GameObject astronautPrefab;
    public GameObject laserPrefab;
    public GameObject alienPrefab;

    public CircularMovement astronautPrefabScript;
    public CircularMovement alienPrefabScript;

    private Rigidbody2D _rigidbody;

    public VariableManager variableManager;

    void OnEnable() { }

    void Update()
    {
        nextInvertChange = variableManager.nextInvertSwitch;
    }

    public void CallRandomSpawner()
    {
        objectList = new List<string>();
        print(" CallRandomSpawner: ive been called");
        objectList.Clear();
        System.Random rnd = new System.Random();

        if (sameSpawns == true && VariableManager.timeLeft > 6)
        {
            if (astronautActive == true)
            {
                objectList.Add("Astronaut");
            }

            if (alienActive == true)
            {
                objectList.Add("Alien");
            }

            if (laserActive == true && enableSpawnerV2 == false)
            {
                objectList.Add("Laser");
            }

            if (
                asteroidActive == true
                && enableSpawnerV2 == false
                && VariableManager.timeLeft > 15f
            ) // stop spawnig asteroids late in the level
            {
                objectList.Add("Asteroid");
            }

            if (objectList.Count != 0)
            {
                int randomInt = rnd.Next(objectList.Count);
                string randomObjectToSpawn = objectList[randomInt];
                RandomSpawner(randomObjectToSpawn);
            }
            else
            {
                return;
            }
        }
        else if (sameSpawns == false && VariableManager.timeLeft > 6)
        {
            // build the List of availabe obejcts (objects that are not yet in the scene)
            if (VariableManager.astronautCount == 0 && astronautActive == true)
            {
                objectList.Add("Astronaut");
            }

            if (VariableManager.alienCount == 0 && alienActive == true)
            {
                objectList.Add("Alien");
            }

            if (VariableManager.laserCount == 0 && laserActive == true && enableSpawnerV2 == false)
            {
                objectList.Add("Laser");
            }

            if (
                VariableManager.asteroidCount == 0
                && asteroidActive == true
                && enableSpawnerV2 == false
                && VariableManager.timeLeft > 15f
            ) // stop spawnig asteroids late in the level
            {
                objectList.Add("Asteroid");
            }

            if (objectList.Count != 0)
            {
                int randomInt = rnd.Next(objectList.Count);
                string randomObjectToSpawn = objectList[randomInt];
                RandomSpawner(randomObjectToSpawn);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    public void RandomSpawner(string objectToSpawn)
    {
        switch (objectToSpawn)
        {
            case ("Astronaut"):

                SpawnAstronaut();
                break;

            case ("Laser"):

                SpawnLaser();
                break;

            case ("Alien"):

                SpawnAlien();
                break;

            case ("Asteroid"):

                SpawnAsteroid();
                break;

            default:
                print("that was default?");
                break;
        }
    }

    public void SpawnAsteroid()
    {
        Vector3 spawnPosition =
            new Vector3(this.transform.position.x, 0, this.transform.position.z)
            + new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized
                * spawnDistanceStraight;

        if (enableSpawnerV2 == true) // This is for v2
        {
            if (
                (this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z
                && spawnPosition.z
                    <= this.transform.position.z
                        + spawnDistanceCircular
                        - variableManager.topSpawnAngleV2
            )
            {
                Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

                VariableManager.asteroidCount++;
                VariableManager.asteroidsSpawnedThisStage++;
            }
            else
            {
                SpawnAsteroid();
            }
        }
        else
        {
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            VariableManager.asteroidCount++;
            VariableManager.asteroidsSpawnedThisStage++;
        }
    }

    public void SpawnLaser()
    {
        Vector3 spawnPosition =
            new Vector3(this.transform.position.x, 0, this.transform.position.z)
            + new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized
                * spawnDistanceStraight;

        if (enableSpawnerV2 == true) // This is for v2
        {
            if (
                (this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z
                && spawnPosition.z
                    <= this.transform.position.z
                        + spawnDistanceCircular
                        - variableManager.topSpawnAngleV2
            )
            {
                Instantiate(laserPrefab, spawnPosition, Quaternion.identity);

                VariableManager.laserCount++;
                VariableManager.lasersSpawnedThisStage++;
            }
            else
            {
                SpawnLaser();
            }
        }
        else
        {
            Instantiate(laserPrefab, spawnPosition, Quaternion.identity);

            VariableManager.laserCount++;
            VariableManager.lasersSpawnedThisStage++;
        }
    }

    public void SpawnAstronaut()
    {
        Vector3 spawnPosition =
            new Vector3(this.transform.position.x, 0, this.transform.position.z)
            + new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized
                * spawnDistanceCircular;

        if (enableSpawnerV2 == true) // This is for v2
        {
            if (
                (this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z
                && spawnPosition.z
                    <= this.transform.position.z
                        + spawnDistanceCircular
                        - variableManager.topSpawnAngleV2
            )
            {
                Instantiate(astronautPrefab, spawnPosition, Quaternion.identity);

                VariableManager.astronautCount++;
                VariableManager.astronautsSpawnedThisStage++;
            }
            else
            {
                SpawnAstronaut();
            }
        }
        else
        {
            Instantiate(astronautPrefab, spawnPosition, Quaternion.identity);

            VariableManager.astronautCount++;
            VariableManager.astronautsSpawnedThisStage++;

            if (invertRotationOn == true && Time.time > nextInvertChange && enableTutorial == false)
            {
                nextInvertChange = Time.time + variableManager.nextInvertSwitch;
                astronautPrefabScript.ChangeRotation();
            }
        }
    }

    public void SpawnAlien()
    {
        Vector3 spawnPosition =
            new Vector3(this.transform.position.x, 0, this.transform.position.z)
            + new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized
                * spawnDistanceCircular;

        if (enableSpawnerV2 == true) // This is for v2
        {
            if (
                (this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z
                && spawnPosition.z
                    <= this.transform.position.z
                        + spawnDistanceCircular
                        - variableManager.topSpawnAngleV2
            )
            {
                Instantiate(alienPrefab, spawnPosition, Quaternion.identity);
                VariableManager.alienCount++;
                VariableManager.aliensSpawnedThisStage++;
            }
            else
            {
                SpawnAlien();
            }
        }
        else
        {
            Instantiate(alienPrefab, spawnPosition, Quaternion.identity);

            VariableManager.alienCount++;
            VariableManager.aliensSpawnedThisStage++;

            if (invertRotationOn == true && Time.time > nextInvertChange && enableTutorial == false)
            {
                nextInvertChange = Time.time + variableManager.nextInvertSwitch;
                alienPrefabScript.ChangeRotation();
            }
        }
    }
}
