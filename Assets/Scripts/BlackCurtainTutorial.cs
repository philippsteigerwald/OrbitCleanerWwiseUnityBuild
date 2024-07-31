using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCurtainTutorial : MonoBehaviour
{
    // Start is called before the first frame update
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
