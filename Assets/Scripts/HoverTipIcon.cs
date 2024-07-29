using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class HoverTipIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{	
	
	
	//public RectTransform tipWindow;
	public AK.Wwise.Event hoverSound;
	
	
	
	void Start() 
	{
		
	}
	
	
	public void OnPointerEnter(PointerEventData eventData)
	{


				StopAllCoroutines();
				StartCoroutine(SoundHover());
				//StartCoroutine(InfoHover());
				
				
				

	}
	
		public void OnPointerExit(PointerEventData eventData)
	{

				

				StopAllCoroutines();



				hoverSound.Stop(gameObject);
	}				
	
	

	
		private void PlaySound()
	{
		

		hoverSound.Post(gameObject);
	
	}
		
	
	

	
		private IEnumerator SoundHover()
	{
		yield return new WaitForSeconds(1f);
		
		PlaySound();
	}
}

