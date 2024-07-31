using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventClickToInfoFromConsent : MonoBehaviour, IPointerClickHandler //, IPointerDownHandler, IPointerEnterHandler
{
    public GameObject consentCanvas;
    public GameObject infoCanvasActionMode;

    public GameObject infoCanvasNonActionMode;

    public Toggle consentCheckBox;
    public Toggle groupOne;
    public Toggle groupTwo;

    public AK.Wwise.Event uiClick;
    public AK.Wwise.Event welcomeSound;

    public VariableManager variableManager;

    private void Awake()
    {
        variableManager.CheckID();
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
        if (consentCheckBox.isOn && groupOne.isOn && !groupTwo.isOn)
        {
            variableManager.groupOne = true;
            variableManager.groupTwo = false;
            welcomeSound.Post(gameObject);

            consentCanvas.SetActive(false);

            infoCanvasActionMode.SetActive(true);

            variableManager.GenerateRandomID();
        }
        else if (consentCheckBox.isOn && groupTwo.isOn && !groupOne.isOn)
        {
            variableManager.groupTwo = true;
            variableManager.groupOne = false;
            welcomeSound.Post(gameObject);

            variableManager.enableV2 = true;
            consentCanvas.SetActive(false);
            infoCanvasNonActionMode.SetActive(true);

            variableManager.GenerateRandomID();
        }
    }
}
