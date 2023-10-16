using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeft : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{  
    public void OnPointerDown(PointerEventData eventData)
    {
        Player.instance.MoveLeft();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Player.instance.StopMove();
    }
}
