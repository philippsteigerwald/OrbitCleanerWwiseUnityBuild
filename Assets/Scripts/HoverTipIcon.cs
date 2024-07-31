using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTipIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AK.Wwise.Event hoverSound;

    void Start() { }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(SoundHover());
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
