using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EventClickAsteroid : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, IPointerEnterHandler

{

		
	public Spawner spawner;
	public AK.Wwise.Event uiClick;
	
	
	public VariableManager variableManager;
	
	
	public void OnPointerClick(PointerEventData eventData)
	{
		
		if (variableManager.inTransition == false)
		{
			uiClick.Post(gameObject);
			StartCoroutine(EventDelay());
		}


		
		
	}		
		

	private IEnumerator EventDelay()
	{
		yield return new WaitForSeconds(0.5f);
		
		StartEvent();
	}
	
	private void StartEvent()
	{
			spawner.SpawnAsteroid();
	}	
}	