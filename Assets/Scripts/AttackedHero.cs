

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//攻撃される側
public class AttackedHero : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        /*攻撃 **/
        //attackerカードを選択(ストックから選択)
        SkillController attacker = eventData.pointerDrag.GetComponent<SkillController>();


        if (attacker == null)
        {
            return;
        }

        if (attacker.model.canAttack)
        {
            //attackerがHeroに攻撃する
            GameManager.instance.AttackedToHero(attacker,true);
        }

    }


}
