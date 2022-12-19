using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems
    ;
public class DropPlace : MonoBehaviour, IDropHandler
{
   
    public void OnDrop(PointerEventData eventData)
    {
        SkillMovement skill = eventData.pointerDrag.GetComponent<SkillMovement>();
        if (skill != null) {
            skill.defaultParent = this.transform;

        }

    }
   

}
