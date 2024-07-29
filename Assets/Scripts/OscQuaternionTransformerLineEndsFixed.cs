using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscSimpl;

public class OscQuaternionTransformerLineEndsFixed : MonoBehaviour
{
	// Quaternion values
	private float qw;
	private float qx;
	private float qy;
	public float qz;

	public Quaternion headTrackerRotation; // The current Quaternion value of the head tracker
	//Quaternion baselineRotation; // The baseline Quaternion value
	//public float lerpSpeed = 20.0f; // The speed of the interpolation
	
	

	void Start()
	{
		headTrackerRotation = Quaternion.identity;
		//transform.Rotate (Vector3.left * -90); 
		//baselineRotation = Quaternion.identity;
		//InvokeRepeating("UpdateHeadRotation", 0, 0.01f);
		
	}

	private void UpdateHeadRotation() // rotates the Object
	{
		//Quaternion relativeRotation = headTrackerRotation * baselineRotation;
		//Debug.Log(Time.deltaTime);
		//this.transform.rotation = Quaternion.Slerp(this.transform.localRotation, relativeRotation, Time.deltaTime * lerpSpeed);
		this.transform.rotation = headTrackerRotation;

		this.transform.Rotate (Vector3.left * -90); // this is from me?
		
		
	}


	public void SetRotationValue(OscMessage message)
	{
		// Extract quaterion out of OSC message
		message.TryGet(0, out qw);
		message.TryGet(1, out qx);
		message.TryGet(2, out qy);
		message.TryGet(3, out qz);
		headTrackerRotation = new( 0, -qz, 0, qw);
		//headTrackerRotation = new(-qx, -qz, -qy, qw);
		UpdateHeadRotation();

	}

  
}
