using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    public GameObject listener;

    void Update()
    {
        Vector3 thistransformpositionOnScreen = Camera.main.WorldToViewportPoint(
            transform.position
        );
        Vector3 listenerpositionOnScreen = Camera.main.WorldToViewportPoint(
            listener.transform.position
        );
        Vector3 distanceToShip = this.transform.position;
        Vector3 zeroPoint = new Vector3(0, 0, 0);

        float angle = AngleBetweenTwoPoints(
            listenerpositionOnScreen,
            thistransformpositionOnScreen
        );
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
