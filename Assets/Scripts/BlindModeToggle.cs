using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BlindModeToggle : MonoBehaviour, IPointerClickHandler
{
    //public Canvas tutorialCanvas;

    public VariableManager variableManager;

    public TextMeshProUGUI blindTextBox;

    public GameObject blackCurtainObject;

    public AK.Wwise.Event uiClick;

    private bool toggleBool = false;

    public void Start() { }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            uiClick.Post(gameObject);
            StartCoroutine(EventDelay());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        uiClick.Post(gameObject);
        StartCoroutine(EventDelay());
    }

    private IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(0.1f);

        StartEvent();
    }

    private void StartEvent()
    {
        if (variableManager.blackCurtainActive == false)
        {
            blindTextBox.text = "BlindModeOn";
            gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                201 / 360,
                84 / 100,
                88 / 100
            );
        }
        else
        {
            blindTextBox.text = "BlindModeOff";

            gameObject.GetComponent<Renderer>().material.color = new Color32(35, 157, 224, 65);
        }

        if (variableManager.enableTutorial == true)
        {
            toggleBool = !toggleBool;

            blackCurtainObject.SetActive(toggleBool);
        }
    }
}
