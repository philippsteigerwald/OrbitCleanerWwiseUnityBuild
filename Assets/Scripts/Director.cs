using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{

    public AK.Wwise.Event mouseLocatorStart;
    public AK.Wwise.Event mouseLocatorStop;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseLocatorStart.Post(gameObject);
        }

         if (Input.GetMouseButtonUp(0))
        {
            mouseLocatorStop.Post(gameObject);
        }
    }

// INstantiate at MousePosition???

}



