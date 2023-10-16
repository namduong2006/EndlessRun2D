using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Player.instance.MoveRight();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Player.instance.StopMove();
    }
}
