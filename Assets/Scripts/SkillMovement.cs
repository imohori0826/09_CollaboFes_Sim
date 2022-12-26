using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillMovement : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{

    
    public Transform defaultParent;

   public void OnBeginDrag(PointerEventData eventData)
    {
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent,false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 cardPos = Camera.main.ScreenToWorldPoint(eventData.position);
        cardPos.z = 0;
        transform.position = cardPos;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void SetSkillTransform(Transform parentTransform) {
        defaultParent = parentTransform;
        transform.SetParent(defaultParent);
    }


    
}
