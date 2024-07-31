using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCurtainTutorial : MonoBehaviour
{

    public VariableManager variableManager;

    public void OnEnable()
    {
        variableManager.ActivateBlackCurtain();
    }

    public void OnDisable()
    {
        variableManager.DeactivateBlackCurtain();
    }
}
