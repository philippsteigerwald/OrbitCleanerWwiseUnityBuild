using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventClickCopyID : MonoBehaviour, IPointerClickHandler //, IPointerDownHandler, IPointerEnterHandler
{
    public VariableManager variableManager;

    public AK.Wwise.Event uiClick;

    void Awake() { }

    public void OnPointerClick(PointerEventData eventData)
    {
        uiClick.Post(gameObject);
        StartCoroutine(EventDelay());
        Debug.Log("been clicked");
    }

    private IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(0.15f);

        StartEvent();
    }

    private void StartEvent()
    {
        CopyToClipboard();
        variableManager.Quit();
    }

    public void CopyToClipboard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = variableManager.subjectID;
        textEditor.SelectAll();
        textEditor.Copy();
    }
}
