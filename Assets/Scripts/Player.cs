using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	VariableManager variableManager;

	public Spawner spawnerScript;

	public GameObject GameObjectVariableManager;

	[HideInInspector]
	public bool enablePlayerV2;

	public GameObject collisionAllPrefab;

	public GameObject asteroidCollisionPrefab;

	void Start()
	{
		variableManager = GameObjectVariableManager.GetComponent<VariableManager>();
	}

	void Update() { }

	private void LayerChange()
	{
		this.gameObject.layer = LayerMask.NameToLayer("Idle");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (variableManager.enableTutorial == false && VariableManager.timeLeft > 10)
		{
			spawnerScript.Invoke("CallRandomSpawner", variableManager.spawnCoolDown);
		}

		if (other.tag == "Astronaut")
		{
			Destroy(other.gameObject);
			var collisionPoint = other.ClosestPoint(transform.position);
			Vector3 prefabSpawnPosition = new Vector3(
				collisionPoint.x,
				collisionPoint.y,
				this.transform.position.z
			);
			Instantiate(collisionAllPrefab, prefabSpawnPosition, Quaternion.identity);

			variableManager.score -= variableManager.alienAstronautAsteroidLaserImpactEnergyCost;
			VariableManager.hitsTakenThisStage++;
			VariableManager.astronautCount--;
			VariableManager.astronautsStruckThisStage++;
		}
		else if (other.tag == "Alien")
		{
			Destroy(other.gameObject);
			var collisionPoint = other.ClosestPoint(transform.position);
			Vector3 prefabSpawnPosition = new Vector3(
				collisionPoint.x,
				collisionPoint.y,
				this.transform.position.z
			);
			Instantiate(collisionAllPrefab, prefabSpawnPosition, Quaternion.identity);

			variableManager.score -= variableManager.alienAstronautAsteroidLaserImpactEnergyCost;
			
			VariableManager.hitsTakenThisStage++;
			VariableManager.alienCount--;
			VariableManager.aliensStruckThisStage++;
		}
		else if (other.tag == "Laser")
		{
			Destroy(other.gameObject);
			var collisionPoint = other.ClosestPoint(transform.position);
			Vector3 prefabSpawnPosition = new Vector3(
				collisionPoint.x,
				collisionPoint.y,
				this.transform.position.z
			);
			Instantiate(collisionAllPrefab, prefabSpawnPosition, Quaternion.identity);

			variableManager.score -= variableManager.alienAstronautAsteroidLaserImpactEnergyCost;
			
			VariableManager.hitsTakenThisStage++;
			VariableManager.laserCount--;
			VariableManager.lasersStruckThisStage++;
		}
		else if (other.tag == "Asteroid")
		{
			Destroy(other.gameObject);
			var collisionPoint = other.ClosestPoint(transform.position);
			Vector3 prefabSpawnPosition = new Vector3(
				collisionPoint.x,
				collisionPoint.y,
				this.transform.position.z
			);
			Instantiate(asteroidCollisionPrefab, prefabSpawnPosition, Quaternion.identity);

			VariableManager.hitsTakenThisStage++;
			VariableManager.asteroidCount--;
			VariableManager.asteroidsStruckThisStage++;
			
			variableManager.score -= variableManager.alienAstronautAsteroidLaserImpactEnergyCost; // lost control soundeffect alert
			variableManager.disableCollider();
			variableManager.Invoke("enableCollider", variableManager.asteroidStunDuration);
		}
	}
}
