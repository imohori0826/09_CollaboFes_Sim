using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    SkillView view;// ������(view)�Ɋւ��邱�Ƃ𑀍�
    SkillModel model; //�f�[�^(model)�Ɋւ��邱�Ƃ𑀍�


    private void Awake()
    {
        view = GetComponent<SkillView>();
    }

    public void Init(int skillID) {
        model = new SkillModel(skillID);
        view.Show(model);
    }
}
