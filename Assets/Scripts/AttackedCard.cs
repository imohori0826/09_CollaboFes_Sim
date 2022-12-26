using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�U������鑤
public class AttackedCard : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        /*�U��         **/

        //attacker�J�[�h��I��(�X�g�b�N����I��)
        SkillController attacker = eventData.pointerDrag.GetComponent<SkillController>();

        //defender�J�[�h�ꗗ���擾
        SkillController defender = GetComponent<SkillController>();


        if (attacker == null || defender == null) {
            return;
        }

        if (attacker.model.canAttack) {
            //attacker��defender���킹��
            GameManager.instance.SkillBattle(attacker, defender);
        }

    }


}
