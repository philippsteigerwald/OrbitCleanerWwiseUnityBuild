using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class HoverTipLetter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{	
	
	
	public RectTransform tipWindow;

	public RectTransform tipWindowV2;
	//public AK.Wwise.Event hoverSound;

	public GameObject player;
	public SpriteRenderer spriteRendererListener;

	public VariableManager variableManager;
	
	
	
	void Start() 
	{
		
	}
	
	
	public void OnPointerEnter(PointerEventData eventData)
	{


				StopAllCoroutines();
				//StartCoroutine(SoundHover());
				StartCoroutine(InfoHover());
				
				
				

	}
	
		public void OnPointerExit(PointerEventData eventData)
	{

				

				StopAllCoroutines();

				tipWindow.gameObject.SetActive(false);


				if (variableManager.enableV2 == true)
				{
					tipWindowV2.gameObject.SetActive(false);
				}


				if (variableManager.blackCurtainActive == false)
				{

				player.SetActive(true);
				spriteRendererListener.enabled = true;
				}



	}				
	
	
	private void ShowInfo()
	{
		
		if (variableManager.enableV2 == true)
		{
			tipWindowV2.gameObject.SetActive(true);
		}

		else 
		{
			tipWindow.gameObject.SetActive(true);
		}
		variableManager.KillAllGameobjects();
		player.SetActive(false);
		spriteRendererListener.enabled = false;




			
	}	
	

		
	
	
	private IEnumerator InfoHover()
	{
		yield return new WaitForSeconds(0.2f);
		
		ShowInfo();
	}
	

}

