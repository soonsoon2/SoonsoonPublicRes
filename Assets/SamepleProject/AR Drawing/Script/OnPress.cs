using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ARDrawLine _drawLineST;
    bool _pressed = false; 
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true; 
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
        _drawLineST.StopDrawLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pressed)
        {
            _drawLineST.StartDrawLine();
        }
    }
}
