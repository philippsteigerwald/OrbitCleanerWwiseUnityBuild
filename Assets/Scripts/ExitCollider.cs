using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    private SphereCollider exitCollider;
    public SphereCollider spawner;
    private SphereCollider spawnerRadius;

    VariableManager variableManager;
    public GameObject GameObjectVariableManager;

    void Start()
    {
        spawnerRadius = spawner.GetComponent<SphereCollider>();
        exitCollider = GetComponent<SphereCollider>();

        variableManager = GameObjectVariableManager.GetComponent<VariableManager>();
    }

    void Update() { }

    private void OnTriggerExit(Collider other)
    {
        if (
            other.gameObject.tag == "Asteroid"
            || other.gameObject.tag == "Alien"
            || other.gameObject.tag == "Astronaut"
            || other.gameObject.tag == "Laser"
        )
        {
            Destroy(other.gameObject);

            VariableManager.objectCount--;
        }
    }
}
