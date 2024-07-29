using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpawnPrefab : MonoBehaviour
{



	VariableManager variableManager;
	

	void Start()
	{

		Destroy(this.gameObject, 0.01f);
		//transform.Rotate (Vector3.left * -90); 
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
