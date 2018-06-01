using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class EventTriggerButton : EventTrigger
{
    public GameObject infoPanel;

    public override void OnPointerEnter(PointerEventData data)
    {
        OnHover();
    }

    public override void OnPointerExit(PointerEventData data)
    {
        OnExit();
    }

    public void OnHover()
    {
        GetComponent<DataReceiver>().valueHandlerClass.infoPanel.gameObject.SetActive(true);

    }

    public void OnExit()
    {
        GetComponent<DataReceiver>().valueHandlerClass.infoPanel.gameObject.SetActive(false);
    }

}
