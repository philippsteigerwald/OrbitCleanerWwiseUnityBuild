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

	public VariableManager variableManager; // Script


	//private int timeShift = 2;

	


	void OnEnable()
	{

		// if (enableTutorial == false)
		// {
		// 	InvokeRepeating(nameof(CallRandomSpawner), 2, spawnCoolDown); // start Spawning once Spawner is enabled in VariableManager
		// }

	}




	void Update()
	{

	nextInvertChange = variableManager.nextInvertSwitch;

			
	}


	


	
	
	// 	public enum SpawnerType
	// {
		
	// 	Asteroid, //0 
	// 	Laser,  //1
	// 	Alien, //2
	// 	Astronaut //3
	// }

	// public void RandomSpawner(Enum enumToTake, float upperBoundaryObjects )
	// {
		
	//string[] objectStringAll = { "Astronaut", "Laser", "Alien", "Asteroid" };
			
	//string allObjects = objectStringAll[Random.Range(0, upperBoundaryObjects)];		
		
	public void CallRandomSpawner()
	{	
		objectList = new List<string>();	
		print(" CallRandomSpawner: ive been called");
		objectList.Clear();
		System.Random rnd = new System.Random(); 
		
		
		if (sameSpawns == true && VariableManager.timeLeft > 6)// && (VariableManager.objectCount < variableManager.spawnCap))
		{
			if (astronautActive == true)
			{	
				//print("Astronaut");
				objectList.Add("Astronaut");
			}	
			
				if (alienActive == true)
				{
					objectList.Add("Alien");
					//print("Alien");
				}
		
					if (laserActive == true && enableSpawnerV2 == false)
					{
						objectList.Add("Laser");
						//print("Laser");
					}
			
						if (asteroidActive == true && enableSpawnerV2 == false && VariableManager.timeLeft > 15f) // stop spawnig asteroids late in the level
						{
							objectList.Add("Asteroid");
							//print("Astronaut");
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
		
		// Can easily add and remove elements
		

		
		else if (sameSpawns == false && VariableManager.timeLeft > 6)// && (VariableManager.objectCount < variableManager.spawnCap)) 
			{
			// build the List of availabe obejcts ( objects that are not yet in the scene)
			if (VariableManager.astronautCount == 0 && astronautActive == true)
			{	
				//print("Astronaut");
				objectList.Add("Astronaut");
			}	
			
				if (VariableManager.alienCount == 0 && alienActive == true)
				{
					objectList.Add("Alien");
					//print("Alien");
				}
		
					if (VariableManager.laserCount == 0 && laserActive == true && enableSpawnerV2 == false)
					{
						objectList.Add("Laser");
						//print("Laser");
					}
			
						if (VariableManager.asteroidCount == 0 && asteroidActive == true && enableSpawnerV2 == false && VariableManager.timeLeft > 15f) // stop spawnig asteroids late in the level
						{
							objectList.Add("Asteroid");
							//print("Astronaut");
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
		//print(" RandomSpawner: ive been called");
		
		
		//SpawnerType st = (SpawnerType)(Random.Range(lowerBoundaryObjects,upperBoundaryObjects)); // change range for variety 0 - 4

		switch (objectToSpawn)
		{
			//case SpawnerType.Astronaut:
			
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

			Vector3 spawnPosition = new Vector3( this.transform.position.x, 0,  this.transform.position.z) + new Vector3(Random.insideUnitSphere.x, 0 , Random.insideUnitSphere.z ).normalized * spawnDistanceStraight;

			
			if (enableSpawnerV2 == true) // This is for v2
			{
				if ((this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z && spawnPosition.z <= this.transform.position.z + spawnDistanceCircular - variableManager.topSpawnAngleV2)
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
	
			Vector3 spawnPosition = new Vector3( this.transform.position.x, 0,  this.transform.position.z) + new Vector3(Random.insideUnitSphere.x, 0 , Random.insideUnitSphere.z ).normalized * spawnDistanceStraight;


			if (enableSpawnerV2 == true) // This is for v2
			{
				if ((this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z && spawnPosition.z <= this.transform.position.z + spawnDistanceCircular - variableManager.topSpawnAngleV2)
				
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
		
		Vector3 spawnPosition = new Vector3( this.transform.position.x, 0,  this.transform.position.z) + new Vector3(Random.insideUnitSphere.x, 0 , Random.insideUnitSphere.z ).normalized * spawnDistanceCircular;
			
			
		if (enableSpawnerV2 == true) // This is for v2
			{
				if ((this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z && spawnPosition.z <= this.transform.position.z + spawnDistanceCircular - variableManager.topSpawnAngleV2)
				
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
		Vector3 spawnPosition = new Vector3( this.transform.position.x, 0,  this.transform.position.z) + new Vector3(Random.insideUnitSphere.x, 0 , Random.insideUnitSphere.z ).normalized * spawnDistanceCircular;
			
		if (enableSpawnerV2 == true) // This is for v2
			{
				if ((this.transform.position.z + variableManager.bottomSpawnAngleV2) <= spawnPosition.z && spawnPosition.z <= this.transform.position.z + spawnDistanceCircular - variableManager.topSpawnAngleV2)
				//if (Enumerable.Range(this.transform.position.z + variableManager.bottomSpawnAngleV2,this.transform.position.z + spawnDistanceCircular - variableManager.topSpawnAngleV2).Contains(spawnPosition.z)) 
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