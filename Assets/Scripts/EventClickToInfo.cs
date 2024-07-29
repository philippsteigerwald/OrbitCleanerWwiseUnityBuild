using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EventClickToInfo : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, IPointerEnterHandler

{

	//public Canvas tutorialCanvas;	
	
	public GameObject infoCanvas;
	public GameObject infoCanvasV2;
	public VariableManager variableManager;
	
	public AK.Wwise.Event uiClick;
	
	public void OnPointerClick(PointerEventData eventData)
	{
		//GameObject.FindWithTag("InfoCanvas").SetActive(true);
		
		//tutorialCanvas.enabled = false;
		uiClick.Post(gameObject);
		StartCoroutine(EventDelay());
			
		//canvas.enabled = false;
		
		
	}
	
		private IEnumerator EventDelay()
	{
		yield return new WaitForSeconds(0.1f);
		
		StartEvent();
	}
	
	private void StartEvent()
	{
		variableManager.disableCollider();
		variableManager.KillAllGameobjects();
		//allUIElements.SetActive(false);
		
		if(variableManager.enableV2 == true)
		{
			infoCanvasV2.SetActive(true);
		}
		else
		{
			infoCanvas.SetActive(true);
		
		}
		
	}
	

}

