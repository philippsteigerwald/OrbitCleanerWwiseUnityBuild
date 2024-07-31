using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpawnPrefab : MonoBehaviour
{
    VariableManager variableManager;

    void Start()
    {
        Destroy(this.gameObject, 0.01f);
    }

    void Update() { }
}
