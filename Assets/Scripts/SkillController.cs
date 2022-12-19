using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    SkillView view;// Œ©‚©‚¯(view)‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì
    SkillModel model; //ƒf[ƒ^(model)‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì


    private void Awake()
    {
        view = GetComponent<SkillView>();
    }

    public void Init(int skillID) {
        model = new SkillModel(skillID);
        view.Show(model);
    }
}
