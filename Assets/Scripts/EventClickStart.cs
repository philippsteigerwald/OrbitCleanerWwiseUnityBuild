using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class EventClickStart : MonoBehaviour, IPointerClickHandler//, IPointerDownHandler, IPointerEnterHandler

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
			
				
		
				
	}
	
	private IEnumerator EventDelay()
	{
		yield return new WaitForSeconds(0.15f);
		
		StartEvent();
	}
	
	private void StartEvent()
	{
			
			
			
			variableManager.StartGame();
	}

	


}