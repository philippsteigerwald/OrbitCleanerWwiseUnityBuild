using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour
{
	
	[HideInInspector]
	public float speed;
	private Rigidbody _rigidbody;
	
	[HideInInspector]
	public float spawnDelay;
	
	[HideInInspector]
	public Vector3 spawnerPosition;
	

	Vector3 finalDirection;
	

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();

	
		

	}

	private void Start()
	{


		  transform.Rotate (Vector3.left * -90); 
		  this.gameObject.SetActive(false);
		  var moveDirection = spawnerPosition - this.transform.position;
		  
		  Invoke(nameof(ActivateAfterDelay),spawnDelay);	
		  finalDirection = moveDirection; // * trajectory variance	

		if ( this.gameObject.tag == "Asteroid")
		{
			speed *= 2;
		}  
		  
		  
	}
	
	public void Update()
	{
		Vector3 distanceToShip = this.transform.position;

		AkSoundEngine.SetRTPCValue("distanceToShip", distanceToShip.magnitude);	


		
		float distanceThisFrame = (speed / 5) * Time.deltaTime;
		transform.Translate(finalDirection * distanceThisFrame, Space.World);
		
		AkSoundEngine.SetRTPCValue("straightSpeed", speed);
		//Debug.Log ("straight" + speed);
	}


		
	private void ActivateAfterDelay()
		
		
	{
		this.gameObject.SetActive(true);
	}
	
	

	



}
