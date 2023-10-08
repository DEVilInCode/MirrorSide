using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Обработчик взаимодействия с объектом карты
/// </summary>
public class CardDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Min(0)]
    public Vector2 CardShow;
    [Min(1)]
    public float Scale;

    private Vector2 offset;
    private Vector2 initialPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - eventData.pointerCurrentRaycast.worldPosition;
        initialPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = eventData.pointerCurrentRaycast.worldPosition;
        newPos.z = 0;
        transform.position = (Vector2)newPos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localPosition += (Vector3)CardShow;
        transform.localScale *= Scale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localPosition -= (Vector3)CardShow;
        transform.localScale /= Scale;
    }
}
