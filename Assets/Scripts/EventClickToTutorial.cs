using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EventClickToTutorial : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, IPointerEnterHandler

{

	//public Canvas tutorialCanvas;	
	public VariableManager variableManager;
	public GameObject infoCanvas;

	public GameObject tutorialBackGround;
	

	public AK.Wwise.Event uiClick;
	
	
	
	
	public void OnPointerClick(PointerEventData eventData)
	{

		
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
		variableManager.enableTutorial = true;
		variableManager.enableCollider();
		tutorialBackGround.SetActive(true);
		infoCanvas.SetActive(false);
		variableManager.Reconfiguration();
		variableManager.scoreTimerInfoFolder.SetActive(true);
		//variableManager.allUIElements(true);
		
	}

}

