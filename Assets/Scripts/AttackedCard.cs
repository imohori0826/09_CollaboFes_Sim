using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//攻撃される側
public class AttackedCard : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        /*攻撃         **/

        //attackerカードを選択(ストックから選択)
        SkillController attacker = eventData.pointerDrag.GetComponent<SkillController>();

        //defenderカード一覧を取得
        SkillController defender = GetComponent<SkillController>();


        if (attacker == null || defender == null) {
            return;
        }

        if (attacker.model.canAttack) {
            //attackerとdefenderを戦わせる
            GameManager.instance.SkillBattle(attacker, defender);
        }

    }


}
