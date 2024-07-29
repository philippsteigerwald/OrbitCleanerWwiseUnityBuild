using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using UnityEditor.UIElements;
using UnityEngine;
//using System.Runtime.InteropServices;
using System;
//using TMPro;

public class MouseDirection : MonoBehaviour



{


	// Update is called once per frame
	void Update()
	{

		//Get the Screen positions of the object
		Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

		//Get the Screen position of the mouse
		Vector3 mouseOnScreen = (Vector3)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen) + 90;

		//Ta Daaa
		transform.rotation = Quaternion.Euler(new Vector3(90f, -angle, 0f));

	}




//    public IEnumerator CoroutineAction()
//    {
//        // do some actions here

//        yield return null;
//// wait for 5 frames
//             // do some actions after 5 frames
//    }


	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

}
