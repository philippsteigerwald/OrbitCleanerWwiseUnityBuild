using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{

    private SphereCollider exitCollider;
    public SphereCollider spawner;
    private SphereCollider spawnerRadius;

    //Spawner spawner;
    //public GameObject Spawner;

    VariableManager variableManager;
    public GameObject GameObjectVariableManager;
     
    


    // Start is called before the first frame update
    void Start()
    {
        spawnerRadius = spawner.GetComponent<SphereCollider>();
        exitCollider = GetComponent<SphereCollider>();


        //exitCollider.transform.localScale = new Vector3((spawner.spawnDistance + 1) * Mathf.Sin(45), (spawner.spawnDistance + 1) * Mathf.Cos(45), 1);
        //exitCollider.radius = (spawner.radius + 1);


        variableManager = GameObjectVariableManager.GetComponent<VariableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Alien" || other.gameObject.tag == "Astronaut" || other.gameObject.tag == "Laser" )
        {
            Destroy(other.gameObject);

            VariableManager.objectCount--;
             
            //variableManager.score -= 10;


        }
    }
}
