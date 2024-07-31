using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    void Start() { }

    void Update()
    {
        if (VariableManager.timeLeft == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
