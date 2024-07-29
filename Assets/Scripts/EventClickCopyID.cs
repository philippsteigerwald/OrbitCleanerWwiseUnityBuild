using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class EventClickCopyID : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, IPointerEnterHandler

{
	// Start is called before the first frame update
	
	public VariableManager variableManager;
	
	public AK.Wwise.Event uiClick;
	
	
	
	void Awake()
	{
		
	}

	// Update is called once per frame
	
	
	
	
	
	
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
			
			//Clipboard.SetText(variableManager.subjectID);
			CopyToClipboard();
			variableManager.Quit();
			//Screen.fullScreen = false;
			//variableManager.enableV2 = !variableManager.enableV2;
			//variableManager.StartGame
	}
	
	public void CopyToClipboard()
	{
		TextEditor textEditor = new TextEditor();
		textEditor.text = variableManager.subjectID;
		textEditor.SelectAll();
		textEditor.Copy();	
	}

	


}