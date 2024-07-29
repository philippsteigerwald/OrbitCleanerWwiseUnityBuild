using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class BlindModeToggle : MonoBehaviour, IPointerClickHandler
{

	//public Canvas tutorialCanvas;	
	
	public VariableManager variableManager;
	
	public TextMeshProUGUI blindTextBox;
	

	
	public GameObject blackCurtainObject;
	
	
	public AK.Wwise.Event uiClick;

	private bool toggleBool = false;
	
	
	public void Start()
	{
		
			//blindTextBox.text = "BlindModeOff";
			//gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(201/360, 84/100, 88/100);

		
		

		
	}


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
		if (variableManager.blackCurtainActive == false)
		{
			//variableManager.blackCurtainActive = false;
			blindTextBox.text = "BlindModeOn";
			gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(201/360, 84/100, 88/100);
			
			//gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(201, 84, 88);
			
		}
		
		else
		{
			//variableManager.blackCurtainActive = true;
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