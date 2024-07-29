using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    // Start is called before the first frame update
    

    public GameObject listener;


    // Update is called once per frame
    void Update()
    {

        Vector3 thistransformpositionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 listenerpositionOnScreen = Camera.main.WorldToViewportPoint(listener.transform.position);
        Vector3 distanceToShip = this.transform.position;
        Vector3 zeroPoint = new Vector3(0,0,0);
		//Debug.Log(" Distance is" + distanceToShip.magnitude);


        float angle = AngleBetweenTwoPoints(listenerpositionOnScreen, thistransformpositionOnScreen);
        //Debug.Log("Angle is"+ angle);

    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
