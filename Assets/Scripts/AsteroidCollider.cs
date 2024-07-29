using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{




	[HideInInspector]
	public float nextActionTime;



	public VariableManager variableManager;

	public GameObject asteroidActionPrefab;
	public GameObject collectedAllPrefab;
	public GameObject player;


	public Spawner spawnerScript;
	public GameObject Blink;


	//public AK.Wwise.RTPC astronautCollisionValue;
	//AsteroidShieldSound.Post(gameObject);
	//astronautCollisionValue.SetGlobalValue(0);
	//var direction = rotation * Vector3.forward; turn rotation to a vector

	void Start()
	{



	}
	
	void OnEnable()
	{
			if(variableManager.enableV2 == true)
		{
			this.gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
	{
		

	if (Input.GetKeyDown(KeyCode.R))
	{
		VariableManager.buttonsPressedThisStage++; 
	}

		if (Input.GetKeyDown(KeyCode.R) & Time.time > nextActionTime && variableManager.inTransition == false)
		{
			this.gameObject.layer = LayerMask.NameToLayer("Spacecraft");
			nextActionTime = Time.time + variableManager.actionCooldownTime;
			//InvokeRepeating("LayerChange", 0.1f, 1);
			Invoke(nameof(LayerChange), 0.1f);
			Instantiate(asteroidActionPrefab, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
			variableManager.score -= variableManager.laserAsteroidEnergyCost;
			//tutorialVariableManager.score -= tutorialVariableManager.laserAsteroidEnergyCost;
			
			VariableManager.actionsExecutedThisStage++;
			
		if (variableManager.blackCurtainActive == false)
		{
			StartCoroutine(BlinkDelay());
		}






	}
}
	
	private IEnumerator BlinkDelay()
	{
			if (variableManager.stunned == false && variableManager.inTransition == false)
			
			Blink.SetActive(true);
			yield return new WaitForSeconds(0.1f);
			StartCoroutine(BlinkDelay1());
	}

private IEnumerator BlinkDelay1()
	{
		Blink.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		StartCoroutine(BlinkDelay2());
	}
	



private IEnumerator BlinkDelay2()
	{
			if (variableManager.stunned == false && variableManager.inTransition == false)
			
			Blink.SetActive(true);
			yield return new WaitForSeconds(0.1f);
			StartCoroutine(BlinkDelay3());
	}

private IEnumerator BlinkDelay3()
	{
		Blink.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		StartCoroutine(BlinkDelay4());
	}	

private IEnumerator BlinkDelay4()
	{
			if (variableManager.stunned == false && variableManager.inTransition == false)
			
			Blink.SetActive(true);
			yield return new WaitForSeconds(0.1f);
			BlinkDelay5();
	}	

private void BlinkDelay5()
	{
		Blink.SetActive(false);
	}	

	private void LayerChange()
	{
		this.gameObject.layer = LayerMask.NameToLayer("Idle");

	}


	private void OnTriggerEnter(Collider other)
	{


		if (other.tag == "Asteroid")
		{

			Destroy(other.gameObject);
			var collisionPoint = other.ClosestPoint(transform.position);
			Vector3 prefabSpawnPosition = new Vector3(collisionPoint.x, collisionPoint.y, collisionPoint.z);
			Instantiate(collectedAllPrefab, prefabSpawnPosition, Quaternion.identity);
			 
			variableManager.score += variableManager.alienAstronautAsteroidCollectionEnergyGain;
			//tutorialVariableManager.score += tutorialVariableManager.alienAstronautAsteroidCollectionEnergyGain;
			
			VariableManager.sucessfullHitsThisStage++;
			VariableManager.asteroidCount--;
			VariableManager.asteroidsDestroyedThisStage++;

		if (variableManager.enableTutorial == false && VariableManager.timeLeft > 10)
		{
			spawnerScript.Invoke("CallRandomSpawner",variableManager.spawnCoolDown);
		}


			
			

		}
	}
}