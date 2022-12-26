using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    SkillView view;// ������(view)�Ɋւ��邱�Ƃ𑀍�
    public SkillModel model; //�f�[�^(model)�Ɋւ��邱�Ƃ𑀍�
    public SkillMovement movement; //�ړ�(movement)�Ɋւ��邱�Ƃ𑀍�

    private void Awake()
    {
        view = GetComponent<SkillView>();
        movement = GetComponent<SkillMovement>();
    }

    public void Init(int skillID) {
        model = new SkillModel(skillID);
        view.Show(model);
    }

    public void Attack(SkillController enemySkill) {
        model.Attack(enemySkill);

        SetCanAttack(false);
    }

    public void SetCanAttack(bool canAttack) {
        model.canAttack = canAttack;
        view.SetActiveSelectablePanel(canAttack);


    }

    public void Reflesh() {
        view.Refresh(model);
    }


    public void CheckAlive() {
        if (model.isAlive)
        {
            view.Refresh(model);

        }
        else {
            Destroy(this.gameObject);
        }
    }
}
