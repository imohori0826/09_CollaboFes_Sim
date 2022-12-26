

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�U������鑤
public class AttackedHero : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        /*�U�� **/
        //attacker�J�[�h��I��(�X�g�b�N����I��)
        SkillController attacker = eventData.pointerDrag.GetComponent<SkillController>();


        if (attacker == null)
        {
            return;
        }

        if (attacker.model.canAttack)
        {
            //attacker��Hero�ɍU������
            GameManager.instance.AttackedToHero(attacker,true);
        }

    }


}
